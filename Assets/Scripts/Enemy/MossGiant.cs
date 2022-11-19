using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MossGiant : Enemy,IDamagable
{
   public int Health { get; set; }

    public void Damage()
    {

        if(isDead==true)
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
            diamondCopy.GetComponent<Diamonds>().gems = base.gemValue;
        }
    }

    public override void Update()
    {
        base.Update();
       
    }

    /* private void Movement()
     {//this works but is wordy
         if (this.gameObject.transform.position == pointA.transform.position)
         {
             canSwitch = true;
         }
         else if (this.gameObject.transform.position == pointB.transform.position)
         {
             canSwitch = false;
         }

         if (canSwitch == true)
         {
             transform.position = Vector2.MoveTowards(transform.position, pointB.transform.position, speed * Time.deltaTime);
             enemySprite.flipX = false;
         }
         else if (canSwitch == false)
         {
             transform.position = Vector2.MoveTowards(transform.position, pointA.transform.position, speed * Time.deltaTime);
             enemySprite.flipX = true;
         }
     }*/
}
