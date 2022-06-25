using Assets.Architecture.Scripts.CustomBehaviour.BehavioursCollection;
using UnityEngine;

namespace Assets.Architecture.Scripts
{
    public class PlayerController : Unit
    {
        [SerializeField] private Gun _gun;

        private InputKey _inputKey;
        private Animator _animator;

        private bool _isJump = false;
        private bool _isMove = false;

        private float _playerRotationY;
        private float _mouseSensX = 30f;

        private void Awake()
        {
            _inputKey = new InputKey();
            _animator = GetComponent<Animator>();
            _gun = _gun.GetComponent<Gun>();
            SetCursorParameters();
        }

        private void OnEnable()
        {
            _inputKey.moveKeyDown += RunStart;
            _inputKey.moveKeyUp += RunStop;
            _inputKey.jumpKeyPressed += Jump;
            _inputKey.shootingMousLeftPressed += Shot;
        }

        private void OnCollisionEnter(Collision collision)
        {
            OnCollision(collision);
        }

        public override void Start()
        {
            base.Start();
            AddUnitBehaviour();
        }

        public override void Update()
        {
            base.Update();
            _inputKey.Update();
            LookAtMouse();
        }

        private void OnDisable()
        {
            _inputKey.moveKeyDown -= RunStart;
            _inputKey.moveKeyUp -= RunStop;
            _inputKey.jumpKeyPressed -= Jump;
            _inputKey.shootingMousLeftPressed -= Shot;
        }

        private void OnCollisionExit(Collision collision)
        {
            if (collision.collider.GetComponent<IInteractiveble>() != null)
            {
                var component = collision.collider.GetComponent<IInteractiveble>();
                component.OnActionExit();
            }
        }

        private void OnCollision(Collision collision)
        {
            if (_isJump)
            {
                if (collision.collider.GetComponent<Grounds>() != null)
                {
                    JumpExit();
                }
            }

            if (collision.collider.GetComponent<IInteractiveble>() != null)
            {
                var component = collision.collider.GetComponent<IInteractiveble>();
                component.OnActionEnter();
            }
        }

        private void AddUnitBehaviour()
        {
            _behaviourController.behavioursMap[typeof(BehaviourRun)] = new BehaviourRun(this);
            _behaviourController.behavioursMap[typeof(BehaviourJump)] = new BehaviourJump(this);
        }

        private void RunStart()
        {
            _behaviourController.SetBehaviour<BehaviourRun>();
            _isMove = true;
        }

        private void RunStop()
        {
            _behaviourController.SetBehaviour<BehaviourIdle>();
            _isMove = false;
        }

        private void Jump()
        {
            if (!_isJump)
            {
                _isJump = true;
                _behaviourController.SetBehaviour<BehaviourJump>();
            }
        }

        private void JumpExit()
        {
            if (_isMove)
            {
                _behaviourController.SetBehaviour<BehaviourRun>();
            }
            else
            {
                _behaviourController.SetBehaviour<BehaviourIdle>();
            }

            _isJump = false;
        }

        private void Shot()
        {
            _behaviourController.SetBehaviour<BehaviourIdle>();
            _animator.SetTrigger("Shot");
            _gun.Shot();
            _animator.SetTrigger("ShotEnd");
        }

        private void SetCursorParameters()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        private void LookAtMouse()
        {
            var mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * _mouseSensX;
            _playerRotationY -= mouseX;
            var _resultRotate = Quaternion.Euler(0, -_playerRotationY, 0);
            transform.rotation = _resultRotate;
        }
    }
}
