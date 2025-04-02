using UniRx;
using UnityEngine;

namespace Ui.MainMenu.Impl
{
    public class ExitButton : AButton
    {
        protected override void OnAction(Unit unit)
        {
            Application.Quit();
        }
    }
}