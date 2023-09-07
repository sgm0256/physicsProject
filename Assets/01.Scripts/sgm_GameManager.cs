using DG.Tweening;
using System.Collections;
using System.Security.Cryptography;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class sgm_GameManager : MonoSingleton<sgm_GameManager>
{
    [SerializeField]
    private Slider slider;
    [SerializeField]
    private GameObject panel;
    [SerializeField]
    TextMeshProUGUI scoreTxt;
    [SerializeField]
    TextMeshProUGUI endScoreTxt;
    [SerializeField]
    GameObject gameOverPenel;

    [SerializeField] private Material _material;
    private readonly int _valueHash = Shader.PropertyToID("_Value");

    bool isGameEnd;
    private float divideValue = 100f;
    private float value = 0.15f;
    public float Score { get; private set; }

    private void Start()
    {
        ScoreUpdate();
    }

    private void Update()
    {
        //Test
        /*if(slider.value == 0)
        {
            panel.SetActive(true);
        }*/

        value += Time.deltaTime / divideValue;
        MinusLife(value);
    }

    public void Plus()
    {
        Score += 10;
        slider.value += 15 + value * 15f;
        ScoreUpdate();
    }

    public void Minus()
    {
        slider.value -= 15 + value * 35f;
        //StartCoroutine("PanelActive"); Test
    }

    private void MinusLife(float value)
    {
        slider.value -= value;
    }
    void ScoreUpdate()
    {
        scoreTxt.text = "점수 : " + Score;
    }
    
    private void GameOver()
    {
        if (slider.value < 0 || slider.value == 0)
        {
            endScoreTxt.text = "점수 : " + Score;
            gameOverPenel.SetActive(true);
        }
    }

    public void Damaged(float startValue, float endValue)
    {
        _material.SetFloat(_valueHash, startValue);
        DOTween.To
        (
            () => _material.GetFloat(_valueHash),
            value => _material.SetFloat(_valueHash, value),
            endValue,
            0.5f
        );
    }
} 
