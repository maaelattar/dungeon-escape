using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private static UIManager instance;
    public static UIManager Instance {
          get
          {
               if(instance == null)
               {
                    Debug.Log("uimanager instance is null");
               } 
               return instance;
          }
     }

     public Text playerGemCountText;
     public Image selectionImg;
     public Text gemCountText;
     public Image[] healthBars;
     private void Awake()
     {
          instance = this;
     }

     public void OpenShop(int gemCount)
     {
          playerGemCountText.text = "" + gemCount + "G";
     }

     public void UpdateShopSelection(int yPos)
     {
          selectionImg.rectTransform.anchoredPosition = new Vector2(selectionImg.rectTransform.anchoredPosition.x, yPos);
     }
     
     public void UpdateGemCount(int count)
     {
          gemCountText.text = "" + count;
     }
     
     public void UpdateLives(int livesRemaining)
     {
          if(livesRemaining >=0 && livesRemaining <= 3)
          {
               healthBars[livesRemaining].enabled = false;
          }

     }

}
