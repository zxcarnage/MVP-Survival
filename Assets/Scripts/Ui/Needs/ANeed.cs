using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Ui.Needs
{
    public abstract class ANeed : MonoBehaviour
    {
        [SerializeField] private TMP_Text _needValue;
        [FormerlySerializedAs("_needSlider")] 
        [SerializeField] protected Slider NeedSlider;

        [SerializeField] private float _moveSpeed;

        protected void UpdateView(int newValue)
        {
            NeedSlider.DOValue(newValue, _moveSpeed).SetEase(Ease.Linear);
            _needValue.text = newValue.ToString();
        }
    }
}