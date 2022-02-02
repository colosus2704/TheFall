using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FSM
{
    public class Controller : MonoBehaviour
    {
        public State currentState; // apuntador al estado actual
        public State remainState;  // el estado en el que te quedas si no pasas a la siguiente

        private HealthSystem _healthSystem;

        private InputSystemKeyboard _inputSystemKeyboard;

        private GroundDetector _groundDetector;
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
        public void SetAnimation(string animation, bool value)
        {
            _animatorController.SetBool(animation, value);
        }

        private Animator _animatorController;
        //private HealthSystem _healtSystem;

        private void Awake()
        {
            _animatorController = GetComponent<Animator>();
            _healthSystem = GetComponent<HealthSystem>();
            _inputSystemKeyboard = GetComponent<InputSystemKeyboard>();
            _groundDetector = GetComponent<GroundDetector>();
        }

        public void Update() // Se ejecutan las acciones del estado actual.
        {
            currentState.UpdateState(this);   // El parámetro permite que los 
                                              // estados tengan una referencia al
                                              // controlador, para poder llamar a
                                              // sus métodos
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