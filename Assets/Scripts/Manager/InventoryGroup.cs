using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryGroup : MonoBehaviour
{
    [SerializeField]
    private Transform SpawnCharacterTrans;
    private void Start()
    {
        GameObject Player = Instantiate(Resources.Load<GameObject>("Prefab/" + (SharedObject.g_playerPrefsdata.playerdata.Gender == 0 ? "Female" : "Male")+"(Inventory)"), SpawnCharacterTrans.position, SpawnCharacterTrans.rotation);
        Player.GetComponent<PlayerAppearance>().ChangeFace(SharedObject.g_playerPrefsdata.playerdata.FaceNum);
        Player.GetComponent<PlayerAppearance>().ChangeHair(SharedObject.g_playerPrefsdata.playerdata.HairNum);

       
    }
}
