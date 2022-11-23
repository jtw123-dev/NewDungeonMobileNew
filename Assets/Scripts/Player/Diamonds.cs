using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamonds : MonoBehaviour
{
    private int _gems = 1;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag=="Player")
        {
            Player player = other.GetComponent<Player>();
            player.AddGems(_gems);
            Destroy(gameObject);
        }
    }

    public void GemCount(int count)
    {
        _gems = count;
    }
}
