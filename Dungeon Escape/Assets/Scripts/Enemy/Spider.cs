using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : Enemy, IDamagable
{
     public GameObject acidEffectPefab;
     public int Health { get; set; }

     public override void Init()
     {
          base.Init();
          Health = base.health;
     }


     public override void Update()
     {
          
     }
     public void Damage()
     {
          if(isDead == true)
          {
               return;
          }
          Health--;
          base.health = Health;
          if (Health < 1)
          {
               isDead = true;
               anim.SetTrigger("Death");

               GameObject diamond = Instantiate(diamondPrefab, transform.position, Quaternion.identity) as GameObject;
               diamond.GetComponent<Diamond>().gems = base.gems;
          }
     }

     public void Attack()
     {
          Instantiate(acidEffectPefab, transform.position, Quaternion.identity);
     }
}
