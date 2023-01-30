using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SharedObject
{
    static public DataManager g_DataManager;
    static public PlayerPrefsData g_playerPrefsdata = new PlayerPrefsData();
    static public readonly string SavePath = Application.persistentDataPath + "/SaveData.json";
}
