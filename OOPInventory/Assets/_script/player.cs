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
        Vector3 newPosition = transform.position + Vector3.forward * moveSpeed * Time.deltaTime;
        transform.position = newPosition;

        if(Input.GetKeyUp(KeyCode.LeftArrow) && transform.position.x > -40)
        {
           
            transform.position += new Vector3(-40f, 0f, 0f);
        }

        if (Input.GetKeyUp(KeyCode.RightArrow) && transform.position.x < 40 )
        {
            transform.position += new Vector3(40f, 0f, 0f);
        }
    }

    
}
