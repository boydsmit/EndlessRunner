using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moving : MonoBehaviour {

    public float speed;
    public float jumpHeight;
    
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(speed, 0, 0 * Time.deltaTime);

        if (Input.GetKeyDown("space"))
        {
            print("Space pressed");
            
        }
    }
}
