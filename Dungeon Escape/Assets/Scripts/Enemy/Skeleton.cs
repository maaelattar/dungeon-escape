using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : Enemy, IDamagable
{
     
     public int Health { get; set; }

     public override void Init()
     {
          base.Init();
          Health = base.health;
     }

     public void Damage()
     {
          if (isDead == true)
          {
               return;
          }
          Health--;
          base.health = Health;
          anim.SetTrigger("Hit");
          isHit = true;
          anim.SetBool("InCombat", true);
          if(Health < 1)
          {
               isDead = true;
               anim.SetTrigger("Death");
               GameObject diamond = Instantiate(diamondPrefab, transform.position, Quaternion.identity) as GameObject;
               diamond.GetComponent<Diamond>().gems = base.gems;
          }
     }
}
