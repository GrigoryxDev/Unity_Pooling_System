using System.Collections;
using System.Collections.Generic;
using SpawnSystem;
using UnityEngine;
using UnityEngine.UI;

public class UIRoot : Singleton<UIRoot>
{
    [SerializeField, Header("Spawn system elements")] private Spawner spawner;
    [SerializeField] private ObjectPooler objectPooler;
    [SerializeField] private Counter counter;

    [SerializeField, Header("Text elements")] private Text textCubes;
    [SerializeField] private Text textSpheres;
    [SerializeField] private Text textAutoReturned;
    
    public Spawner Spawner => spawner;
    public ObjectPooler ObjectPooler => objectPooler;
    public Text TextCubes => textCubes;
    public Text TextSpheres => textSpheres;
    public Text TextAutoReturned => textAutoReturned;
    public Counter Counter => counter;
}
