using UnityEngine;

namespace Game.Ship
{
    public interface IShipPresenter
    {
        public void Build(GameObject inactive, GameObject active);
    }
}