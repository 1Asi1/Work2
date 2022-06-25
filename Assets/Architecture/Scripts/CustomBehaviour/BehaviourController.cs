using Assets.Architecture.Scripts.CustomBehaviour.BehavioursCollection;
using System;
using System.Collections.Generic;

namespace Assets.Architecture.Scripts.CustomBehaviour
{
    public class BehaviourController
    {
        public Dictionary<Type, IBehaviour> behavioursMap;

        private Unit _unitScript;

        private IBehaviour _currentBehaviour;

        public void BehaviourStart()
        {
            InitBehaviour();
            SetDefaultBehaviour();
        }

        public void BehaviourUpdate()
        {
            _currentBehaviour.Update();
        }

        public void BehaviourFixedUpdate()
        {
            _currentBehaviour.FixedUpdate();
        }

        public void SetBehaviour<T>() where T : IBehaviour
        {
            if (_currentBehaviour != null)
            {
                _currentBehaviour.Exit();
            }

            var type = typeof(T);
            _currentBehaviour = behavioursMap[type];
            _currentBehaviour?.Enter();
        }

        private void InitBehaviour()
        {
            behavioursMap = new Dictionary<Type, IBehaviour>();
            behavioursMap[typeof(BehaviourIdle)] = new BehaviourIdle(_unitScript);
        }

        private void SetDefaultBehaviour()
        {
            _currentBehaviour = behavioursMap[typeof(BehaviourIdle)];
            _currentBehaviour?.Enter();
        }

        public BehaviourController(Unit script)
        {
            _unitScript=script;
        }
    }
}
