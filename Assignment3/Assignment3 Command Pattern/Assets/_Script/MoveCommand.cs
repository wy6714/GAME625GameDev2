using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCommand : Command
{
    private Transform PlayerTransform;
    private Vector3 originalPosition;
    private Vector3 newPosition;

    public MoveCommand(Transform playerTransform, Vector3 originalPosition, Vector3 newPosition)
    {
        this.PlayerTransform = playerTransform;
        this.originalPosition = originalPosition;
        this.newPosition = newPosition;
    }

    public override void Execute()
    {
        PlayerTransform.position = newPosition;
    }

    public override void Undo()
    {
        PlayerTransform.position = originalPosition;
    }
}
