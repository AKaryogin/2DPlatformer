using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEnemy : MonoBehaviour
{
    [SerializeField] private MovementEnemy _movementEnemy;
    [SerializeField] private Animator _animator;
    [SerializeField] private GemSpawner _gemSpawner;

    private const string Dead = "Dead";

    public void DeadEnemy()
    {        
        _movementEnemy.KillSequence();
        _animator.SetTrigger(Dead);
        _gemSpawner.Create(transform.position);
        Destroy(GetComponentInParent<Enemy>().gameObject, 1f);
    }
}
