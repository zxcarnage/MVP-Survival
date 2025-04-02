using System;
using Game.Player;
using Game.Player.Models;
using UnityEngine;

namespace Game.Services.Needs.Impl
{
    public class NeedService : INeedService
    {
        private readonly HungerModel _hungerModel;
        private readonly WaterModel _waterModel;

        public NeedService(
            HungerModel hungerModel,
            WaterModel waterModel
        )
        {
            _hungerModel = hungerModel;
            _waterModel = waterModel;
        }
        
        public void DecreaseNeed(int value, ENeedType type)
        {
            switch (type)
            {
                case ENeedType.Water:
                    _waterModel.Value.Value = Mathf.Clamp(_waterModel.Value.Value - value, 0, 100);
                    break;
                case ENeedType.Hunger:
                    _hungerModel.Value.Value = Mathf.Clamp(_hungerModel.Value.Value - value, 0, 100);
                    break;
            }
        }

        public void IncreaseNeed(int value, ENeedType type)
        {
            switch (type)
            {
                case ENeedType.Water:
                    _waterModel.Value.Value = Mathf.Clamp(_waterModel.Value.Value + value, 0, 100);
                    break;
                case ENeedType.Hunger:
                    _hungerModel.Value.Value = Mathf.Clamp(_hungerModel.Value.Value + value, 0, 100);
                    break;
            }
        }
    }
}