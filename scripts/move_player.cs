using System;
using UnityEngine;

public class movePlayer : MonoBehaviour
{


    [SerializeField] private float jumpHeight;
    [SerializeField] private float moveSpeed = 10f;
    private float _moveDir;

    private bool _jumpPressed;
    private float _jumpYVel;
    private Rigidbody2D _rigidbody2D;
    private Vector3 _moveVel;
    private bool IsGrounded;



    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
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
            _moveVel = _rigidbody2D.linearVelocity;
            _moveVel.x = _moveDir * moveSpeed * Time.fixedDeltaTime * 2;
            _rigidbody2D.linearVelocity = _moveVel;
        }
        else
        {
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
        _moveDir = Input.GetAxisRaw("Horizontal"); // takes move input
        _jumpPressed |= Input.GetKeyDown(KeyCode.Space); // takes input for jump using space
    }


    private void OnCollisionEnter2D(Collision2D col)
    {
        IsGrounded = true;
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        IsGrounded = false;
    }
}
    