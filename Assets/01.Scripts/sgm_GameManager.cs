using System;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class sgm_GameManager : MonoSingleton<sgm_GameManager>
{
    private Transform _canvasTrm;
    
    private Slider hpBarSlider;
    private TextMeshProUGUI scoreTxt;
    private GameObject gameOverPanel;
    private TextMeshProUGUI endScoreTxt;
    private GameObject _quitPanel;

    [SerializeField] private Material _material;
    private readonly int _valueHash = Shader.PropertyToID("_Value");

    private bool isGameEnd;
    private float divideValue = 100f;
    private float _value = 0.15f;
    private float score;

    private Tween _tween;

    private void Awake()
    {
        _canvasTrm = GameObject.Find("Canvas").transform;

        hpBarSlider = _canvasTrm.Find("HPBarSlider").GetComponent<Slider>();
        scoreTxt = _canvasTrm.Find("ScoreText").GetComponent<TextMeshProUGUI>();
        gameOverPanel = _canvasTrm.Find("GameOverPanel").gameObject;
        endScoreTxt = gameOverPanel.transform.Find("ScoreText").GetComponent<TextMeshProUGUI>();
        _quitPanel = _canvasTrm.Find("QuitPanelBackground").gameObject;
        
        InitializeApplicationQuit();
    }

    private void Start()
    {
        gameOverPanel.SetActive(false);
        _quitPanel.SetActive(false);
        _material.SetFloat(_valueHash, 0);
        ScoreUpdate();
    }

    private void Update()
    {
        _value += Time.deltaTime / divideValue;
        MinusLife(_value);
        OnGetButtonEsc();
        GameOver();
    }

    private void OnGetButtonEsc()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (_quitPanel.activeSelf)
            {
                Time.timeScale = 0;
                _quitPanel.SetActive(true);
                return;
            }
            else
            {
                OnClickQuitCancel();
                return;
            }
        }
    }

    public void Plus()
    {
        score += 10;
        hpBarSlider.value += 15 + _value * 15f;
        ScoreUpdate();
    }

    public void Minus()
    {
        hpBarSlider.value -= 15 + _value * 15f;
    }

    private void MinusLife(float value)
    {
        hpBarSlider.value -= value;
    }
    void ScoreUpdate()
    {
        scoreTxt.text = "점수 : " + score;
    }
    
    private void GameOver()
    {
        if (hpBarSlider.value <= 0)
        {
            gameOverPanel.SetActive(true);
            endScoreTxt.text = scoreTxt.text;
            Time.timeScale = 0;
        }
    }

    public void Damaged(float startValue, float endValue)
    {
        _tween.Kill();
        _material.SetFloat(_valueHash, startValue);
        _tween = DOTween.To
        (
            () => _material.GetFloat(_valueHash),
            value => _material.SetFloat(_valueHash, value),
            endValue,
            0.5f
        );
    }

    private void OnClickQuitProcess()
    {
        Application.Quit();
    }

    private void OnClickQuitCancel()
    {
        Time.timeScale = 1;
        _quitPanel.SetActive(false);
    }
} 
