using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : MonoBehaviour
{    
    [SerializeField] private int _cost;

    private GemPool _gemPool;

    private void OnEnable()
    {
        _gemPool = gameObject.GetComponentInParent<GemPool>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.TryGetComponent<GemCounter>(out GemCounter gemCounter))
        {
            gemCounter.SetGems(_cost);
            _gemPool?.CheckTakenAllGem();
            Destroy(gameObject);
        }                
    }        
}
