using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class CollisionEnemy : MonoBehaviour
{
    [SerializeField] private float _pushForceSide;
    [SerializeField] private float _pushForceUp;
    [SerializeField] private float _timeStun;
    [SerializeField] private Animator _animator;
    [SerializeField] private MovementPlayer _movementPlayer;
    [SerializeField] private GroundChecker _groundChecker;

    private Rigidbody2D _rigidbody;

    private const string Damage = "Damage";

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)    
    {
        PushLeft(collision);
        PushRight(collision);
        PushUp(collision);
    }

    private void PushLeft(Collision2D collision)
    {
        if(_groundChecker.Grounded && transform.position.x < collision.transform.position.x)
        {
            if(collision.collider.TryGetComponent<MovementEnemy>(out MovementEnemy movementEnemy))
            {
                _movementPlayer.enabled = false;
                _animator.SetTrigger(Damage);

                _rigidbody.AddForce(Vector2.left * _pushForceSide, ForceMode2D.Impulse);
                _rigidbody.AddForce(Vector2.up * (_pushForceUp / 2));

                Stun(_timeStun);
            }
        }
    }

    private void PushRight(Collision2D collision)
    {
        if(_groundChecker.Grounded && transform.position.x > collision.transform.position.x)
        {
            if(collision.collider.TryGetComponent<MovementEnemy>(out MovementEnemy movementEnemy))
            {
                _movementPlayer.enabled = false;
                _animator.SetTrigger(Damage);

                _rigidbody.AddForce(Vector2.right * _pushForceSide, ForceMode2D.Impulse);
                _rigidbody.AddForce(Vector2.up * (_pushForceUp / 2));

                Stun(_timeStun);
            }
        }
    }

    private void PushUp(Collision2D collision)
    {
        if(_groundChecker.Grounded == false && transform.position.y > collision.transform.position.y)
        {
            if(collision.collider.TryGetComponent<DestroyerEnemy>(out DestroyerEnemy destroyEnemy))
            {
                _rigidbody.AddForce(Vector2.up * _pushForceUp);
                destroyEnemy.Kill();
            }
        }
    }

    private void Stun(float time)
    {
        StartCoroutine(TimerStun(time));
    }

    private IEnumerator TimerStun(float time)
    {        
        WaitForSeconds waitForSeconds = new WaitForSeconds(time);

        yield return waitForSeconds;

        _movementPlayer.enabled = true;        
    }
}
