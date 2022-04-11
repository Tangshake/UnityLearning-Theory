using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField]
    private SpawnManager spawnManager;

    [SerializeField]
    private Player player;

    private void Awake()
    {
        //Just simple singleton available within scene - thats all.
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (player.PlayerHealth < 0)
        {
            //Stop balls to spawn
            spawnManager.StopEnemySpawn();

            //Do the game over procedure :)
            GameOver();
        }
    }

    private void GameOver()
    {
        ExplodeRemainingBalls();
    }

    private void ExplodeRemainingBalls()
    {
        //lets retrieve all game object that are enemies
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        //Check if array exists and check if array contains at least one element.
        if(enemies != null && enemies.Length > 0)
        {
            Debug.Log("Destroy all enemies.");

            //Now we can iterate through all enemies and blow them up
            foreach(var enemy in enemies)
            {
                spawnManager.SpawnBallExplosionAt(enemy.transform.position);
                Destroy(enemy);
            }
        }
    }
}
