using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    public Vector3 jump;
    public float jumpForce = 9.0f;
    public bool isGrounded=false;

    public Rigidbody rb; // es una variable de tipo rigidbody y como tal le puedo poner el nombre que quiera...
    public float horizontalInput;
    public float verticalInput;
    public float speed = 10.0f;

    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 2.0f, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        Vector3 m_Input = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        rb.MovePosition(transform.position + m_Input * Time.deltaTime * speed);
        if (horizontalInput != 0.0f || verticalInput != 0.0f)
        {
        animator.SetBool("IsRunning", true);

        }
        else
        {
             animator.SetBool("IsRunning", false);
        }

        if (animator.GetBool("IsRunning")==true && Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
             
             animator.SetBool("jumprun", true);
            
        }
        else
        {
        animator.SetBool("jumprun", false);

        }

        if(Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {

          rb.velocity += jumpForce * Vector3.up;
           
        }

         if (Input.GetKeyDown("e"))
        {
            animator.SetTrigger("IsAttacking");
        }
    }

       void OnCollisionEnter(Collision other)
 {
     if (other.gameObject.tag == "Ground")
     {
        isGrounded = true;
        animator.SetBool("IsJumping", false);
     }
 }
 
 void OnCollisionExit(Collision other)
 {
     if (other.gameObject.tag == "Ground")
     {
         isGrounded = false;
         animator.SetBool("IsJumping", true);

     }

}}