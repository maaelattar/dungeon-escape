using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
     Animator anim;
     private Animator swordAnimation;
    void Start()
    {
          anim = GetComponentInChildren<Animator>();
          swordAnimation = transform.GetChild(1).GetComponent<Animator>();
    }

    

     public void Move(float move)
     {
          anim.SetFloat("Move", Mathf.Abs(move));
     }


     public void Jump(bool jumping)
     {
          anim.SetBool("Jumping", jumping);
     }

     public void Attack()
     {
          anim.SetTrigger("Attack");
          swordAnimation.SetTrigger("Sword_Animation");
     }

     public void Death()
     {
          anim.SetTrigger("Death");
          
     }
}
