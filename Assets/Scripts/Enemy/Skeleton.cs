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
    }

    public void Damage()
    {
        if (isDead == true)
        {
            return;
        }
        animator.SetTrigger("Hit");
        isHit = true;
        health--;
        animator.SetBool("InCombat", true);     

        if (health < 1)
        {
            isDead = true;
            animator.SetTrigger("Death");
            var diamondCopy = Instantiate(diamondPrefab, transform.position, Quaternion.identity);
            diamondCopy.GetComponent<Diamonds>().GemCount(base.gemValue);
        }
    }
}
