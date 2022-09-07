using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*This script is used to controll the jump of the entity you put it on, you can controll it from the editor,
it detects the ground to not be able to multijump, but it's easy to change it to do the typical double jump
from platformer games*/

public class JumpingBehaviour : MonoBehaviour
{
    public AudioClip Sound;

    [SerializeField]
    public float jumpspeed = 10;
    private GroundDetector _groundDetector;
    private Rigidbody2D _rb;
    private FSM.Controller _controller;


    internal bool GetGround()
    {
        return _groundDetector.isGrounded;
    }
    private void Awake()
    {
        _groundDetector = GetComponent<GroundDetector>();
        _rb = GetComponent<Rigidbody2D>();
        _controller = GetComponent<FSM.Controller>();
    }
    void Update()
    {
        if (_controller.GetInputW())
        {
            if (GetGround())
            {
                _rb.velocity = new Vector2(_rb.velocity.x, jumpspeed);
                PlaySound();
            }
        }
    }
    public void PlaySound()
    {
        GetComponent<AudioSource>().clip = Sound;
        GetComponent<AudioSource>().Play();
    }
}
