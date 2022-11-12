using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Skeleton : Enemy,IDamagable
{
    public int Health { get; set; }

    private void Start()
    {
        Health = health;
    }

    public override void Update()
    {
        base.Update();
        Vector3 direction = player.transform.localPosition - transform.localPosition;
        if (direction.x > 0 && animator.GetBool("InCombat") == true)
        {
            enemySprite.flipX = false;
        }
        else if (direction.x < 0 && animator.GetBool("InCombat") == true)
        {
            enemySprite.flipX = true;
        }
    }

    public void Damage()
    {
      


        animator.SetTrigger("Hit");
        isHit = true;
        health--;
        animator.SetBool("InCombat", true);

       

        if (health < 1)
        {
            Destroy(gameObject);
        }
    }
}
