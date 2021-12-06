using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemSpawner : MonoBehaviour
{
    [SerializeField] private GemPool _gemPool;

    public void Create(Vector3 position)
    {
        Instantiate(_gemPool, position, Quaternion.identity);
    }
}
