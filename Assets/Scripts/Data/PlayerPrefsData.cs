using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using Newtonsoft.Json;
using System.Runtime.Serialization.Formatters.Binary;

public class PlayerPrefsData
{
    public class PlayerDataNoSave
    {
        
    }
    [Serializable]
    public class PlayerData
    {
        public int Gender = 1;
        public int HairNum = 0;
        public int FaceNum = 0;
        public List<WeaponInfo> WeaponList;
        public WeaponInfo EquipedWeapon;
    }
    public PlayerData playerdata = new PlayerData();
    public PlayerDataNoSave playerdataNoSave = new PlayerDataNoSave();

}

