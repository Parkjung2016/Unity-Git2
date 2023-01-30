using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class DataManager : MonoBehaviour
{

    private void Awake()
    {
        if (SharedObject.g_DataManager == null)
        {
            SharedObject.g_DataManager = this;
            DontDestroyOnLoad(this);
        }
    }

}
