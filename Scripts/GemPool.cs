using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemPool : MonoBehaviour
{
    private Gem[] _gems;   

    public void CheckTakenAllGem()
    {
        _gems = gameObject.GetComponentsInChildren<Gem>();        

        if(_gems.Length == 1)
            Destroy(gameObject, 1f);
    }
}
