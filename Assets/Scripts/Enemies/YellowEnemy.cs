using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowEnemy : Enemy
{
    protected override void Introduction()
    {
        Debug.Log($"Hello my name is: Yellow!");
    }
}
