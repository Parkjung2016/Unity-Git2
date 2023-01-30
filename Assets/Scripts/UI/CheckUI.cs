using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckUI : MonoBehaviour
{
    private GameObject InventoryCamera;
    [SerializeField]
    private GameObject[] Groups;
    private GameObject MainCam;
    private void Awake()
    {
        InventoryCamera = GameObject.FindGameObjectWithTag("InventoryCam");
    }
    private void Start()
    {
        MainCam = Camera.main.gameObject;
        EnableUI(false);
    }
    public void EnableUI(bool enable)
    {
        MainCam.gameObject.SetActive(!enable);
        InventoryCamera.SetActive(enable);
            MainCanvas.Instance.MainGroup.SetActive(!enable);
        Cursor.lockState =enable ? CursorLockMode.None : CursorLockMode.Locked;
        Cursor.visible = enable;
        gameObject.SetActive(enable);
    }
    public void EnableGroup(int Index)
    {
        for(int i =0;i <Groups.Length;i++)
        {
            Groups[i].SetActive(false);
        }
        Groups[Index].SetActive(true);
    }
}
