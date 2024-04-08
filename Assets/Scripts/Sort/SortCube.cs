using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SortCube : MonoBehaviour
{
    public Image block;
    public Text num;

    public void SetBlock(Transform parent, int i)
    {
        transform.SetParent(parent);
        SetNum(i);
    }

    public void SetNum(int i)
    {
        num.text = i.ToString();
        GetComponent<RectTransform>().sizeDelta = new Vector2(100, 100 + i * 10);
    }

    public void AdjustPosition(float x, float y)
    {
        transform.position = new Vector2(x, y);
    }

    public void AdjustPosition(Vector3 pos)
    {
        transform.position = pos;
    }

    public Vector3 GetPosition()
    {
        return transform.position;
    }
}
