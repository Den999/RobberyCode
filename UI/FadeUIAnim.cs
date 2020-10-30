using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class FadeUIAnim : MonoBehaviour
{
    [SerializeField] private float _to = .8f;
    [SerializeField] private float _duration = .5f;
    [SerializeField] private Ease _ease = Ease.InOutSine;

    private void Start()
    {
        GetComponent<MaskableGraphic>().DOFade(_to, _duration).SetEase(_ease).SetLoops(-1, LoopType.Yoyo);
    }
}
