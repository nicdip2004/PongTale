using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{

    public KeyCode moveUp = KeyCode.W;
    public KeyCode moveDown = KeyCode.S;
    public float Speed = 10.0f;
    public float boundY = 2.25f;
    private Rigidbody2D rb2d;
    public Vector3 startPosition;
    public Animator animator;
    float verticalMove = 0f;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        var vel = rb2d.velocity;
        verticalMove = Input.GetAxisRaw("Vertical") * Speed;
        animator.SetFloat("speed", Mathf.Abs(verticalMove));

        if (Input.GetKey(moveUp))
        {
            vel.y = Speed;
        }
        else if (Input.GetKey(moveDown))
        {
            vel.y = -Speed;
        }
        else
        {
            vel.y = 0;
        }
        rb2d.velocity = vel;

        var pos = transform.position;
        if (pos.y > boundY)
        {
            pos.y = boundY;
        }
        else if (pos.y < -boundY)
        {
            pos.y = -boundY;
        }
        transform.position = pos;
    }

    public void Reset()
    {
        rb2d.velocity = Vector3.zero;
        transform.position = startPosition;
    }
}
