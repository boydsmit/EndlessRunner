using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moving : MonoBehaviour {

    public Rigidbody rb;
    public float speed;
    public float jumpHeight;

    public bool jump = false;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
        
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
    void Update () {

        //transform.Translate(speed, 0, 0 * Time.deltaTime);

        rb.MovePosition(transform.position + transform.right * Time.deltaTime * speed );




        if (jump == true)
        {
            if (Input.GetKey(KeyCode.Space))
            {


                rb.AddForce(new Vector3(0, jumpHeight, 0), ForceMode.Impulse);
                
            }
        }
    }
}
