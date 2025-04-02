using DG.Tweening;
using UnityEngine;

namespace Ui.CharacterChoose
{
    public class CharacterRotator : MonoBehaviour
    {
        private Tween _tween;
        private Transform _transform;
        private void Start()
        {
            _transform = transform;
            _tween = _transform.DORotate(new Vector3(0, 360, 0), 2f, RotateMode.LocalAxisAdd)
                .SetEase(Ease.Linear)
                .SetLoops(-1, LoopType.Incremental);
        }

        private void OnDestroy()
        {
            _tween?.Kill();
        }
    }
}