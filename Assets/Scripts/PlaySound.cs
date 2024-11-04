using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour
{
    [SerializeField]
    private AudioClip sound;
    [SerializeField]
    private Sprite pressedSprite;

    private Sprite defaultSprite;
    private SpriteRenderer spriteRenderer;

    private AudioSource audioSource;

    private bool isPressed = false;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();
        defaultSprite = spriteRenderer.sprite;
    }

    private void OnMouseDown()
    {
        print("Hit The Button");

        if(!isPressed)
        {
            isPressed = true;
            spriteRenderer.sprite = pressedSprite;

            if(sound != null)
            {
                audioSource.PlayOneShot(sound);
            }
            else
            {
                Debug.LogWarning("Attempted to press a sound effect button with no sound assigned");
            }
        }
        else
        {
            isPressed = false;
            audioSource.Stop();
            spriteRenderer.sprite = defaultSprite;
        }
    }

    private void Update()
    {
        if(audioSource.isPlaying == false)
        {
            isPressed = false;
            spriteRenderer.sprite = defaultSprite;
        }
    }
}
