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

    private List<GameObject> pages = new List<GameObject>();
    private int activePageIndex = 0;

    void Start()
    {
        int i = 0;
        foreach(Transform child in transform)
        {
            pages.Add(child.gameObject);
            if(i != 0)
            {
                child.gameObject.SetActive(false);
            }
            i++;
        }
    }

    public void IncrementPage(int incrementAmount)
    {
        int previousPageIndex = activePageIndex;
        activePageIndex += incrementAmount;
        activePageIndex = Mathf.Clamp(activePageIndex, 0, pages.Count() - 1);
        if(activePageIndex != previousPageIndex)
        {
            for(int i = 0; i < pages.Count(); i++)
            {
                if(i == activePageIndex)
                {
                    pages.ElementAt(i).SetActive(true);
                }
                else
                {
                    pages.ElementAt(i).SetActive(false);
                }
            }
            pageIndicatorTMP.text = "PAGE " + (activePageIndex + 1);
        }
    }
}
