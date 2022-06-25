using UnityEngine;

namespace Assets.Architecture.Scripts
{
    public class Gun : MonoBehaviour, IShot
    {
        [SerializeField] private ParticleSystem _particleSystem;

        private AudioSource _audioSource;

        private void Start()
        {
            _audioSource = GetComponent<AudioSource>();
            _particleSystem = _particleSystem.GetComponent<ParticleSystem>();
        }

        public void Shot()
        {
            _audioSource.Play();
            _particleSystem.Play();
        }
    }
}
