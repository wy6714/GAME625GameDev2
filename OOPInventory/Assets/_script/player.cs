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
        Vector3 newPosition = transform.position + Vector3.back * moveSpeed * Time.deltaTime;
        transform.position = newPosition;
    }
}
