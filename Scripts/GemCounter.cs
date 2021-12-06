using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GemCounter : MonoBehaviour
{
    [SerializeField] private TMP_Text _textScore;

    private int _count = 0;

    public void SetGems(int count)
    {
        _count += count;

        _textScore.text = "x " + _count;
    }
}
