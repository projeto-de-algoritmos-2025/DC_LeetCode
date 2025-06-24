function reversePairs(nums: number[]): number {
    let count = 0;
    
    function mergeSort(left: number, right: number): number[] {
        if (left === right) {
            // faixa de tamanho 1 já está ordenada
            return [nums[left]];
        }
        const mid = Math.floor((left + right) / 2);
        const leftArr = mergeSort(left, mid);
        const rightArr = mergeSort(mid + 1, right);

        // Contagem de pares (i,j) com leftArr[i] > 2 * rightArr[j]
        let j = 0;
        for (let i = 0; i < leftArr.length; i++) {
            while (j < rightArr.length && leftArr[i] > 2 * rightArr[j]) {
                j++;
            }
            count += j;
        }

        // Merge clássico dos dois arrays já ordenados
        const merged: number[] = [];
        let i = 0;
        let k = 0;
        while (i < leftArr.length && k < rightArr.length) {
            if (leftArr[i] <= rightArr[k]) {
                merged.push(leftArr[i++]);
            } else {
                merged.push(rightArr[k++]);
            }
        }
        // resto de leftArr
        while (i < leftArr.length) {
            merged.push(leftArr[i++]);
        }
        // resto de rightArr
        while (k < rightArr.length) {
            merged.push(rightArr[k++]);
        }
        
        return merged;
    }

    if (nums.length > 0) {
        mergeSort(0, nums.length - 1);
    }
    return count;
}
