using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSVData
{
    public List<Dictionary<string, object>> Itemdata;
    public List<Dictionary<string, object>> PlayerSTAT;
    public List<Dictionary<string, object>> ItemUpgradeValue;
    public List<Dictionary<string, object>> SkillInfo;
    public List<Dictionary<string, object>> Quest;
    public List<Dictionary<string, object>> Monster;
    public List<Dictionary<string, object>> Pet;
    public readonly int[] ItemTypeNum = { 0, 6, 12, 18, 24, 30 };
    public readonly int[] ItemTypeNum2 = { 0, 6, 12, 18, 24, 30 };
    public readonly int[] CurrentPotionTypeNum = { 33,  34, 35, };
    public readonly string[] ItemUpgradeType = { "WeaponValue", "HelmetValue", "ArmorValue", "LeggingsValue", "BootsValue" };
}
