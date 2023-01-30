using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCanvas : Singleton<MainCanvas>
{
    public CheckUI checkUI;
    public GameObject MainGroup;
    protected override void Awake()
    {
        checkUI = GetComponentInChildren<CheckUI>();
        base.Awake();
    }
    // Update is called once per frame
    void Update()
    {
     if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            checkUI.EnableUI(true);
            checkUI.EnableGroup(0);
        }
    }
}
