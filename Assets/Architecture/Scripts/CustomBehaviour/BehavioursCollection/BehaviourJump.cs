using UnityEngine;

namespace Assets.Architecture.Scripts.CustomBehaviour.BehavioursCollection
{
    public class BehaviourJump : GeneralBehaviour
    {
        private Vector3 _jumpDirection;

        private float _jumpPower = 300f;

        private bool _isJumping = false;
        public override void Enter()
        {
            _animator = _unitScript.GetComponent<Animator>();
            _rb = _unitScript.GetComponent<Rigidbody>();
            _animator.SetTrigger("Jump");
            _jumpDirection = Vector3.up * _jumpPower;
            _isJumping = true;
        }

        public override void Exit()
        {

        }

        public override void Update()
        {

        }
        public override void FixedUpdate()
        {
            Jump();
        }

        public BehaviourJump(Unit script) : base(script)
        {

        }

        private void Jump()
        {
            if (_isJumping)
            {
                _isJumping = false;
                _rb.AddForce(_jumpDirection, ForceMode.Impulse);
            }
        }
    }
}
