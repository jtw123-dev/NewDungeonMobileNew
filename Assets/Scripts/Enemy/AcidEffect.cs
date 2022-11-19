using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcidEffect : MonoBehaviour,IDamagable
{
    private float _speed = 3;
    [SerializeField] private GameObject _acidAttack;

    public int Health { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

    public void Damage()
    {
        Debug.Log("Hitting Player");
    }

    private void Update()
    {
        transform.Translate(Vector3.right * _speed * Time.deltaTime);
        Destroy(gameObject, 5);
    }
}
