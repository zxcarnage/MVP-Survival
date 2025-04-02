using UnityEngine;

namespace Ui.CharacterChoose
{
    public class CharacterInit : MonoBehaviour
    {
        [SerializeField] private AArrow _startParameters;

        private void OnEnable()
        {
            _startParameters.ChangeStats(new ());
        }
    }
}