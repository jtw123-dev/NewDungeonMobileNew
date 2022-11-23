using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField]protected int health;
    [SerializeField]protected int speed;
    [SerializeField]protected int gemValue;
    [SerializeField]protected Transform pointA,pointB;
    [SerializeField]protected SpriteRenderer enemySprite;
    [SerializeField]protected bool canSwitch;
    [SerializeField]protected Animator animator;
    [SerializeField]protected Vector3 currentTarget;
    [SerializeField]protected Transform player;
    [SerializeField]protected GameObject diamondPrefab;
    protected Diamonds diamond;
    protected bool isDead = false;
    protected float distance; 
    protected bool isHit = false;

    public virtual void Update()
    {
        distance = Vector3.Distance(transform.position, player.transform.position);

        if (distance > 2)
        {
            isHit = false;
            animator.SetBool("InCombat", false);
        }

        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            return;
        }

        if (isDead==false)
        {
            EnemyMovement();
        }      
    }
    
    public virtual void EnemyMovement()
    {
        Vector3 direction = player.transform.localPosition - transform.localPosition;
        if (direction.x > 0 && animator.GetBool("InCombat") == true)
        {
            enemySprite.flipX = false;
        }
        else if (direction.x < 0 && animator.GetBool("InCombat") == true)
        {
            enemySprite.flipX = true;
        }

        if (transform.position == pointA.position)
        {
            currentTarget = pointB.position;
            animator.Play("Idle");
            enemySprite.flipX = false;
        }
        else if (transform.position == pointB.position)
        {
            currentTarget = pointA.position;
            animator.Play("Idle");
            enemySprite.flipX = true;
        }
        if (isHit==false)
        {
            transform.position = Vector2.MoveTowards(transform.position, currentTarget, speed * Time.deltaTime);
        }   
    }
}
