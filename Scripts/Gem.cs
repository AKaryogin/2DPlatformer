using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : MonoBehaviour
{    
    [SerializeField] private int _cost;    

    public int Cost { get => _cost; }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.TryGetComponent<GemCounter>(out GemCounter gemCounter))
        {            
            Destroy(gameObject);
        }                
    }        
}
