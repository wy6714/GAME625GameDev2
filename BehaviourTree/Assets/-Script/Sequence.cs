using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sequence : Node
{
    public Sequence(string n) {
        name = n;
    }

    public override Status Process()
    {
        Status childstaus = children[currentChild].Process();
        if (childstaus == Status.RUNNING) return Status.RUNNING;
        if (childstaus == Status.FAILURE) return childstaus;
        currentChild++;//go next child

        if(currentChild >= children.Count)//if run out of children
        {
            currentChild = 0;
            return Status.SUCCESS;
        }

        return Status.RUNNING;
    }
}
