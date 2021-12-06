using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class CollisionEnemy : MonoBehaviour
{
    [SerializeField] private float timeStun;
    [SerializeField] private Animator _animator;
    [SerializeField] private MovementPlayer _movementPlayer;
    [SerializeField] private GroundChecker _groundChecker;

    private Rigidbody2D _rb2d;

    private const string Damage = "Damage";
    private const string Grounded = "Grounded";

    private void Start()
    {
        _rb2d = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)    
    {
        if(_groundChecker.Grounded && transform.position.x < collision.transform.position.x)
        {
            if(collision.collider.TryGetComponent<MovementEnemy>(out MovementEnemy movementEnemy))
            {
                _movementPlayer.enabled = false;
                _animator.SetTrigger(Damage);
                               
                _rb2d.AddForce(Vector2.left * 5, ForceMode2D.Impulse);
                _rb2d.AddForce(Vector2.up * 150);

                StartCoroutine(TimerStun(timeStun));
            }
        }

        if(_groundChecker.Grounded && transform.position.x > collision.transform.position.x)
        {
            if(collision.collider.TryGetComponent<MovementEnemy>(out MovementEnemy movementEnemy))
            {
                _movementPlayer.enabled = false;
                _animator.SetTrigger(Damage);
                               
                _rb2d.AddForce(Vector2.right * 5, ForceMode2D.Impulse);
                _rb2d.AddForce(Vector2.up * 150);

                StartCoroutine(TimerStun(timeStun));
            }
        }

        if(_groundChecker.Grounded == false && transform.position.y > collision.transform.position.y)
        {
            if(collision.collider.TryGetComponent<DestroyEnemy>(out DestroyEnemy destroyEnemy))
            {     
                _rb2d.AddForce(Vector2.up * 300);
                destroyEnemy.DeadEnemy();
            }
        }
    }

    private IEnumerator TimerStun(float time)
    {
        for(int i = 0; i < time; i++)
        {
            yield return null;
        }

        _movementPlayer.enabled = true;
    }
}
