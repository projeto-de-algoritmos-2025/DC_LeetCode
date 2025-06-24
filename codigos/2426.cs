public class Solution {
    public long NumberOfPairs(int[] nums1, int[] nums2, int diff) {
        int n = nums1.Length;
        // Monta o array A em que buscamos pares i<j tais que A[i] <= A[j] + diff
        long[] A = new long[n];
        for (int i = 0; i < n; i++) {
            A[i] = (long)nums1[i] - nums2[i];
        }
        return CountAndSort(A, 0, n - 1, diff);
    }

    // Retorna o número de pares válidos em A[l..r] e ordena A[l..r]
    private long CountAndSort(long[] A, int l, int r, int diff) {
        if (l >= r) return 0;
        int m = (l + r) >> 1;
        long cnt = CountAndSort(A, l, m, diff)
                   + CountAndSort(A, m + 1, r, diff);

        // Contagem entre a metade esquerda A[l..m] e direita A[m+1..r]
        int j = m + 1;
        for (int i = l; i <= m; i++) {
            // avança j enquanto A[i] > A[j] + diff
            while (j <= r && A[i] > A[j] + diff) j++;
            // todos os índices k em [j..r] satisfazem A[i] <= A[k]+diff
            cnt += (r - j + 1);
        }

        // Merge clássico para manter A[l..r] ordenado
        long[] temp = new long[r - l + 1];
        int p1 = l, p2 = m + 1, t = 0;
        while (p1 <= m && p2 <= r) {
            if (A[p1] <= A[p2]) temp[t++] = A[p1++];
            else                temp[t++] = A[p2++];
        }
        while (p1 <= m) temp[t++] = A[p1++];
        while (p2 <= r) temp[t++] = A[p2++];
        Array.Copy(temp, 0, A, l, temp.Length);

        return cnt;
    }
}
