using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundChecker : MonoBehaviour
{  
    public bool Grounded { get; private set; }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<Ground>(out Ground ground))
        {
            Grounded = true;            
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.TryGetComponent<Ground>(out Ground ground))
        {
            Grounded = false;            
        }
    }
}
