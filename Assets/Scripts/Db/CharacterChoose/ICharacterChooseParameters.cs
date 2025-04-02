using UnityEngine;

namespace Db.CharacterChoose
{
    public interface ICharacterChooseParameters
    {
        RenderTexture RightArrowTexture { get; }
        RenderTexture LeftArrowTexture { get; }
    }
}