using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdsManager : MonoBehaviour,IUnityAdsListener
{
    private string _gameID = "5028117";
    private bool _testMode = true;
    private Player _player;

    private void Start()
    {
        _player = GameObject.Find("Player").GetComponent<Player>();
        Advertisement.AddListener(this);
        Advertisement.Initialize(_gameID, _testMode);
    }

    public void ShowAd()
    {
        Advertisement.Show("Rewarded_Android");
        _player.AddGems(100);
        UIManager.Instance.OpenShop(_player.diamonds);
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
