using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandInvoker 
{
    private Stack<Command> moveHistory = new Stack<Command>();

    public void ExecuteCommand(Command command)
    {
        command.Execute();
        moveHistory.Push(command);
    }

    public void UndoLastCommand()
    {
        if (moveHistory.Count > 0)
        {
            Command lastCommand = moveHistory.Pop(); 
            lastCommand.Undo();
        }
        else
        {
            Debug.Log("You are in the first step!");
        }
    }
}
