using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour
{
    [SerializeField]
    private AudioClip sound;

    private void OnMouseDown()
    {
        print("Hit The Button");
        if(sound != null)
        {
            AudioSource.PlayClipAtPoint(sound, Camera.main.transform.position);
        }
        else
        {
            Debug.LogWarning("Attempted to press a sound effect button with no sound assigned");
        }
    }
}
