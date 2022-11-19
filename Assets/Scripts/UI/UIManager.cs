using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private static UIManager _instance;
    public static UIManager Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError("UIManager is null");
            }
            return _instance;
        }
}
    public Text playerGemCountText;
    public Image selectionImg;
    public Text gemCountText;
    [SerializeField] private Image[] _healthBar;

    private void Awake()
    {
        _instance = this;
    }

    public void OpenShop(int gemCount)
    {
        playerGemCountText.text = "" +gemCount + "G";
    }

    public void UpdateSelection(int yPos)
    {
        selectionImg.rectTransform.anchoredPosition = new Vector2(selectionImg.rectTransform.anchoredPosition.x, yPos);
    }

    public void UpdateGemCount(int count)
    {
        gemCountText.text = "" + count;
    }
   
    public void UpdateLives(int livesRemaining)
    {
        _healthBar[livesRemaining].gameObject.SetActive(false);
    }
}
