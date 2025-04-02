using System;
using Game.Services.Input;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace Ui.UpgradeView
{
    public class UpgradeView : MonoBehaviour
    {
        [SerializeField] private CanvasGroup _canvasGroup;
        
        private IInputProvider _inputProvider;

        [Inject]
        private void Construct(
            IInputProvider inputProvider
        )
        {
            _inputProvider = inputProvider;
        }

        private void OnEnable()
        {
            _inputProvider.InputSystem.Player.SkillTree.performed += ChangeSkillTreeVision;
        }

        private void ChangeSkillTreeVision(InputAction.CallbackContext context)
        {
            if (Mathf.Approximately(_canvasGroup.alpha, 1))
            {
                Time.timeScale = 1f;
                _canvasGroup.alpha = 0;
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
            else
            {
                Time.timeScale = 0f;
                Cursor.lockState = CursorLockMode.Confined;
                Cursor.visible = true;
                _canvasGroup.alpha = 1;
            }
        }

        private void OnDisable()
        {
            _inputProvider.InputSystem.Player.SkillTree.performed -= ChangeSkillTreeVision;
        }
    }
}