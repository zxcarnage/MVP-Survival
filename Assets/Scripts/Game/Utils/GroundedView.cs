using Game.Player.Presenter.Jump;
using Game.Player.Presenter.Jump.Model;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using Zenject;

namespace Game.Utils
{
    public class GroundedView : MonoBehaviour
    {
        [SerializeField] private Collider _trigger;
        
        private GroundedModule _groundedModule;

        [Inject]
        public void Construct(
            GroundedModule groundedModule
        )
        {
            _groundedModule = groundedModule;
        }
        
        private void Awake()
        {
            _trigger.OnTriggerEnterAsObservable().Subscribe(Ground);
            _trigger.OnTriggerExitAsObservable().Subscribe(Unground);
            
        }

        private void Ground(Collider col)
        {
            if(col.gameObject.layer != LayerMask.NameToLayer("Ground")) 
                return;
            
            _groundedModule.IsGrounded.Value = true;
        }
        
        private void Unground(Collider col)
        {
            if(col.gameObject.layer != LayerMask.NameToLayer("Ground")) 
                return;
            
            _groundedModule.IsGrounded.Value = false;
        }
    }
}