using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D _body;
    [SerializeField] private float _speed = 1;
    [SerializeField] private float _jumpForce = 3;
    [SerializeField] private bool _isGrounded;
    [SerializeField] private Animator _anim;
    [SerializeField] private SpriteRenderer _renderer;
    private bool _hasJumped;
    
    // Start is called before the first frame update
    void Start()
    {
        _body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Attack();
    }

    private void Attack()
    {
        if (Input.GetMouseButtonDown(0) &&IsGrounded())
        {
            _anim.SetTrigger("Attack");
        }
        
    }


    private void Movement()
    {
        {
            if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
            {
                _body.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
                _anim.SetTrigger("Jump");
            }          
        }
        float translation = Input.GetAxisRaw("Horizontal") * _speed;

        if (translation > 0)
        {
            _renderer.flipX = false; 
        }
        else if (translation < 0)
        {
            _renderer.flipX = true;
        }

        _body.velocity = new Vector2(translation, _body.velocity.y);

        if (Mathf.Abs(translation)>0)
        {
            _anim.SetFloat("Move",1);
        }
        else if (translation<=0)
        {
            _anim.SetFloat("Move", 0);
        }
       
    }

    private bool IsGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up, 0.7f);

        if (hit.collider != null)
        { 
            return true;
        }
        else
        {
            return false;
        }
    }
}
