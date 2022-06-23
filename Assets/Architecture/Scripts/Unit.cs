using Assets.Architecture.Scripts.CustomBehaviour;
using UnityEngine;

namespace Assets.Architecture.Scripts
{
    public class Unit : MonoBehaviour
    {
        public BehaviourController _behaviourController;

        public virtual void Start()
        {
            _behaviourController = new BehaviourController(this);
            _behaviourController.BehaviourStart();
        }

        public virtual void Update()
        {
            _behaviourController.BehaviourUpdate();
        }

        public virtual void FixedUpdate()
        {
            _behaviourController.BehaviourFixedUpdate();
        }

    }
}
