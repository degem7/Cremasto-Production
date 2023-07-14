using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float acceleration;
    [SerializeField] private float maxSpeed;
    [SerializeField] private float jumpForce;

    private Rigidbody2D rigidbody;
    private float movementX;
    private float movementY;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    private void OnJump()
    {
        movementY = jumpForce;
    }

    private void OnMove(InputValue movementValue)
    {
        movementX = movementValue.Get<float>() * acceleration;
    }

    private void FixedUpdate()
    {
        if (Math.Abs(rigidbody.velocity.x) < maxSpeed)
        {
            rigidbody.AddForce(new Vector2(movementX, movementY));
        }
        else
        {
            rigidbody.AddForce(new Vector2(0.0f, movementY));
        }

        movementY = 0;
    }
}
