using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelActivator : MonoBehaviour
{
    [SerializeField] private GameObject _panel;

    public void Enable()
    {
        _panel.SetActive(true);
    }

    public void Disable()
    {
        _panel.SetActive(false);
    }
}
