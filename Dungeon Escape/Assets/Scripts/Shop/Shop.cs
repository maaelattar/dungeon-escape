using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
     public GameObject shopPanel;
     public int currentSelectedItem;
     public int currentItemCost;
     Player player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     private void OnTriggerEnter2D(Collider2D other)
     {
          if(other.tag == "Player")
          {
                player = other.GetComponent<Player>();
               if(player != null)
               {
                    UIManager.Instance.OpenShop(player.diamonds);
               }
               shopPanel.SetActive(true);
          }
     }

     private void OnTriggerExit2D(Collider2D other)
     {
          if (other.tag == "Player")
          {
               shopPanel.SetActive(false);
          }
     }
   

     public void SelectItem(int item)
     {
          switch (item)
          {
               case 0:
                    UIManager.Instance.UpdateShopSelection(72);
                    currentSelectedItem = 0;
                    currentItemCost = 200;
                    break;
               case 1:
                    UIManager.Instance.UpdateShopSelection(-21);
                    currentSelectedItem = 1;
                    currentItemCost = 400;
                    break;
               case 2:
                    UIManager.Instance.UpdateShopSelection(-114);
                    currentSelectedItem = 2;
                    currentItemCost = 100;
                    break;
          }
     }

     public void BuyItem()
     {
          if (currentSelectedItem == 2)
          {
               GameManager.Instance.HasKeyToCastle = true;
          }

          if (player.diamonds >= currentItemCost) 
          {
               player.diamonds -= currentItemCost;
               shopPanel.SetActive(false);
          }
          else
          {
               shopPanel.SetActive(false);
          }
     }
}
