using UnityEngine;

namespace Assets.Architecture.Scripts.CustomBehaviour
{
    public abstract class GeneralBehaviour : IBehaviour
    {
        public Unit _unitScript;

        protected Animator _animator;

        protected Rigidbody _rb;

        public abstract void Enter();

        public abstract void Exit();

        public abstract void Update();

        public abstract void FixedUpdate();

        public GeneralBehaviour(Unit unit)
        {
            _unitScript=unit;
        }
        
    }
}
