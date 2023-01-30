using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    protected Animator Anim;
    protected PlayerAnim playeranim;
    protected PlayerMove playermove;
    protected virtual void Awake()
    {
        Anim = GetComponent<Animator>();
        playermove = GetComponent<PlayerMove>();
        playeranim = GetComponent<PlayerAnim>();
    }
}
