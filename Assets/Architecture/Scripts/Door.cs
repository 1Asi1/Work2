using TMPro;
using UnityEngine;

namespace Assets.Architecture.Scripts
{
    public class Door : MonoBehaviour, IInteractiveble
    {
        private const string DOORANAME = "DoorActivate";

        [SerializeField] private Canvas _canvas;
        [SerializeField] private TextMeshProUGUI _text;

        private bool _doorIsActive = false;
        private bool _playerIsDetected = false;

        private KeyCode _keyCodeInteractive = KeyCode.E;

        private Animator _animator;

        private void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<PlayerController>() != null)
            {
                OnActionEnter();
            }
        }

        public void OnActionEnter()
        {
            _canvas = _canvas.GetComponent<Canvas>();
            _text = _text.GetComponent<TextMeshProUGUI>();
            _animator=GetComponent<Animator>();
            _canvas.gameObject.SetActive(true);
            _playerIsDetected = true;
            _text.text= KeyCode.E.ToString();
        }

        public void OnActionExit()
        {
            _canvas.gameObject.SetActive(false);
            _playerIsDetected = false;
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.GetComponent<PlayerController>() != null)
            {
                OnActionExit();
            }
        }

        public void OnAction()
        {
            _doorIsActive = !_doorIsActive;
            _animator.SetBool(DOORANAME, _doorIsActive);
        }

        private void Update()
        {
            GetInput();
        }

        private void GetInput()
        {
            if (_playerIsDetected)
            {
                if (Input.GetKeyDown(_keyCodeInteractive))
                {
                    OnAction();
                }
            }
        }
    }
}
