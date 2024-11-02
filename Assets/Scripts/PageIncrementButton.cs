
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events; // Necessary for UnityEvent

public class PageIncrementButton : MonoBehaviour
{
    [SerializeField]
    private UnityEvent onPressed = new UnityEvent();

    private void OnMouseDown()
    {
        onPressed.Invoke();
    }
}
