using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : Player
{

    private void Update()
    {
        Anim.SetBool("Move", Input.GetButton("Horizontal") || Input.GetButton("Vertical"));
        Anim.SetBool("Sprint", Input.GetButton("Sprint"));
        if(!playermove. Jumping)
        Anim.SetBool("Falling", !playermove._isGrounded);
        else
        Anim.SetBool("Falling", false);

        if(playermove._isGrounded)
        {
            if(Input.GetButtonDown("Jump"))
            {
                Anim.SetTrigger("Jump");
            }
        }
    }
}
