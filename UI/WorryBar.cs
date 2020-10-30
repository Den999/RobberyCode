using System;
using D2D.Utils;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace D2D
{
    public class WorryBar : MonoBehaviour
    {
        [SerializeField] private DOTweenAnimation _bellAnim;
        [SerializeField] private Slider _slider;
        private WorryHub _worryHub;

        private void OnDrawGizmos()
        {
            if (_slider != null)
                _slider.maxValue = 1;
        }

        private void OnEnable()
        {
            _worryHub = gameObject.FindOrCreate<WorryHub>();
            _worryHub.WorryOverhead += PlayAlarmAnim;
            
            InvokeRepeating(nameof(UpdateBar), 0, 1/20f);
        }

        private void OnDisable()
        {
            _worryHub.WorryOverhead -= PlayAlarmAnim;
        }

        private void PlayAlarmAnim()
        {
            _bellAnim.DOPlay();
        }

        private void UpdateBar()
        {
            _slider.value = _worryHub.WorryFactor;
        }
    }
}