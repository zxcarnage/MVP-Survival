using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace Ui.MainMenu
{
    public abstract class AButton : MonoBehaviour
    {
        private Button _button;

        private void Start()
        {
            _button = GetComponent<Button>();
            _button.OnClickAsObservable().Subscribe(OnAction).AddTo(this);
        }

        protected abstract void OnAction(Unit unit);
    }
}