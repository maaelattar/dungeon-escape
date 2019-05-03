using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour, IDamagable
{
     public int diamonds;

     PlayerAnimation playerAnim;
     Rigidbody2D rigid;
     SpriteRenderer playerSprite;
     SpriteRenderer swordArcSprite;
     private float jumpForce = 8.0f;
     [SerializeField]
     private float speed = 3.0f;
     [SerializeField]
     private bool resetJump;
     private bool grounded = false;
     public int Health { get; set; }

     
     // Start is called before the first frame update
     void Start()
    {
          rigid = GetComponent<Rigidbody2D>();
          playerAnim = GetComponent<PlayerAnimation>();
          playerSprite = GetComponentInChildren<SpriteRenderer>();
          swordArcSprite = transform.GetChild(1).GetComponent<SpriteRenderer>();

          Health = 4;
    }

    // Update is called once per frame
    void Update()
    {
          Movement();

          
          Debug.DrawRay(transform.position, Vector2.down * 0.7f, Color.green);
          /*
          if(Input.GetMouseButtonDown(0) && IsGrounded() == true)
          {
               playerAnim.Attack();
          }
          */
          if(CrossPlatformInputManager.GetButtonDown("A_Button") && IsGrounded() == true)
          {
               playerAnim.Attack();
          }

          
     }

     void Movement()
     {

          //float move = Input.GetAxisRaw("Horizontal");
          float move = CrossPlatformInputManager.GetAxis("Horizontal");
          grounded = IsGrounded();
          if (move > 0)
          {
               Flip(true);
               
          }
          else if (move < 0)
          {
               Flip(false);
          }

/*
          if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
          {
               rigid.velocity = new Vector2(rigid.velocity.x, jumpForce);
               StartCoroutine(ResetJumpRoutine());
               playerAnim.Jump(true);
          }

          */
          if (CrossPlatformInputManager.GetButtonDown("B_Button") && IsGrounded())
          {
               rigid.velocity = new Vector2(rigid.velocity.x, jumpForce);
               StartCoroutine(ResetJumpRoutine());
               playerAnim.Jump(true);
          }
          rigid.velocity = new Vector2(move * speed, rigid.velocity.y);
          playerAnim.Move(move);
     }

     bool IsGrounded()
     {
          RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.down, 0.7f, 1 << 8);
          if (hitInfo.collider != null)
          {
               if(resetJump == false)
               {
                    playerAnim.Jump(false);
                    return true;
               }
               

          }
          return false;
     }

     void Flip(bool faceRight)
     {
          if (faceRight == true)
          {
               playerSprite.flipX = false;
               swordArcSprite.flipX = false;
               swordArcSprite.flipY = false;

               Vector3 newPos = swordArcSprite.transform.localPosition;
               newPos.x = 1.01f;
               swordArcSprite.transform.localPosition = newPos; 
          }
          else if (faceRight == false)
          {
               playerSprite.flipX = true;
               swordArcSprite.flipX = true;
               swordArcSprite.flipY = true;

               Vector3 newPos = swordArcSprite.transform.localPosition;
               newPos.x = -1.01f;
               swordArcSprite.transform.localPosition = newPos; 
          }
     }
     IEnumerator ResetJumpRoutine()
     {
          resetJump = true;
          yield return new WaitForSeconds(0.1f);
          resetJump = false;
     }

   public void AddGems(int amount)
     {
          diamonds += amount;
          UIManager.Instance.UpdateGemCount(diamonds);
     }

     public void Damage()
     {
          if (Health < 1)
          {
               return;
          }
          Health--;
          UIManager.Instance.UpdateLives(Health);
          if(Health < 1)
          {
               playerAnim.Death();
          }
     }

}
