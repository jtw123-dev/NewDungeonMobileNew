using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdsManager : MonoBehaviour,IUnityAdsListener
{
    private string gameID = "5028117";
    private string myPlacementID = "Rewarded_Android";
    private bool testMode = true;
    private Player _player;

    private void Start()
    {
        _player = GameObject.Find("Player").GetComponent<Player>();
        Advertisement.AddListener(this);
        Advertisement.Initialize(gameID, testMode);
    }

    public void ShowAd()
    {
        Advertisement.Show("Rewarded_Android");
        _player.AddGems(100);
        UIManager.Instance.OpenShop(_player.diamonds);
       // UIManager.Instance.UpdateGemCount(100);
      //  UIManager.Instance.playerGemCountText.text += 100.ToString();
    }

    public void ShowRewardedAd()
    {
        if (Advertisement.IsReady("Rewarded_Android"))
        {
            var options = new ShowOptions
            {
                resultCallback = HandleShowResult
            };
            Advertisement.Show("Rewarded_Android", options);
        }

        Debug.Log("Showing Rewarded ad");

    }
    void HandleShowResult(ShowResult result)
    {
        switch (result)
        {
            case ShowResult.Finished:
                break;
            case ShowResult.Skipped:
                Debug.Log("You skipped the ad no gems for you");

                break;
            case ShowResult.Failed:
                Debug.Log("The video failed it must not have been ready");
                break;
        }

    }

    public void OnUnityAdsReady(string placementId)
    {
       
    }

    public void OnUnityAdsDidError(string message)
    {
       
    }

    public void OnUnityAdsDidStart(string placementId)
    {
       
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        
    }
}
