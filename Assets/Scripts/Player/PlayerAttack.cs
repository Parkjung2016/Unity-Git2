using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (ReferenceEquals(SharedObject.g_playerPrefsdata.playerdata.EquipedWeapon, null))
            {
                print("�ָ԰���");
            }
            else
            {
                print("�������");
            }
        }
    }
}
