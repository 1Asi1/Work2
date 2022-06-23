using Assets.Architecture.Scripts.CustomBehaviour.BehavioursCollection;
using UnityEngine;

namespace Assets.Architecture.Scripts
{
    public class PlayerController : Unit
    {
        private InputKey _inputKey;
        private bool _isJump = false;
        private bool _isMove = false;

        private void Awake()
        {
            _inputKey = new InputKey();
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
            if (_isJump)
            {
                if (collision.collider.GetComponent<Grounds>() != null)
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
            }
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
        }

        private void OnDisable()
        {
            _inputKey.moveKeyDown -= RunStart;
            _inputKey.moveKeyUp -= RunStop;
            _inputKey.jumpKeyPressed -= Jump;
            _inputKey.shootingMousLeftPressed -= Shot;
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

        private void Shot()
        {

        }
    }
}
