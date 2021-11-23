using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb;
    int enemy = 0; 
    [SerializeField] float axisMovement = 4f;
    [SerializeField] float jumb = 3f;
    [SerializeField] Transform groundCheker;
    [SerializeField] LayerMask ground;
    [SerializeField] AudioSource jumpSound;
    [SerializeField] AudioSource enemyDeath;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {   
        // use input setting via project settings
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        rb.velocity = new Vector3(horizontalInput*axisMovement, rb.velocity.y, verticalInput*axisMovement);

        if (Input.GetKeyDown("space") && IsGrounded())
        {
            jump();
        }
    }
    void jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, jumb, rb.velocity.z);
        jumpSound.Play();
    }
    bool IsGrounded()
    {
        return Physics.CheckSphere(groundCheker.position, 0.1f, ground);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy Head"))
        {
            Destroy(collision.transform.parent.gameObject);
            enemyDeath.Play();
            jump();
            enemy++;

        }

    
    }
    
}
