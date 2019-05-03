using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
     public GameObject diamondPrefab;
     // Start is called before the first frame update
     [SerializeField]
     protected int health;
     [SerializeField]
     protected float speed;
     [SerializeField]
     protected int gems;
     [SerializeField]
     protected Transform pointA, pointB;

     protected Vector3 currentTarget;
     protected Animator anim;
     protected SpriteRenderer sprite;

     protected Player player;

     protected bool isHit = false;
     protected bool isDead = false;
     public virtual void Init()
     {
          anim = GetComponentInChildren<Animator>();
          sprite = GetComponentInChildren<SpriteRenderer>();
          player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
     }

     public void Start()
     {
          Init();
     }

     public virtual void Update()
     {

          if (anim.GetCurrentAnimatorStateInfo(0).IsName("Idle") && anim.GetBool("InCombat") == false)
          {
               return;
          }

          if(isDead == false)
          {
               Movement();
          }

          


     }


     public virtual void Movement()
     {
          if (currentTarget == pointA.position)
          {
               sprite.flipX = true;
          }
          else
          {
               sprite.flipX = false;
          }

          if (transform.position == pointA.position)
          {
               currentTarget = pointB.position;
               anim.SetTrigger("Idle");
          }
          else if (transform.position == pointB.position)
          {
               currentTarget = pointA.position;
               anim.SetTrigger("Idle");
          }
          if(isHit == false)
          {
               transform.position = Vector3.MoveTowards(transform.position, currentTarget, speed * Time.deltaTime);
          }

          float distance = Vector3.Distance(transform.localPosition, player.transform.localPosition);
          if(distance > 2.0f)
          {
               isHit = false;
               anim.SetBool("InCombat", false);
          }

          Vector3 direction = player.transform.localPosition - transform.localPosition;
          if (anim.GetBool("InCombat") == true)
          {
               if (direction.x > 0)
               {
                    sprite.flipX = false;
               }
               else if (direction.x < 0)
               {
                    sprite.flipX = true;
               }
          }

     }




}
