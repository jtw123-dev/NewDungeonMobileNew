using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    private bool _canDamage =true;
    private void OnTriggerEnter2D(Collider2D other)
    {
       IDamagable hit = other.GetComponent<IDamagable>();
        if (hit != null)
        {
            if (_canDamage==true)
            {
                hit.Damage();
                _canDamage = false;
                StartCoroutine("CanAttack");
            }        
        }
    }
    private IEnumerator CanAttack()
    {
        yield return new WaitForSeconds(0.5f);
        _canDamage = true;
    }
}
