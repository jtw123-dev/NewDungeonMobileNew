using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using static UnityEditor.Experimental.GraphView.GraphView;

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
    [SerializeField] private Text _playerGemCountText;
    [SerializeField] private Image _selectionImg;
    [SerializeField] private Text _gemCountText;
    [SerializeField] private Image[] _healthBar;
    private Player _player;
    private void Awake()
    {
        _instance = this;
    }
    public void GemCountText()
    {
        _playerGemCountText.text = _player.diamonds.ToString(); 
    }
    public void OpenShop(int gemCount)
    {
        _playerGemCountText.text = "" +gemCount + "G";
    }

    public void UpdateSelection(int yPos)
    {
        _selectionImg.rectTransform.anchoredPosition = new Vector2(_selectionImg.rectTransform.anchoredPosition.x, yPos);
    }

    public void UpdateGemCount(int count)
    {
        _gemCountText.text = "" + count;
    }
   
    public void UpdateLives(int livesRemaining)
    {
        _healthBar[livesRemaining].gameObject.SetActive(false);
    }
}
