using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Game.Collectable
{
    public interface ICollectablePresenter
    {
        void Initialize(Transform player);
    }
}