using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

public class CharacterSelectCanvas : MonoBehaviour
{
    [SerializeField]
    private Animator[] CharacterAnimators;
    [SerializeField]
    private Transform CharacterCustomzingTrans;
    [SerializeField]
    private Vector3 CharacterCustomzingPos;
    private Vector3 OriginCameraPos;
    private Vector3 OriginFemalePos;
    private Vector3 OriginmalePos;
    [SerializeField]
    private GameObject[] UIGroups;
    private int CurrentGender;
    [SerializeField]
    private GameObject[] FemaleHairs;
    [SerializeField]
    private GameObject[] FemaleFaces;
    [SerializeField]
    private GameObject[] MaleHairs;
    [SerializeField]
    private GameObject[] MaleFaces;
    private int CurrentHair;
    private int CurrentFace;
    [SerializeField]
    private GameObject[] HairBtn;
    [SerializeField]
    private GameObject[] FaceBtn;
    private int MaxFaceCount = 0;
    private int MaxHairCount = 0;

    [SerializeField]
    private Text CurrentHairText;
    [SerializeField]
    private Text CurrentFaceText;
    private void Start()
    {
        OriginCameraPos = Camera.main.transform.position;
        EnableUIGroup(0, true);
        OriginFemalePos = CharacterAnimators[0].gameObject.transform.position;
        OriginmalePos = CharacterAnimators[1].gameObject.transform.position;

    }
    public void SelectGender(int Num)
    {
        StartCoroutine(ChangePosition(1,CharacterAnimators[Num], CharacterCustomzingTrans.position, CharacterCustomzingPos,new Vector3(0, 160, 0)));
        CurrentGender = Num;
        CurrentFace = 0;
        CurrentHair = 0;
        RefreshCustomzing();

      
        if (CurrentGender == 0)
        {
            MaxFaceCount = FemaleFaces.Length;
            MaxHairCount = FemaleHairs.Length;
            CharacterAnimators[1].CrossFade("SadIdle", .2f,-1,0);
        }
        else
        {
            MaxFaceCount = MaleFaces.Length;
            MaxHairCount = MaleHairs.Length;
            CharacterAnimators[0].CrossFade("SadIdle", .1f,-1,0);
        }
    }
    public void Back()
    {
        CurrentHair = 0;
        CurrentFace = 0;
        ChangeHair();
        ChangeFace();
        StartCoroutine(ChangePosition(0,CharacterAnimators[CurrentGender], CurrentGender == 0 ? OriginFemalePos : OriginmalePos, OriginCameraPos, new Vector3(0,CurrentGender ==0 ? -203:203, 0)));
        if (CurrentGender == 0)
        {

            CharacterAnimators[1].CrossFade("Locomotion", .2f, -1, 0);
        }
        else
        {

            CharacterAnimators[0].CrossFade("Locomotion", .2f, -1, 0);
        }
    }
    public void StartGame()
    {
        SharedObject.g_playerPrefsdata.playerdata.HairNum = CurrentHair;
        SharedObject.g_playerPrefsdata.playerdata.FaceNum = CurrentFace;
        SharedObject.g_playerPrefsdata.playerdata.Gender = CurrentGender;
        SceneManager.LoadScene("Lobby");
    }
    IEnumerator ChangePosition(int UIGroupIndex, Animator anim,Vector3 CharacterMovePos,Vector3 CameraMovePos,Vector3 Rotate)
    {

            EnableUIGroup(UIGroupIndex == 1 ? 0:1, false);
            DOTween.To(() => anim.GetFloat("Speed"), x => anim.SetFloat("Speed", x), .5f, .5f);
            anim.gameObject.transform.DOMove(CharacterMovePos, 3f);
            anim.gameObject.transform.DOLookAt(CharacterMovePos, .5f,AxisConstraint.Y);
            Camera.main.transform.DOMove(CameraMovePos, 3);
            yield return new WaitForSeconds(2.1f);
            DOTween.To(() => anim.GetFloat("Speed"), x => anim.SetFloat("Speed", x), 0, .5f);
            anim.gameObject.transform.DORotate(Rotate, .5f);
            EnableUIGroup(UIGroupIndex, true);
    }
    public void NextHair()
    {
        if(CurrentHair != MaxHairCount-1)
        {
        CurrentHair++;
        ChangeHair();

        }
    }
    public void PreviousHair()
    {
        if (CurrentHair != 0)
        {
            CurrentHair--;
            ChangeHair();

        }
    }
 
    public void NextFace()
    {
        if(CurrentFace != MaxFaceCount-1)
        {
        CurrentFace++;
        ChangeFace();

        }
    }
    public void PreviousFace()
    {
        if (CurrentFace != 0)
        {
            CurrentFace--;
            ChangeFace();

        }
    }
    public void RefreshCustomzing()
    {
        CurrentFaceText.text = "¾ó±¼0"+ CurrentFace.ToString();
        CurrentHairText.text = "¸Ó¸®0"+ CurrentHair.ToString();
        if(CurrentFace == 0)
        {
            FaceBtn[0].SetActive(false);
            FaceBtn[1].SetActive(true);
        }
        else if(CurrentFace == MaxFaceCount-1)
        {
            FaceBtn[0].SetActive(true);
            FaceBtn[1].SetActive(false);
        }
        else
        {
            FaceBtn[0].SetActive(true);
            FaceBtn[1].SetActive(true);
        }
        if (CurrentHair == 0)
        {
            HairBtn[0].SetActive(false);
            HairBtn[1].SetActive(true);
        }
        else if (CurrentHair == MaxHairCount-1)
        {
            HairBtn[0].SetActive(true);
            HairBtn[1].SetActive(false);
        }
        else
        {
            HairBtn[0].SetActive(true);
            HairBtn[1].SetActive(true);
        }
    }
    public void ChangeFace()
    {
        if(CurrentGender== 0)
        {
            for (int i = 0; i < FemaleFaces.Length; i++)
                FemaleFaces[i].gameObject.SetActive(false);
            FemaleFaces[CurrentFace].SetActive(true);
        }
        else
        {
            for (int i = 0; i < MaleFaces.Length; i++)
                MaleFaces[i].gameObject.SetActive(false);
            MaleFaces[CurrentFace].SetActive(true);
        }
        RefreshCustomzing();
    }
    public void ChangeHair()
    {
        if (CurrentGender == 0)
        {
            for (int i = 0; i < FemaleFaces.Length; i++)
                FemaleHairs[i].gameObject.SetActive(false);
            FemaleHairs[CurrentHair].SetActive(true);
        }
        else
        {
            for (int i = 0; i < MaleFaces.Length; i++)
                MaleHairs[i].gameObject.SetActive(false);
            MaleHairs[CurrentHair].SetActive(true);
        }
        RefreshCustomzing();
    }
    public void EnableUIGroup(int Num,bool Enable)
    {
        for (int i = 0; i < UIGroups.Length; i++)
            UIGroups[i].SetActive(false);
        if(Enable)
        {

        UIGroups[Num].SetActive(Enable);
        }
    }
}
