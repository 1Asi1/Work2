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

        private KeyCode _keyCodeInteractive = KeyCode.E;

        private Animator _animator;

        private void Start()
        {
            _canvas = _canvas.GetComponent<Canvas>();
            _text = _text.GetComponent<TextMeshProUGUI>();
            _animator = GetComponent<Animator>();
            _text.text = _keyCodeInteractive.ToString();
        }

        public void OnActionEnter()
        {
            _canvas.gameObject.SetActive(true);
        }

        public void OnActionExit()
        {
            _canvas.gameObject.SetActive(false);
        }

        public void OnAction()
        {
            _doorIsActive = !_doorIsActive;
            _animator.SetBool(DOORANAME, _doorIsActive);
        }
    }
}
