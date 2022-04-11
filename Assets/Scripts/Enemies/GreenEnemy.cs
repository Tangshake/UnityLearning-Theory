using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenEnemy : Enemy
{
    protected override void Introduction()
    {
        Debug.Log($"Hello my name is: Green!");
    }

    private void OnDestroy()
    {
        GameManager.Instance.AddScore(EnemyScore);
    }
}
