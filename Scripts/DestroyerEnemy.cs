using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyerEnemy : MonoBehaviour
{
    [SerializeField] private MovementEnemy _movementEnemy;
    [SerializeField] private Animator _animator;
    [SerializeField] private GemPoolSpawner _gemPoolSpawner;

    private const string Dead = "Dead";

    public void Kill()
    {        
        _movementEnemy.Stopping();
        _animator.SetTrigger(Dead);
        _gemPoolSpawner.Create(transform.position);
        Destroy(transform.parent.gameObject, 1f);
    }
}
