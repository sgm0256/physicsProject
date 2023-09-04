using System;
using System.Collections;
using UnityEngine;
using DG.Tweening;

public class Galvanometer : MonoBehaviour
{
    private Transform _needleTrm;
    private Sequence _seq;

    private void Awake()
    {
        _needleTrm = transform.Find("Needle");
    }

    private void Update()
    {
        Separate();
        Sort();
    }

    private void Separate()
    {
        if ((int)Input.GetAxisRaw("Horizontal") == -1)
        {
            _seq = DOTween.Sequence();
            _seq.Append(_needleTrm.DORotateQuaternion(Quaternion.Euler(0, 0, 80), 0.5f).SetEase(Ease.InOutCubic));
            _seq.Append(_needleTrm.DORotateQuaternion(Quaternion.identity, 0.5f).SetEase(Ease.InOutCubic));
        }
        if ((int)Input.GetAxisRaw("Horizontal") == 1)
        {
            _seq = DOTween.Sequence();
            _seq.Append(_needleTrm.DORotateQuaternion(Quaternion.Euler(0, 0, -80), 0.5f).SetEase(Ease.InOutCubic));
            _seq.Append(_needleTrm.DORotateQuaternion(Quaternion.identity, 0.5f).SetEase(Ease.InOutCubic));
        }
    }

    private void Sort()
    {
        if (YSGameManager.Instance.IsUnderS);
    }
}
