using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bot : MonoBehaviour
{
    public Transform ball;
    public Transform enemy;
    public float Speed = 10f;
    private Vector2 destination;
    public Animator animator;
    float verticalMove = 0f;

    public void MoveToBall()
    {
        destination = new Vector2(enemy.transform.position.x, ball.position.y);
        transform.position = Vector2.Lerp(enemy.transform.position, destination, Speed * Time.deltaTime);
    }

    void Update()
    {
        verticalMove = Input.GetAxisRaw("Vertical") * Speed;
        animator.SetFloat("speed", Mathf.Abs(verticalMove));

        MoveToBall();
    }
}