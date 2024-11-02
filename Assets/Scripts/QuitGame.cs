using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitGame : MonoBehaviour
{
    private void OnMouseDown()
    {
        print("Quit Game");
        Application.Quit();
    }
}
