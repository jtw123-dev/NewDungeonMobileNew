using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopKeeperScript : MonoBehaviour
{
    [SerializeField] private GameObject _shopPanel;
    private int _currentItemSelected;
    private int _itemCost;
    private Player _player;

    private void Start()
    {
        _player = GameObject.Find("Player").GetComponent<Player>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Player player = other.GetComponent<Player>();
        if (player != null)
        {
            UIManager.Instance.OpenShop(player.diamonds);
        }

        if (other.tag == "Player")
        {
            _shopPanel.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            _shopPanel.SetActive(false);
        }
    }
    public void SelectItem(int selectItem)
    {
        switch (selectItem)
        {
        case 0:
                UIManager.Instance.UpdateSelection(79);
                _currentItemSelected = 0;
                _itemCost = 200;
                    break;  
                case 1:
                UIManager.Instance.UpdateSelection(-21);
                _currentItemSelected = 1;
                _itemCost = 400;
                break;
            case 2:
                UIManager.Instance.UpdateSelection(-112);
                _currentItemSelected = 2;
                _itemCost = 100;
                break;
        }
    }

    public void BuyItem()
    {
        if (_player.diamonds<_itemCost)

        {
            _shopPanel.gameObject.SetActive(false);

        }
        else
        {

            if (_currentItemSelected == 2)
            {
                GameManager.Instance.HasKeyToCastle = true; 
            }

            Debug.Log("You have enough money");
            _player.diamonds -= _itemCost;
            UIManager.Instance.playerGemCountText.text = _player.diamonds.ToString();
        }
    }
}
