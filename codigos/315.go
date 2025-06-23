func countSmaller(nums []int) []int {
    if len(nums) == 0 {
        return []int{}
    }
    
    pairs := make([][]int, len(nums))
    for i, num := range nums {
        pairs[i] = []int{num, i}
    }
    
    result := make([]int, len(nums))
    mergeSort(pairs, 0, len(pairs)-1, result)
    
    return result
}

func mergeSort(pairs [][]int, start, end int, result []int) {
    if start >= end {
        return
    }
    
    mid := (start + end) / 2
    mergeSort(pairs, start, mid, result)
    mergeSort(pairs, mid+1, end, result)
    merge(pairs, start, mid, end, result)
}

func merge(pairs [][]int, start, mid, end int, result []int) {
    left := make([][]int, mid-start+1)
    right := make([][]int, end-mid)
    
    for i := 0; i < len(left); i++ {
        left[i] = pairs[start+i]
    }
    for i := 0; i < len(right); i++ {
        right[i] = pairs[mid+1+i]
    }
    
    i, j, k := 0, 0, start
    smallerCount := 0
    
    for i < len(left) && j < len(right) {
        if left[i][0] <= right[j][0] {
            result[left[i][1]] += smallerCount
            pairs[k] = left[i]
            i++
        } else {
            smallerCount++
            pairs[k] = right[j]
            j++
        }
        k++
    }
    
    for i < len(left) {
        result[left[i][1]] += smallerCount
        pairs[k] = left[i]
        i++
        k++
    }
    
    for j < len(right) {
        pairs[k] = right[j]
        j++
        k++
    }
}