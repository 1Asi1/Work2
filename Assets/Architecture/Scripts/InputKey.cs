using System;
using UnityEngine;

namespace Assets.Architecture.Scripts
{
    public class InputKey
    {
        public event Action moveKeyDown;
        public event Action moveKeyUp;
        public event Action jumpKeyPressed;
        public event Action shootingMousLeftPressed;
        public event Action onAction;

        private bool _movekeysIsPressed=false;
        public void Update()
        {
            GetInputKey();
        }

        public void GetInputKey()
        {
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
            {
                if (_movekeysIsPressed)
                {
                    _movekeysIsPressed = false;
                    moveKeyDown?.Invoke();
                }
            }
            else
            {
                if (!_movekeysIsPressed)
                {
                    _movekeysIsPressed = true;
                    moveKeyUp?.Invoke();
                }  
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                jumpKeyPressed?.Invoke();
            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                onAction?.Invoke();
            }

            if (Input.GetMouseButtonDown(0))
            {
                shootingMousLeftPressed?.Invoke();
            }
        }
    }
}
