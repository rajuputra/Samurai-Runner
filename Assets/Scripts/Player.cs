using System.Collections;
using System.Collections.Generic;
using UnityEditor.VisionOS;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5f;
    public float acceleration = 0.1f;
    private Rigidbody2D rb;
    public float jumpHeight = 7f;
    private bool isGround = true;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        anim = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();

        if (Input.GetKeyDown(KeyCode.Space) && isGround)
        {
            Jump();
            anim.SetBool("jump", true);
            isGround = false;
        }
    }

    void Move()
    {
        speed += acceleration * Time.deltaTime;
        transform.Translate(new Vector2(1f, 0f) * speed * Time.deltaTime);
    }

    void Jump()
    {
        Vector2 velocity = rb.velocity;
        velocity.y = jumpHeight;
        rb.velocity = velocity;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            isGround = true;
            anim.SetBool("jump", false);
        }
    }
}