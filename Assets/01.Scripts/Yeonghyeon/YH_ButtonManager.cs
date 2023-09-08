using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
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

    public void StartBtn()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }

    public void QuitBtn()
    {
        SceneManager.LoadScene(0);
    }
}
