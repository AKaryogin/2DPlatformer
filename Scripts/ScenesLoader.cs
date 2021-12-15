using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IJunior.TypedScenes;

public class ScenesLoader : MonoBehaviour
{
    public void LoadMainMenu()
    {
        MainMenu.Load();
    }

    public void LoadLevelOne()
    {
        Level1.Load();
    }
}
