using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using ActivateObjects;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class Test : MonoBehaviour
{
    [SerializeField] private BoxCollider2D _collider2D;
    void Start()
    {
        var sw = new Stopwatch();
        
        sw.Start();
        for (int i = 0; i < 1000;i++)
        {
           
        }
        sw.Start();
        
        Debug.Log($"Get Component time spend: {sw.Elapsed}");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
