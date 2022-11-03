using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D _body;
    [SerializeField] private float _speed = 1;
    [SerializeField] private float _jumpForce = 3;
    [SerializeField] private bool _isGrounded;
    
    // Start is called before the first frame update
    void Start()
    {
        _body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    private void Movement()
    {
        {
            if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
            {
                _body.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
            }
        }
        float translation = Input.GetAxisRaw("Horizontal") *_speed;
        _body.velocity = new Vector2(translation, _body.velocity.y);
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
