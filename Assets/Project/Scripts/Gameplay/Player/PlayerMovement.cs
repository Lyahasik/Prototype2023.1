using System;
using UnityEngine;

using Prototype.UI.Gameplay;

namespace Prototype.Gameplay.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private ParticleSystem effectMovement;

        [Space]
        [SerializeField] private float gravityMin;
        [SerializeField] private float gravityMax;
        [SerializeField] private float gravityRateChange;

        private float _currentGravity;
        private bool _isGravityActive;

        private bool _isActive;

        private void OnEnable()
        {
            TouchArea.OnTouchUp += GravityOff;
            TouchArea.OnTouchDown += GravityOn;
        }

        private void Update()
        {
            ChangeGravity();
            ApplyGravity();
        }

        private void ChangeGravity()
        {
            if (!_isActive)
                return;

            if (_isGravityActive)
                _currentGravity = Math.Clamp(_currentGravity + gravityRateChange, gravityMin, gravityMax);
            else
                _currentGravity = Math.Clamp(_currentGravity - gravityRateChange, gravityMin, gravityMax);
        }

        private void ApplyGravity()
        {
            if (!_isActive)
                return;
            
            transform.Translate(Vector3.up * (_currentGravity * Time.deltaTime));
        }

        public void Activate()
        {
            effectMovement.Play();

            _isActive = true;
        }

        public void Reset()
        {
            effectMovement.Stop();

            _currentGravity = 0f;
            _isActive = false;
        }

        private void GravityOn()
        {
            _isGravityActive = true;
        }

        private void GravityOff()
        {
            _isGravityActive = false;
        }
    }
}
