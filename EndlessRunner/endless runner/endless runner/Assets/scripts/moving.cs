using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moving : MonoBehaviour {

    public Rigidbody rb;

    //private Vector3 moveDirection = Vector3.zero;

    //movement
    public float speed;

    public bool jump;

    //private CharacterController controller;

    //public bool jump = false;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
        //controller = GetComponent<CharacterController>();
    }

   void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            jump = true;
        }

    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            jump = false;
        }
    }

    // Update is called once per frame
    void Update()
    {

        rb.MovePosition(transform.position + transform.right * Time.deltaTime * speed);

        if (jump == true)
        {
            if (Input.GetButton("Jump"))
            {
                StartCoroutine("Jump");
            }
        }
        /* if (controller.isGrounded)
         {
             moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
             moveDirection = transform.TransformDirection(moveDirection);
             if (Input.GetButton("Jump") Input.GetKeyDown(KeyCode.Space)) 
             {
                 if (controller.isGrounded)
                 {
                     Debug.Log("Jump");
                     moveDirection.y = jumpspeed;
                 }
             }
             moveDirection.y -= gravity * Time.deltaTime * 5.5F;
             if (moveDirection.y == maxfallSpeed)
             {
                 moveDirection.y = maxfallSpeed;
             }
             controller.Move(moveDirection * Time.deltaTime);
             //transform.Translate(moveDirection * Time.deltaTime);
             //transform.position += moveDirection * Time.deltaTime; 
         }*/
    }
    private IEnumerator Jump()
    {
        float jumpSpeed = 15; 
        float maxHeight = 2 + this.transform.position.y;
        while (Input.GetButton("Jump") && this.transform.position.y < maxHeight)
        {
            jump = false;
            this.rb.velocity = new Vector3(0,  jumpSpeed);
            yield return null;
        }
        this.rb.velocity = new Vector3(0, 0);
        Debug.Log("end");
    }
}
