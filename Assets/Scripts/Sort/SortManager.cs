using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SortManager : Singleton<SortManager>
{
    // 6|1|5|4|8|9
    // sort����������ͨ���ţ����ݹ�ֶκ��������С��ĳ����ֵʱ����ʹ�ò�������
    // ���ݹ��ι���ֳ������������򣬻�ʹ�ö�����

    #region ��������
    public void QuickSort(List<int> nums)
    {
        int l = 0, r = nums.Count - 1;
        Game.Instance.StartCoroutine(QuickSort(nums, l, r));
    }

    private IEnumerator QuickSort(List<int> nums, int l, int r)
    {
        if(l >= r)
        {
            yield break;
        }
        
        int _l = l, _r = r;
        int m = l + (r - l >> 1);
        int pivot = nums[m];
        nums[m] = nums[l];
        nums[l] = pivot;
        SortCubeManager.GetInstance().SetCubeNum(m, nums[l]);
        yield return new WaitForSeconds(1);
        while (l < r)
        {
            while (l < r && nums[r] > pivot)
            {
                --r;
            }
            nums[l++] = nums[r];
            SortCubeManager.GetInstance().SetCubeNum(l - 1, nums[r]);
            yield return new WaitForSeconds(1);
            while (l < r && nums[l] < pivot)
            {
                ++l;
            }
            nums[r--] = nums[l];
            SortCubeManager.GetInstance().SetCubeNum(r + 1, nums[l]);
            yield return new WaitForSeconds(1);
        }
        nums[l] = pivot;
        SortCubeManager.GetInstance().SetCubeNum(l, pivot);
        yield return new WaitForSeconds(1);
        Game.Instance.StartCoroutine(QuickSort(nums, _l, l - 1));
        Game.Instance.StartCoroutine(QuickSort(nums, l + 1, _r));
    }
    #endregion

    #region ������
    public void HeapSort(List<int> nums)
    {
        Game.Instance.StartCoroutine(HeapSortCor(nums));
    }

    private IEnumerator HeapSortCor(List<int> nums)
    {
        int n = nums.Count;
        // ����
        for (int i = (n - 1) / 2; i >= 0; --i)
        {
            yield return Heapify(nums, i, n);
        }
        yield return new WaitForSeconds(2);
        // ����
        for (int i = n - 1; i > 0; --i)
        {
            int temp = nums[0];
            nums[0] = nums[i];
            nums[i] = temp;
            SortCubeManager.GetInstance().ChangeCube(0, i);
            yield return Heapify(nums, 0, i);
        }
        PrintList(nums, "HeapSort end: ");
    }

    private IEnumerator Heapify(List<int> nums, int i, int n)
    {
        int largest = i;
        int lson = i * 2;
        int rson = i * 2 + 1;
        if (lson < n && nums[largest] < nums[lson])
        {
            largest = lson;
        }
        if (rson < n && nums[largest] < nums[rson])
        {
            largest = rson;
        }
        if(largest != i)
        {
            int temp = nums[largest];
            nums[largest] = nums[i];
            nums[i] = temp;
            SortCubeManager.GetInstance().ChangeCube(largest, i);
            yield return new WaitForSeconds(1);
            yield return Heapify(nums, largest, n);
        }
    }
    #endregion

    #region ��������
    public void InsertSort(List<int> nums)
    {
        Game.Instance.StartCoroutine(InsertSortCor(nums));
    }

    private IEnumerator InsertSortCor(List<int> nums)
    {
        int n = nums.Count;
        for(int i = 1; i < n; ++i)
        {
            int j = i - 1, num = nums[i];
            for(; j >= 0; --j)
            {
                if(nums[j] > num)
                {
                    nums[j + 1] = nums[j];
                    SortCubeManager.GetInstance().SetCubeNum(j + 1, nums[j]);
                    yield return new WaitForSeconds(1);
                }
                else
                {
                    break;
                }
            }
            if(j != i - 1)
            {
                nums[j + 1] = num;
                SortCubeManager.GetInstance().SetCubeNum(j + 1, num);
                yield return new WaitForSeconds(1);
            }
        }
        yield return null;
    }
    #endregion

    #region ð������
    public void BubbleSort(List<int> nums)
    {
        Game.Instance.StartCoroutine(BubbleSortCor(nums));
    }

    private IEnumerator BubbleSortCor(List<int> nums)
    {
        int n = nums.Count;
        for(int i = n - 1; i > 0; --i)
        {
            for(int j = 1; j <= i; ++j)
            {
                if(nums[j - 1] > nums[j])
                {
                    int temp = nums[j - 1];
                    nums[j - 1] = nums[j];
                    nums[j] = temp;
                    SortCubeManager.GetInstance().ChangeCube(j - 1, j);
                    yield return new WaitForSeconds(1);
                }
            }
        }
        yield return null;
    }
    #endregion

    #region �鲢����
    public void MergeSort(List<int> nums)
    {
        Game.Instance.StartCoroutine(MergeSortCor(nums, 0, nums.Count - 1));
    }

    private IEnumerator MergeSortCor(List<int> nums, int l, int r)
    {
        if(l >= r)
        {
            yield break;
        }

        int m = l + (r - l >> 1);
        yield return MergeSortCor(nums, l, m);
        yield return MergeSortCor(nums, m + 1, r);

        List<int> mergeList = new List<int>();
        int _l = l, _r = m + 1;
        while(_l <= m && _r <= r)
        {
            if(nums[_l] <= nums[_r])
            {
                mergeList.Add(nums[_l++]);
            }
            else
            {
                mergeList.Add(nums[_r++]);
            }
        }
        while(_l <= m)
        {
            mergeList.Add(nums[_l++]);
        }
        while (_r <= r)
        {
            mergeList.Add(nums[_r++]);
        }
        for(int i = 0; i < mergeList.Count; ++i)
        {
            nums[l + i] = mergeList[i];
            SortCubeManager.GetInstance().SetCubeNum(l + i, mergeList[i]);
            yield return new WaitForSeconds(1);
        }

        yield return null;
    }
    #endregion

    #region ѡ������
    public void SelectionSort(List<int> nums)
    {
        Game.Instance.StartCoroutine(SelectionSortCor(nums));
    }

    private IEnumerator SelectionSortCor(List<int> nums)
    {
        int n = nums.Count;
        for(int i = 0; i < n; ++i)
        {
            int smallest = i;
            for(int j = i + 1; j < n; ++j)
            {
                if(nums[j] < nums[smallest])
                {
                    smallest = j;
                }
            }
            if(smallest != i)
            {
                int temp = nums[i];
                nums[i] = nums[smallest];
                nums[smallest] = temp;
                SortCubeManager.GetInstance().ChangeCube(i, smallest);
                yield return new WaitForSeconds(1);
            }
        }
        yield return null;
    }
    #endregion

    private void PrintList(List<int> nums, string str = "")
    {
        foreach(int num in nums){
            str += num.ToString();
            str += " ";
        }
        Debug.Log(str);
    }
}
