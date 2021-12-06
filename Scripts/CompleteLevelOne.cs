using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompleteLevelOne : MonoBehaviour
{
    [SerializeField] private PanelActivator _panelActivator;
    [SerializeField] private Rigidbody2D _rb2d;
    [SerializeField] private Animator _animator;

    private const string Grounded = "Grounded";
    private const string Speed = "Speed";

    private void OnCollisionEnter2D(Collision2D collision)    
    {
        if(collision.collider.TryGetComponent<MovementPlayer>(out MovementPlayer movementPlayer))
        {
            Debug.Log("Level Complete");
            movementPlayer.enabled = false;
            _rb2d.velocity = Vector2.zero;
            _animator.SetBool(Grounded, true);
            _animator.SetFloat(Speed, 0f);
            _panelActivator.PanelEnable();
        }
    }
}
