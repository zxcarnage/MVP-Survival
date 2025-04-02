using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Ui.Needs
{
    public abstract class ANeed : MonoBehaviour
    {
        [SerializeField] protected TMP_Text NeedValue;
        [SerializeField] protected Slider NeedSlider;

        [SerializeField] private float _moveSpeed;

        protected void UpdateView(int newValue)
        {
            NeedSlider.DOValue(newValue, _moveSpeed).SetEase(Ease.Linear);
            NeedValue.text = newValue.ToString();
        }
    }
}