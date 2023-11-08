using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selector : Node
{
    public Selector(string n)
    {
        name = n;
    }
    //run 1st child, if fails, not return fails, go next, keep go, until end
    public override Status Process()
    {
        Status childstaus = children[currentChild].Process();
        if (childstaus == Status.RUNNING) return Status.RUNNING;
        if (childstaus == Status.SUCCESS)
        {
            currentChild = 0;
            return Status.SUCCESS;
        }
        currentChild++;
        if (currentChild >= children.Count)
        {
            currentChild = 0;
            return Status.FAILURE;
        }

        return Status.RUNNING;
    }
}
