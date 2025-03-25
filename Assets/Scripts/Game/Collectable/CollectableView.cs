using System;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using Zenject;

namespace Game.Collectable
{
    public class CollectableView : MonoBehaviour
    {
        [SerializeField] private ECollectableType _collectableType;
        [SerializeField] private Collider _collectableTrigger;

        [Inject]
        public void Construct(
            
        )
        {
        }
        
        private void Awake()
        {
            _collectableTrigger.OnTriggerEnterAsObservable().Subscribe(CollectableEntered);
        }

        private void CollectableEntered(Collider other)
        {
            
        }
    }
}