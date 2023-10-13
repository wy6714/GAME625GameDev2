using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player :MonoBehaviour
{
    

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            if (pos.z >= 20.9f)
            {
                pos.z = 20.9f;
            }
            else
            {
                pos.z = pos.z + 1.1f;
            }
            
            transform.position = pos;
        }
        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            if (pos.z <= 0)
            {
                pos.z = 0;
            }
            else
            {
                pos.z = pos.z - 1.1f;
            }
            
            transform.position = pos;
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            if (pos.x <= 0)
            {
                pos.x = 0;
            }
            else
            {
                pos.x = pos.x - 1.1f;
            }
            
            transform.position = pos;
        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            if (pos.x >= 20.9f)
            {
                pos.x = 20.9f;
            }
            else
            {
                pos.x = pos.x + 1.1f;
            }
            
            transform.position = pos;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.CompareTag("target"))
        {
            Destroy(other.gameObject);
            Debug.Log("collide with Target");
            
        }
    }
}
