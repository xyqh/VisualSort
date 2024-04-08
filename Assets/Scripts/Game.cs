using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public static Game Instance;

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        SortCubeManager.GetInstance().OnInit();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
