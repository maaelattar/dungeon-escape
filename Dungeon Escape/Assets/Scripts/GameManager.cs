using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
     private static GameManager instance;
     public static GameManager Instance
     {
          get
          {
               if (instance == null)
               {
                    Debug.Log("uimanager instance is null");
               }
               return instance;
          }
     }
     public bool HasKeyToCastle { get; set; }

     public Player player { get; private set; }

     private void Awake()
     {
          instance = this;
          player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
     }
}
