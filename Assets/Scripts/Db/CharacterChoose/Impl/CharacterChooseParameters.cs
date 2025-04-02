using UnityEngine;

namespace Db.CharacterChoose.Impl
{
    [CreateAssetMenu(menuName = "Settings/" + nameof(CharacterChooseParameters), fileName = nameof(CharacterChooseParameters))]
    public class CharacterChooseParameters : ScriptableObject, ICharacterChooseParameters
    {
        [field: SerializeField]
        public RenderTexture RightArrowTexture { get; private set; }
        [field: SerializeField]
        public RenderTexture LeftArrowTexture { get; private set; }
    }
}