using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class LobbyManager : MonoBehaviour
{
    [SerializeField]
    private Transform PlayerSpawnTrans;
    private CinemachineFreeLook PlayerCam;
    private void Awake()
    {
        PlayerCam = FindObjectOfType<CinemachineFreeLook>();
    }
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        GameObject Player = Instantiate(Resources.Load<GameObject>("Prefab/"+ (SharedObject.g_playerPrefsdata.playerdata.Gender == 0 ? "Female" : "Male")), PlayerSpawnTrans.position, PlayerSpawnTrans.rotation);
        Player.GetComponent<PlayerAppearance>().ChangeFace(SharedObject.g_playerPrefsdata.playerdata.FaceNum);
        Player.GetComponent<PlayerAppearance>().ChangeHair(SharedObject.g_playerPrefsdata.playerdata.HairNum);
        GameObject LookAt = GameObject.FindGameObjectWithTag("CamLookAt");
        PlayerCam.m_Follow = Player.transform;
        PlayerCam.m_LookAt = LookAt.transform;
        FindObjectOfType<Minimap>().Player = Player;
    }
}
