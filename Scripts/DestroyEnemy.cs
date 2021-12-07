using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEnemy : MonoBehaviour
{
    [SerializeField] private MovementEnemy _movementEnemy;
    [SerializeField] private Animator _animator;
    [SerializeField] private GemSpawner _gemSpawner;

    private const string Dead = "Dead";

    public void Die()
    {        
        _movementEnemy.KillSequence();
        _animator.SetTrigger(Dead);
        _gemSpawner.Create(transform.position);
        Destroy(transform.parent.gameObject, 1f);
    }
}
