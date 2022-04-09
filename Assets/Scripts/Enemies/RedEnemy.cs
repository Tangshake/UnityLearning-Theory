using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedEnemy : Enemy
{
    private float timeInterval = 3;
    private float currentTime = 0;
    private float moveX = 0;

    protected override void Introduction()
    {
        Debug.Log($"Hello my name is: Red!");
    }

    //I'm red enemy. I'm sneaky and I go towards the player.
    protected override void Move()
    {
        //When enemy gets closer to the enemy it starts to go towards him.
        float distance = Vector3.Distance(transform.position, target.position);
        if (distance <= 10.0f)
        {
            //ToDo: remove hardcoded value of speed!
            transform.position = Vector3.MoveTowards(transform.position, target.position, 10 * Time.deltaTime);
        }
        else
        {
            base.Move();
        }
    }


}
