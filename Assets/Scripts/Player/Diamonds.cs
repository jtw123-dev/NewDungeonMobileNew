using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamonds : MonoBehaviour
{
    public int gems = 1;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag=="Player")
        {
            Player player = other.GetComponent<Player>();
            player.AddGems(gems);
            Destroy(gameObject);
        }
    }
}
