using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Counter : MonoBehaviour
{
     private UIRoot uIRoot;
    private int cubesCounter;
    private int spheresCounter;
    private int autoReturnedCounter;

    public UIRoot UIRoot => uIRoot ?? (uIRoot = UIRoot.Instance);
    public int CubesCounter
    {
        get => cubesCounter;
        set
        {
            cubesCounter = value;
            UIRoot.TextCubes.text = $"Cubes on Screen: {cubesCounter}";
        }
    }
    public int SpheresCounter
    {
        get => spheresCounter;
        set
        {
            spheresCounter = value;
            UIRoot.TextSpheres.text = $"Spheres on Screen: {spheresCounter}";
        }
    }

    public int AutoReturnedCounter
    {
        get => autoReturnedCounter;
        set
        {
            autoReturnedCounter = value;
            UIRoot.TextAutoReturned.text = $"Auto returned on Screen: {autoReturnedCounter}";
        }
    }



    private void Start()
    {
        Reset();
    }

    public void Reset()
    {
        CubesCounter = 0;
        SpheresCounter = 0;
        AutoReturnedCounter = 0;
    }
}
