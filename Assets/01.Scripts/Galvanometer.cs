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
    }

    private void Separate()
    {
        if ((int)Input.GetAxisRaw("Horizontal") == -1)
        { 
            _seq = DOTween.Sequence();
            _seq.Append(_needleTrm.DORotateQuaternion(Quaternion.Euler(0, 0, 50), 0.1f).SetEase(Ease.InOutCubic));
            _seq.Append(_needleTrm.DORotateQuaternion(Quaternion.Euler(0, 0, -50), 0.3f).SetEase(Ease.InOutCubic));
            _seq.Append(_needleTrm.DORotateQuaternion(Quaternion.identity, 0.5f).SetEase(Ease.InOutCubic));
        }
        if ((int)Input.GetAxisRaw("Horizontal") == 1)
        {
            _seq = DOTween.Sequence();
            _seq.Append(_needleTrm.DORotateQuaternion(Quaternion.Euler(0, 0, -50), 0.1f).SetEase(Ease.InOutCubic));
            _seq.Append(_needleTrm.DORotateQuaternion(Quaternion.Euler(0, 0, 50), 0.3f).SetEase(Ease.InOutCubic));
            _seq.Append(_needleTrm.DORotateQuaternion(Quaternion.identity, 0.5f).SetEase(Ease.InOutCubic));
        }
    }
}
