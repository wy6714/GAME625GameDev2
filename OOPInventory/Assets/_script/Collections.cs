using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public abstract class Collections :MonoBehaviour
{
    protected int point;
    protected int life;
}

public class Flower: Collections
{
    public static int point = 5;
    public static int life = 0;
}

public class Trash: Collections
{
    public static int point = 0;
    public static int life = -1;
}
public class Star : Collections
{
    public static int point = 10;
    public static int life  = 1;
}







