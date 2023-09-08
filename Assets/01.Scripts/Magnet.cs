using UnityEngine;
using DG.Tweening;

public class Magnet : MonoBehaviour
{
    [SerializeField]
    private Transform spawnTrm;
    [SerializeField]
    private Sprite[] magnetSpr;

    private int _spriteIdx;

    SpriteRenderer spriteRenderer;
    private Tween tween;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        ChangeSprite();
    }

    private void Update()
    {
        Seperate();
    }

    private void Seperate()
    {
        if (tween != null && tween.IsActive()) return;
        if ((int)Input.GetAxisRaw("Horizontal") == -1) MoveTween(0);
        if ((int)Input.GetAxisRaw("Horizontal") == 1) MoveTween(1);
    }

    private void MoveTween(int currentIdx)
    {
        if (transform.position.y <= 1f)
        {
            if (_spriteIdx == currentIdx) sgm_GameManager.Instance.Plus();
            else
            {
                sgm_GameManager.Instance.Minus();
                sgm_GameManager.Instance.Damaged(1, 0);
            } 
            tween = transform.DOMoveY(-6.5f, 0.25f).OnComplete(() =>
            {
                transform.position = spawnTrm.position;
                ChangeSprite();
                
            });
        }
        else tween = transform.DOMoveY(transform.position.y - 3f, 0.25f);
    }

    private void ChangeSprite()
    {
        _spriteIdx = Random.Range(0, 2);
        if (_spriteIdx == 0)
            spriteRenderer.sprite = magnetSpr[0];
        else
            spriteRenderer.sprite = magnetSpr[1];
    }
}
