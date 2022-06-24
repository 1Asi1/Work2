using UnityEngine;

namespace Assets.Architecture.Scripts.CustomBehaviour.BehavioursCollection
{
    public class BehaviourRun : GeneralBehaviour
    {
        private const string HORIZONTAL = "Horizontal";
        private const string VERTICAL = "Vertical";

        private Vector3 _move;
        private Vector3 _moveDirection;

        private float _horizontalAxis;
        private float _verticalAxis;
        private float _speed = 3f;

        public override void Enter()
        {
            _animator = _unitScript.GetComponent<Animator>();
            _rb = _unitScript.GetComponent<Rigidbody>();
            _animator.SetBool("Run", true);
        }

        public override void Exit()
        {
            _animator.SetBool("Run", false);
        }

        public override void Update()
        {
            MoveUpdate();
        }

        public override void FixedUpdate()
        {
            _rb.MovePosition(_unitScript.gameObject.transform.position + _moveDirection);
        }

        public BehaviourRun(Unit script) : base(script)
        {

        }

        private void MoveUpdate()
        {
            _horizontalAxis = Input.GetAxis(HORIZONTAL);
            _verticalAxis = Input.GetAxis(VERTICAL);
            _move = new Vector3(_horizontalAxis, 0, _verticalAxis);
            _moveDirection = _move * _speed * Time.fixedDeltaTime;
            _moveDirection = _unitScript.transform.TransformDirection(_moveDirection);
        }
    }
}
