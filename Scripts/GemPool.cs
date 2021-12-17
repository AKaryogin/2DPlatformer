using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemPool : MonoBehaviour
{
    private Gem[] _gems;   

    public void Kill()
    {
        if(CheckTakenAllGem())
            Destroy(gameObject, 1);
    }

    private bool CheckTakenAllGem()
    {
        _gems = gameObject.GetComponentsInChildren<Gem>();

        return (_gems.Length == 1) ? true : false;
    }
}
