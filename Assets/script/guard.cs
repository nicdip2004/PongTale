using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class guard : MonoBehaviour
{
    public GameObject pointA;
    public GameObject pointB;
    private Rigidbody2D rb;
    private Animator animator;
    private Transform pointnow;
    public  float speed;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        pointnow = pointB.transform;
        animator.SetBool("isrunning", true);

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 point = pointnow.position - transform.position;
        if(pointnow == pointB.transform)
        {
            rb.velocity = new Vector2(speed, 0);
        }
        else
        {
            rb.velocity = new Vector2(-speed, 0);
        }

        if(Vector2.Distance(transform.position, pointnow.position) < 2f && pointnow == pointA.transform)
        {
            flip();
            Debug.Log("Nuker1");
            pointnow = pointB.transform;
        }
        if (Vector2.Distance(transform.position, pointnow.position) < 2f && pointnow == pointB.transform)
        {
            flip();
            Debug.Log("Nuker2");
            pointnow = pointA.transform;
        }
    }

    private void flip()
    {
        Vector3 localscale = transform.localScale;
        localscale.x *= -1;
        transform.localScale = localscale;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(pointB.transform.position, 0.5f);
        Gizmos.DrawWireSphere(pointA.transform.position, 0.5f);
        Gizmos.DrawLine(pointA.transform.position, pointB.transform.position);
    }
}
