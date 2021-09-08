using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Rendering;

public class WaveSuccessUI : MonoBehaviour
{
    
    public Material[] menuMaterials;
    public GameObject[] objectsToEnableOnEnable;
    public GameObject[] objectsToDisableOnDisable;

    public GameObject[] objectsToEnableOnDisable;
    public GameObject[] objectsToDisableOnEnable;
    public Volume v;

    // Update is called once per frame
    void Update()
    {
        
    }

    private float ppWeight = 0;

    private void OnDisable()
    {
        foreach (Material item in menuMaterials)
        {
            item.DOFloat(1, "_DissolveValue", 1f).SetEase(Ease.OutCubic).OnStart(daje);

        }
        DOTween.Sequence()
           .Append(DOTween.To(() => v.weight, x => v.weight = x, 0f, 0.7f));
    }


    private void OnEnable()
    {
        foreach (Material item in menuMaterials)
        {
            item.DOFloat(0, "_DissolveValue", 1f).SetEase(Ease.OutCubic).OnStart(daje2);
        }
        DOTween.Sequence()
           .Append(DOTween.To(() => v.weight, x => v.weight = x, 1f, 0.7f));
    }

    private void daje()
    {
        foreach (var item in objectsToDisableOnDisable)
        {
            item.SetActive(false);
        }

        foreach (var item in objectsToEnableOnDisable)
        {
            item.SetActive(true);
        }
    }

    private void daje2()
    {
        foreach (var item in objectsToEnableOnEnable)
        {
            item.SetActive(true);
        }

        foreach (var item in objectsToDisableOnEnable)
        {
            item.SetActive(false);
        }
    }
}
