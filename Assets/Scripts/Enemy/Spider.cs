using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : Enemy,IDamagable
{
    [SerializeField]private GameObject _acidAttack;
    public int Health { get; set; }

    public void Damage()
    {

        if (isDead == true)
        {
            return;
        }
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
       return;
    }

    public void TellEventToFire()
    {
        var acidClone = Instantiate(_acidAttack, transform.position, Quaternion.identity);
        Instantiate(acidClone, transform.position, Quaternion.identity);
    }
}
