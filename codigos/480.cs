public class Solution {
    public double[] MedianSlidingWindow(int[] nums, int k) {
        int n = nums.Length;
        var dh = new DualHeap(k);
        double[] ans = new double[n - k + 1];
        for (int i = 0; i < n; i++) {
            dh.Add(nums[i]);
            if (i >= k) dh.Remove(nums[i - k]);
            if (i >= k - 1) ans[i - k + 1] = dh.GetMedian();
        }
        return ans;
    }
}

class DualHeap {
    PriorityQueue<int,long> lo; // max-heap via -(long)x
    PriorityQueue<int,long> hi; // min-heap via (long)x
    Dictionary<int,int> delLo = new(), delHi = new();
    int k, sizeLo = 0, sizeHi = 0;

    public DualHeap(int k) {
        this.k = k;
        lo = new PriorityQueue<int,long>();
        hi = new PriorityQueue<int,long>();
    }

    public void Add(int x) {
        if (sizeLo == 0 || x <= lo.Peek()) {
            lo.Enqueue(x, -(long)x);
            sizeLo++;
        } else {
            hi.Enqueue(x, (long)x);
            sizeHi++;
        }
        Balance();
    }

    public void Remove(int x) {
        if (sizeLo > 0 && x <= lo.Peek()) {
            delLo[x] = delLo.GetValueOrDefault(x) + 1;
            sizeLo--;
            if (x == lo.Peek()) Clean(lo, delLo);
        } else {
            delHi[x] = delHi.GetValueOrDefault(x) + 1;
            sizeHi--;
            if (x == hi.Peek()) Clean(hi, delHi);
        }
        Balance();
    }

    public double GetMedian() {
        return (k % 2 == 1) 
            ? lo.Peek() 
            : ((long)lo.Peek() + hi.Peek()) * 0.5;
    }

    void Balance() {
        if (sizeLo > sizeHi + 1) {
            int v = lo.Dequeue();
            Clean(lo, delLo);
            sizeLo--;
            hi.Enqueue(v, (long)v);
            sizeHi++;
        }
        else if (sizeLo < sizeHi) {
            int v = hi.Dequeue();
            Clean(hi, delHi);
            sizeHi--;
            lo.Enqueue(v, -(long)v);
            sizeLo++;
        }
    }

    void Clean<TPri>(PriorityQueue<int,TPri> pq, Dictionary<int,int> del) where TPri: struct {
        while (pq.Count > 0 && del.TryGetValue(pq.Peek(), out int cnt)) {
            if (cnt == 1) del.Remove(pq.Peek());
            else del[pq.Peek()] = cnt - 1;
            pq.Dequeue();
        }
    }
}
