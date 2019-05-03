using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverCollider : MonoBehaviour
{
     [SerializeField]
     private GameObject gameOverPanel;

     private void OnTriggerEnter2D(Collider2D other)
     {
          if(other.tag == "Player")
          {
               Time.timeScale = 0;
               gameOverPanel.SetActive(true);
          }
     }
}
