using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MovementEnemy : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform _targetPoint;

    private Sequence _sequence;

    private void Start()
    {
        _sequence = DOTween.Sequence();

        _sequence.Append(transform.DOMove(_targetPoint.position, _speed).SetEase(Ease.Linear));
        _sequence.Append(transform.DORotate(new Vector3(0, 180, 0), 0.01f));
        _sequence.Append(transform.DOMove(transform.position, _speed).SetEase(Ease.Linear));

        _sequence.SetLoops(-1);        
        
    }

    public void Stopping()
    {
        _sequence.Kill();
    } 
}
