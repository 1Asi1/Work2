using UnityEngine;

namespace Assets.Architecture.Scripts.CustomBehaviour.BehavioursCollection
{
    public class BehaviourIdle : GeneralBehaviour
    {

        public override void Enter()
        {
            _animator = _unitScript.GetComponent<Animator>();
            _rb = _unitScript.GetComponent<Rigidbody>();
            _animator.SetBool("Idle", true);
        }

        public override void Exit()
        {
            _animator.SetBool("Idle", false);
        }

        public override void Update()
        {

        }

        public override void FixedUpdate()
        {

        }

        public BehaviourIdle(Unit script) : base(script)
        {

        }
    }
}
