using UnityEngine;

namespace Assets.Architecture.Scripts.CustomBehaviour.BehavioursCollection
{
    public class BehaviourJump : GeneralBehaviour
    {
        private float jumpPower=3f;
        public override void Enter()
        {
            _animator = _unitScript.GetComponent<Animator>();
            _rb= _unitScript.GetComponent<Rigidbody>();
            _animator.SetTrigger("Jump");
            _rb.AddForce(Vector3.up* jumpPower, ForceMode.Impulse);
        }
       
        public override void Exit()
        {

        }

        public override void Update()
        {

        }
        public override void FixedUpdate()
        {

        }

        public BehaviourJump(Unit script) : base(script)
        {

        }
    }
}
