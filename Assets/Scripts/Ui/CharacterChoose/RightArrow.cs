using UnityEngine;

namespace Ui.CharacterChoose
{
    public class RightArrow : AArrow
    {
        protected override RenderTexture TargetRenderTexture => CharacterChooseParameters.RightArrowTexture;
    }
}