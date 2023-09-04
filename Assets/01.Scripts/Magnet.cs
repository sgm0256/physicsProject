using UnityEngine;
using DG.Tweening;

public class Magnet : MonoBehaviour
{
    [SerializeField]
    private Transform spawnTrm;
    [SerializeField]
    private Sprite[] magnetSpr;

    SpriteRenderer spriteRenderer;
    private Tween tween;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }


    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            if (tween != null && tween.IsActive()) return;
            if (transform.position.y <= 1f)
            {
                tween = transform.DOMoveY(-6.5f, 0.2f).OnComplete(() =>
                {
                    transform.position = spawnTrm.position;
                    int ran = Random.Range(1, 3);
                    if (ran == 1)
                        spriteRenderer.sprite = magnetSpr[0];
                    else
                        spriteRenderer.sprite = magnetSpr[1];
                });
            }
            else
            {
                tween = transform.DOMoveY(transform.position.y - 2.5f, 0.2f);
            }
        }
    }
}
