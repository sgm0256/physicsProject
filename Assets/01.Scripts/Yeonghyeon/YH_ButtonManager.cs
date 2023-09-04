using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class YH_ButtonManager : MonoBehaviour
{
    [SerializeField] Image main;
    [SerializeField] Image explanation;
    [SerializeField] TextMeshProUGUI explanationTxt;
    [SerializeField] TextMeshProUGUI scoreTxt;


    private void Start()
    {
        Score();
    }

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

    public void StartBtn()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitBtn()
    {
        Application.Quit();
    }

    void Score()
    {
        scoreTxt.text = sgm_GameManager.Instance.Score+"V";
    }
}
