using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class SharedScript : Singleton<SharedScript>
{

    public CSVData csvdata = new CSVData();
    protected override void Awake()
    {
        base.Awake();
    }
 
}
