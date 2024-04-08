using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SortCubeManager : Singleton<SortCubeManager>
{
    public Transform parent;
    private GameObject cube;
    private List<SortCube> cubes = new List<SortCube>();

    public void OnInit()
    {
        parent = GameObject.Find("Canvas").GetComponent<Transform>();
        cube = Resources.Load("SortCube") as GameObject;
    }

    private void ClearCubes()
    {
        for(int i = 0; i < cubes.Count; ++i)
        {
            Object.Destroy(cubes[i].gameObject);
        }
        cubes.Clear();
    }

    public void InitCubes(List<int> nums)
    {
        ClearCubes();
        int n = nums.Count;
        int width = Screen.width - 200, height = Screen.height;
        float interval = (width - (100 * n)) / (n + 1);
        for(int i = 0; i < n; ++i)
        {
            InitCube(nums[i], i, n, interval * (i + 1) + 100 * i);
        }
    }

    private void InitCube(int num, int i, int n, float x)
    {
        var _cube = Object.Instantiate(cube);
        var cubeScripts = _cube.GetComponent<SortCube>();
        cubeScripts.SetBlock(parent, num);
        cubeScripts.AdjustPosition(x, 0);
        cubes.Add(cubeScripts);
    }

    public void ChangeCube(int l, int r)
    {
        var pos1 = cubes[l].GetPosition();
        var pos2 = cubes[r].GetPosition();
        cubes[l].AdjustPosition(pos2);
        cubes[r].AdjustPosition(pos1);
        var tempCube = cubes[l];
        cubes[l] = cubes[r];
        cubes[r] = tempCube;
    }

    public void SetCubeNum(int i, int num)
    {
        cubes[i].SetNum(num);
    }
}
