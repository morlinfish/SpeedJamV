using System.Collections.Generic;

using UnityEngine;

public class PlayerMovement : MonoBehaviour

{

    public float MovementSpeed = 1;

    public float JumpForce = 1;

    private Rigidbody2D _rigidbody;

    public bool isGrounded = false;
    public bool onWall = false;

    void Start()

    {

        _rigidbody = GetComponent<Rigidbody2D>();

    }


    void Update()

    {

        var movement = Input.GetAxis("Horizontal");

        transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * MovementSpeed;

        if (Input.GetButtonDown("Jump"))

        {
            if (isGrounded == true)
            {
                _rigidbody.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
                isGrounded = false;
            }
            else if (onWall == true)
            {
                _rigidbody.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
            }

        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Safe")
        {
            isGrounded = true;
        }
    }
}
