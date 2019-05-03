using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdsManager : MonoBehaviour
{
   public void ShowRewardedAd()
     {
          if (Advertisement.IsReady("rewardedVideo"))
          {
               var options = new ShowOptions
               {
                    resultCallback = HandleShowResult
               };

               Advertisement.Show("rewardedVideo", options);
          }
     }

     public void HandleShowResult(ShowResult result)
     {
          switch (result)
          {
               case ShowResult.Finished:
                    GameManager.Instance.player.AddGems(100);
                    UIManager.Instance.OpenShop(GameManager.Instance.player.diamonds);
                    Debug.Log("Congratulations you earned 100 gems");
                    break;
               case ShowResult.Skipped:
                    Debug.Log("Ad has been skipped");
                    break;
               case ShowResult.Failed:
                    Debug.Log("Failed to show ad");
                    break;
          }
     }
}
