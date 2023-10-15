using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player :MonoBehaviour
{

    private CommandInvoker commandInvoker = new CommandInvoker();
    private Vector3 originalPosition;

    // Start is called before the first frame update
    void Start()
    {
        originalPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPosition = transform.position;
        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            if (newPosition.z >= 20.9f)
            {
                newPosition.z = 20.9f;
            }
            else
            {
                newPosition.z = newPosition.z + 1.1f;
                MoveCommand moveCommand = new MoveCommand(transform, transform.position, newPosition);
                commandInvoker.ExecuteCommand(moveCommand);
                
            }
        }
        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            if (newPosition.z <= 0)
            {
                newPosition.z = 0;
            }
            else
            {
                newPosition.z = newPosition.z - 1.1f;
                MoveCommand moveCommand = new MoveCommand(transform, transform.position, newPosition);
                commandInvoker.ExecuteCommand(moveCommand);
            }
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            if (newPosition.x <= 0)
            {
                newPosition.x = 0;
            }
            else
            {
                newPosition.x = newPosition.x - 1.1f;
                MoveCommand moveCommand = new MoveCommand(transform, transform.position, newPosition);
                commandInvoker.ExecuteCommand(moveCommand);
            }
        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            if (newPosition.x >= 20.9f)
            {
                newPosition.x = 20.9f;
            }
            else
            {
                newPosition.x = newPosition.x + 1.1f;
                MoveCommand moveCommand = new MoveCommand(transform, transform.position, newPosition);
                commandInvoker.ExecuteCommand(moveCommand);
            }
        }

        //Rewind
        if (Input.GetKeyUp(KeyCode.Z))
        {
            commandInvoker.UndoLastCommand();
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
