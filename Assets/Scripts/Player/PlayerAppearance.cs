using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAppearance : MonoBehaviour
{
    [SerializeField]
    private GameObject[] Faces;
    [SerializeField]
    private GameObject[] Hairs;
   public void ChangeFace(int Num)
    {
        for(int  i=0;i< Faces.Length;i++)
        {
            Faces[i].SetActive(false);
        }
            Faces[Num].SetActive(true);
    }
    public void ChangeHair(int Num)
    {
        for (int i = 0; i < Hairs.Length; i++)
        {
            Hairs[i].SetActive(false);
        }
        Hairs[Num].SetActive(true);
    }
}
