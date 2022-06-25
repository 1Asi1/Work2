using UnityEngine;

namespace Assets.Architecture.Scripts
{
    public class Door : MonoBehaviour, IInteractiveble
    {
        private const string DOORANAME = "DoorActivate";

        [SerializeField]private Canvas _canvas;

        private bool _doorIsActive = false;
        private bool _playerIsDetected=false;

        private Animator _animator;
        private AudioSource _audioSource;

        public void OnActionEnter()
        {
            _canvas= _canvas.GetComponent<Canvas>();
            _canvas.gameObject.SetActive(true);
            _playerIsDetected = true;
        }

        public void OnActionExit()
        {
            _canvas.gameObject.SetActive(false);
            _playerIsDetected = false;
        }

        public void OnAction()
        {
            _doorIsActive = !_doorIsActive;
            _animator.SetBool(DOORANAME, _doorIsActive);
            _audioSource.Play();
        }

        private void Update()
        {
            GetInput();
        }

        private void GetInput()
        {
            if (_playerIsDetected)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    OnAction();
                }
            }
        }
    }
}
