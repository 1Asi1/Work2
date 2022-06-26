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

        public void OnActionEnter()
        {
            _canvas = _canvas.GetComponent<Canvas>();
            _text = _text.GetComponent<TextMeshProUGUI>();
            _animator=GetComponent<Animator>();
            _canvas.gameObject.SetActive(true);
            _text.text= _keyCodeInteractive.ToString();
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
