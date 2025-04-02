using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Ui.Needs
{
    public abstract class ANeed : MonoBehaviour
    {
        [SerializeField] private TMP_Text _needValue;
        [SerializeField] private Slider _needSlider;

        [SerializeField] private float _moveSpeed;

        protected void UpdateView(int newValue)
        {
            _needSlider.DOValue(newValue, _moveSpeed).SetEase(Ease.Linear);
            _needValue.text = newValue.ToString();
        }
    }
}