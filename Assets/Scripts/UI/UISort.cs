using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISort : MonoBehaviour
{
    public InputField InputField;
    public Button QuickBtn;
    public Button HeapBtn;
    public Button InsertBtn;
    public Button BubbleBtn;
    public Button MergeBtn;
    public Button SelectionBtn;

    // Start is called before the first frame update
    void Start()
    {
        QuickBtn.onClick.AddListener(QuickSort);
        HeapBtn.onClick.AddListener(HeapSort);
        InsertBtn.onClick.AddListener(InsertSort);
        BubbleBtn.onClick.AddListener(BubbleSort);
        MergeBtn.onClick.AddListener(MergeSort);
        SelectionBtn.onClick.AddListener(SelectionSort);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private List<int> GetList()
    {
        var str = InputField.text;
        var strs = str.Split('|');
        List<int> nums = new List<int>();
        for(int i = 0; i < strs.Length; ++i)
        {
            nums.Add(int.Parse(strs[i]));
        }

        SortCubeManager.GetInstance().InitCubes(nums);
        return nums;
    }

    private void QuickSort()
    {
        SortManager.GetInstance().QuickSort(GetList());
    }

    private void HeapSort()
    {
        SortManager.GetInstance().HeapSort(GetList());
    }

    private void InsertSort()
    {
        SortManager.GetInstance().InsertSort(GetList());
    }

    private void BubbleSort()
    {
        SortManager.GetInstance().BubbleSort(GetList());
    }

    private void MergeSort()
    {
        SortManager.GetInstance().MergeSort(GetList());
    }

    private void SelectionSort()
    {
        SortManager.GetInstance().SelectionSort(GetList());
    }
}
