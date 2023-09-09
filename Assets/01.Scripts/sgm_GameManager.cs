using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class sgm_GameManager : MonoBehaviour
{
    public static sgm_GameManager _instance;

    public static sgm_GameManager Instance
    {
        get
        {
            _instance ??= FindObjectOfType<sgm_GameManager>();
            return _instance;
        }
    }

    private Transform _canvasTrm;
    
    private Slider hpBarSlider;
    private TextMeshProUGUI scoreTxt;
    private GameObject gameOverPanel;
    private TextMeshProUGUI endScoreTxt;
    private GameObject _quitPanel;

    [SerializeField] private Material _material;
    private readonly int _valueHash = Shader.PropertyToID("_Value");

    private float divideValue = 200f;
    private float score = 0;
    private float _time;

    private Tween _tween;
    private bool _isActivePanel;

    private void Awake()
    {
        _instance ??= this;
        
        _canvasTrm = GameObject.Find("Canvas").transform;

        hpBarSlider = _canvasTrm.Find("HPBarSlider").GetComponent<Slider>();
        scoreTxt = _canvasTrm.Find("ScoreText").GetComponent<TextMeshProUGUI>();
        gameOverPanel = _canvasTrm.Find("GameOverPanel").gameObject;
        endScoreTxt = gameOverPanel.transform.Find("ScoreText").GetComponent<TextMeshProUGUI>();
        _quitPanel = _canvasTrm.Find("QuitPanelBackground").gameObject;
    }

    private void Start()
    {
        Time.timeScale = 1;
        gameOverPanel.SetActive(false);
        _quitPanel.SetActive(false);
        _material.SetFloat(_valueHash, 0);
        ScoreUpdate();
    }

    private void Update()
    {
        MinusLife();
        OnGetButtonEsc();
        GameOver();
    }

    private void OnGetButtonEsc()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (_isActivePanel)
            {
                OnClickQuitCancel();
                _isActivePanel = false;
            }
            else
            {
                _quitPanel.SetActive(true);
                Time.timeScale = 0;
                _isActivePanel = true;
            }
        }
    }

    public void Plus()
    {
        score += 10;
        ScoreUpdate();
        hpBarSlider.value += 25;
    }

    public void Minus()
    {
        hpBarSlider.value -= 15;
    }

    private void MinusLife()
    {
        _time += Time.deltaTime * Time.timeScale;
        hpBarSlider.value -= (Time.deltaTime + _time / divideValue) * Time.timeScale;
    }
    private void ScoreUpdate()
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

    public void Damaged()
    {
        _tween.Kill();
        _material.SetFloat(_valueHash, 1);
        _tween = DOTween.To
        (
            () => _material.GetFloat(_valueHash),
            value => _material.SetFloat(_valueHash, value),
            0,
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
