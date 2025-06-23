# @param {Integer[]} nums
# @param {Integer} lower
# @param {Integer} upper
# @return {Integer}
def count_range_sum(nums, lower, upper)
  return 0 if nums.empty?
  
  prefix_sums = [0]
  nums.each { |num| prefix_sums << prefix_sums.last + num }
  
  count_with_sorted_array(prefix_sums, lower, upper)
end

def count_with_sorted_array(prefix_sums, lower, upper)
  sorted_sums = []
  count = 0
  
  (prefix_sums.length - 1).downto(0) do |i|
    left_bound = prefix_sums[i] + lower
    right_bound = prefix_sums[i] + upper
    
    left_idx = binary_search_left(sorted_sums, left_bound)
    right_idx = binary_search_right(sorted_sums, right_bound)
    count += right_idx - left_idx
    
    insert_position = binary_search_left(sorted_sums, prefix_sums[i])
    sorted_sums.insert(insert_position, prefix_sums[i])
  end
  
  count
end

def binary_search_left(arr, target)
  left, right = 0, arr.length
  
  while left < right
    mid = (left + right) / 2
    if arr[mid] < target
      left = mid + 1
    else
      right = mid
    end
  end
  
  left
end

def binary_search_right(arr, target)
  left, right = 0, arr.length
  
  while left < right
    mid = (left + right) / 2
    if arr[mid] <= target
      left = mid + 1
    else
      right = mid
    end
  end
  
  left
end