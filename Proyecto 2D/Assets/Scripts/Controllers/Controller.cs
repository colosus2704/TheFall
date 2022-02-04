using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FSM
{
    public class Controller : MonoBehaviour
    {
        public State currentState; 
        public State remainState; 

        private HealthSystem _healthSystem;

        private InputSystemKeyboard _inputSystemKeyboard;

        private GroundDetector _groundDetector;

        public Transform[] shotPoints;

        public AudioClip[] Audio;

        internal int GetCurrentHealth()
        {
            return _healthSystem.GetHealth();
        }

        public bool GetInputW()
        {
            return _inputSystemKeyboard.w;
        }
        public bool GetInputS()
        {
            return _inputSystemKeyboard.s;
        }
        internal bool GetGround()
        {
            return _groundDetector.isGrounded;
        }
        public Transform GetShotPoint(int position)
        {
            return shotPoints[position];
        }
        public AudioClip GetAudioClip(int position)
        {
            return Audio[position];
        }
        public void SetAnimation(string animation, bool value)
        {
            _animatorController.SetBool(animation, value);
        }

        private Animator _animatorController;

        private void Awake()
        {
            _animatorController = GetComponent<Animator>();
            _healthSystem = GetComponent<HealthSystem>();
            _inputSystemKeyboard = GetComponent<InputSystemKeyboard>();
            _groundDetector = GetComponent<GroundDetector>();
        }

        public void Update() 
        {
            currentState.UpdateState(this);                                              
        }

        public void Transition(State nextState)
        {
            if (nextState != remainState)
            {
                currentState = nextState;
            }
        }
    }
}