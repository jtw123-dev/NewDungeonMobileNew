using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField]protected int health;
    [SerializeField]protected int speed;
    [SerializeField]protected int gems;
    [SerializeField]protected Transform pointA,pointB;
    [SerializeField]protected SpriteRenderer enemySprite;
    [SerializeField]protected bool canSwitch;
    [SerializeField]protected Animator animator;
    [SerializeField]protected Vector3 currentTarget;
    [SerializeField]protected Transform player;
    protected float distance; 
    protected bool isHit = false;

    //public init use to initialize components don't need because used serialized field to grab components


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

        EnemyMovement();   
    }
    
    
    public virtual void EnemyMovement()
    {
       
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
