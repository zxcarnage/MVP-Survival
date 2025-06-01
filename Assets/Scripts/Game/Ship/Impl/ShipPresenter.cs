using UnityEngine;

namespace Game.Ship
{
    public class ShipPresenter : IShipPresenter
    {
        public void Build(GameObject inactive, GameObject active)
        {
            inactive.SetActive(false);
            active.SetActive(true);
        }
    }
}