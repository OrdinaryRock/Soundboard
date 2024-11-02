using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class ButtonPagesManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI pageIndicatorTMP;
    [SerializeField]
    private float pageSpacing = 6f;

    private List<GameObject> pages = new List<GameObject>();
    private int activePageIndex = 0;

    [SerializeField]
    private float swipeSpeed = 10f;
    private Vector3 swipeStartPosition = Vector3.zero;
    private Vector3 swipeTargetPosition = Vector3.zero;
    private float swipeTimeElapsed = 0f;

    void Start()
    {
        int i = 0;
        foreach(Transform child in transform)
        {
            pages.Add(child.gameObject);
            child.position = new Vector3(i * pageSpacing, 0, 0);
            i++;
        }
    }

    public void IncrementPage(int incrementAmount)
    {
        int previousPageIndex = activePageIndex;
        activePageIndex += incrementAmount;
        activePageIndex = Mathf.Clamp(activePageIndex, 0, pages.Count() - 1);
        pageIndicatorTMP.text = "PAGE " + (activePageIndex + 1);

        if(activePageIndex != previousPageIndex) SwipeInDirection(incrementAmount);
    }

    private void SwipeInDirection(int direction)
    {
        swipeTimeElapsed = 0;
        swipeStartPosition = transform.position;
        swipeTargetPosition = new Vector3(activePageIndex * pageSpacing * -1, 0, 0);
    }

    private void Update()
    {
        swipeTimeElapsed += Time.deltaTime * swipeSpeed;
        transform.position = Vector3.Slerp(swipeStartPosition, swipeTargetPosition, swipeTimeElapsed);
    }
}
