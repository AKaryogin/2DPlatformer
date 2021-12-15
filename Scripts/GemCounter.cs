using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GemCounter : MonoBehaviour
{
    [SerializeField] private TMP_Text _textScore;

    private int _count = 0;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.TryGetComponent<Gem>(out Gem gem))
        {
            _count += gem.Cost;

            _textScore.text = "x " + _count;
        }
    }
}
