using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResponseSystem : MonoBehaviour, IObserver
{
    [SerializeField] Subject subject;

    public void OnNotify(Actions action)
    {
        //observer response controll...
    }

    public void OnEnable()
    {
        subject.AddObserver(this);
    }

    public void OnDisable()
    {
        subject.RemoveObserver(this);
    }
}
