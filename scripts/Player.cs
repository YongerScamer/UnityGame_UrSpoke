using System;
using UnityEngine;

public class Player : MonoBehaviour
{


    [SerializeField] private float jumpHeight;
    [SerializeField] private float moveSpeed = 10f;
    private float _moveDir;

    private bool _jumpPressed;
    private float _jumpYVel;
    private Rigidbody2D _rigidbody2D;
    private Animator animator;
    private Vector3 _moveVel;
    private bool IsGrounded;
    public int max_health = 100;
    public int health = 100;




    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        GetInput();
    }

    private void FixedUpdate()
    {
        Move();
        HandleJump();
    }

    private void HandleJump()
    {
        if (IsGrounded && _jumpPressed)
        {
            _jumpYVel = CalculateJumpVel(jumpHeight);
            _jumpPressed = false;

            _moveVel = _rigidbody2D.linearVelocity;
            _moveVel.y = _jumpYVel;
            _rigidbody2D.linearVelocity = _moveVel;
        }

    }

    private void Move()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            animator.SetBool("run", true);
            _moveVel = _rigidbody2D.linearVelocity;
            _moveVel.x = _moveDir * moveSpeed * Time.fixedDeltaTime * 2;
            _rigidbody2D.linearVelocity = _moveVel;
        }
        else
        {
            animator.SetBool("run", false);
            _moveVel = _rigidbody2D.linearVelocity;
            _moveVel.x = _moveDir * moveSpeed * Time.fixedDeltaTime;
            _rigidbody2D.linearVelocity = _moveVel;
        }
    }


    private float CalculateJumpVel(float height)
    {
        return MathF.Sqrt((-2 * _rigidbody2D.gravityScale * Physics2D.gravity.y * height));
    }

    void GetInput()
    {
        _moveDir = Input.GetAxisRaw("Horizontal");
        animator.SetFloat("speed", Mathf.Abs(_moveDir));
        _jumpPressed |= Input.GetKeyDown(KeyCode.Space); 
    }


    private void OnCollisionEnter2D(Collision2D col)
    {
        IsGrounded = true;
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        IsGrounded = false;
    }

    public void Damage(int damage)
    {
        health -= damage;
        Debug.Log(damage);
        if (health <= 0)
        {
            Debug.Log("Ћох умер");
        }
    }
}
    