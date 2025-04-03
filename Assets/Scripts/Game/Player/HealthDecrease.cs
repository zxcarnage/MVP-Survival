using System;
using Core.Utils;
using Game.Player.Models;
using Game.Services.SceneLoading;
using UnityEngine;
using Zenject;

namespace Game.Player
{
    public class HealthDecrease : MonoBehaviour
    {
        private HealthModel _healthModel;
        private WaterModel _waterModel;
        private HungerModel _hungerModel;

        private float _passedTime = 0f;

        [Inject]
        private void Construct(HealthModel healthModel, WaterModel waterModel, HungerModel hungerModel)
        {
            _healthModel = healthModel;
            _waterModel = waterModel;
            _hungerModel = hungerModel;
        }

        private void Update()
        {
            if (_waterModel.Value.Value <= 50f || _hungerModel.Value.Value <= 50f)
            {
                _passedTime += Time.deltaTime;
                if (_passedTime <= 2f)
                    return;
                _healthModel.DecreaseValue(5);
            }
            else
            {
                _passedTime += Time.deltaTime;
                if (_passedTime <= 3f)
                    return;
                _healthModel.IncreaseValue(1);
            }
            _passedTime = 0f;
            
            if(_healthModel.Value.Value <= 0f)
                Application.Quit();
        }
    }
}