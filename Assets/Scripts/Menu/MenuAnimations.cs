using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuAnimations : MonoBehaviour
{
    [SerializeField] private List<RectTransform> uiElements;
    [SerializeField] private List<Vector2> originalScales;
    [SerializeField] private float enterDuration = 1f;
    [SerializeField] private float exitDuration = 1f;
    [SerializeField] private float enableTime = 1f;
    [SerializeField] private float disableTime = 1f;
    [SerializeField] private float delay = 0.1f;

    private void Awake()
    {
        int childCount = gameObject.transform.childCount;
        for(int i=0; i<childCount; i++)
        {
            uiElements.Add(gameObject.transform.GetChild(i).GetComponent<RectTransform>());
            originalScales.Add(uiElements[i].localScale);
        }

        if(uiElements != null)
        {
            foreach (RectTransform element in uiElements)
            {
                LeanTween.scale(element, Vector3.zero , 0f);
            }
        }
        
    }

    private void OnEnable()
    {
        Invoke("EnableDelayed", enableTime);
    }

    public void EnablingAnimation()
    {
        float additiveDelay = delay;
        for (int i = 0; i < uiElements.Count; i++)
        {
            LeanTween.scale(uiElements[i], originalScales[i], enterDuration).setEase(LeanTweenType.easeOutElastic).setDelay(additiveDelay);
            additiveDelay += delay;
        }
    }

    public void DisablingAnimation()
    {
        float additiveDelay = delay;
        for (int i = 0; i < uiElements.Count; i++)
        {
            LeanTween.scale(uiElements[i], Vector3.zero, exitDuration).setEase(LeanTweenType.easeOutSine).setDelay(additiveDelay);
            additiveDelay += delay;
        }

        Invoke("DisableDelayed", disableTime);
    }

    private void EnableDelayed()
    {
        EnablingAnimation();
    }

    private void DisableDelayed()
    {
        gameObject.SetActive(false);
    }
}
