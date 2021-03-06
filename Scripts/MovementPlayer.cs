using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MovementPlayer : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private GroundChecker _groundChecker;
    [SerializeField] private Animator _animator;

    private const string Horizontal = "Horizontal";
    private const string Speed = "Speed";
    private const string Grounded = "Grounded";

    private Rigidbody2D _rigidbody;
    private bool _movesToRight = true;    

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Jump();
    }

    private void FixedUpdate()
    {
        float directionX = Input.GetAxis(Horizontal) * _speed;

        _rigidbody.velocity = new Vector2(directionX, _rigidbody.velocity.y);

        _animator.SetFloat(Speed, Mathf.Abs(directionX));        

        if(directionX > 0 && _movesToRight == false)
        {
            transform.Rotate(0f, 180f, 0f);
            _movesToRight = true;
        }

        if(directionX < 0 && _movesToRight)
        {
            transform.Rotate(0f, 180f, 0f);
            _movesToRight = false;
        }
        
    }

    private void Jump()
    {
        if(Input.GetKeyDown(KeyCode.Space) && _groundChecker.Grounded)
        {
            _rigidbody.AddForce(Vector2.up * _jumpForce);            
        }

        _animator.SetBool(Grounded, _groundChecker.Grounded);
    }
}
