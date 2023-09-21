using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : Subject
{
    // Start is called before the first frame update
    private float moveSpeed = 50f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPosition = transform.position + Vector3.right * moveSpeed * Time.deltaTime;
        transform.position = newPosition;

        if(Input.GetKeyUp(KeyCode.UpArrow) && transform.position.z < 80)
        {
           
            transform.position += new Vector3(0f, 0f, 40f);
        }

        if (Input.GetKeyUp(KeyCode.DownArrow) && transform.position.z > 0 )
        {
            transform.position += new Vector3(0f, 0f, -40f);
        }
    }

    
}
