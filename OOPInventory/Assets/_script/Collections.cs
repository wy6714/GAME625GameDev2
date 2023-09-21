using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Collections : Subject
{
    protected int point;
    protected int life;
}

public class Flower: Collections
{
    public static int point = 5;
    public static int life = 0;
}

