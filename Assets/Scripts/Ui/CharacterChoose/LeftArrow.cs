using UnityEngine;

namespace Ui.CharacterChoose
{
    public class LeftArrow : AArrow
    {
        protected override RenderTexture TargetRenderTexture => CharacterChooseParameters.LeftArrowTexture;
    }
}