using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelActivator : MonoBehaviour
{
    [SerializeField] private GameObject _panel;

    public void PanelEnable()
    {
        _panel.SetActive(true);
    }

    public void PanelDisable()
    {
        _panel.SetActive(false);
    }
}
