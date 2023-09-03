using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class YH_ButtonManager : MonoBehaviour
{
    [SerializeField] Image main;
    [SerializeField] Image explanation;
    [SerializeField] TextMeshProUGUI explanationTxt;


    public void ExplanationBtn()
    {
        main.gameObject.SetActive(true);
        main.DOFade(0.9f, 0.5f);
        explanation.DOFade(1f, 0.5f);
        explanationTxt.DOFade(1f, 0.5f);
    }

    public void ExplanationClose()
    {
        main.DOFade(0f, 0.5f);
        explanation.DOFade(0f, 0.5f);
        explanationTxt.DOFade(0f, 0.5f).OnComplete(() => main.gameObject.SetActive(false));
    }
}
