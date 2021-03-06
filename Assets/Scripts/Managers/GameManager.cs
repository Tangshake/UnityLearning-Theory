using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField]
    private SpawnManager spawnManager;

    [SerializeField]
    private Player player;

    [SerializeField]
    private TMPro.TMP_Text scoreText;

    [SerializeField]
    private AudioClip _gameOver;

    private GameObject gameOverObject;

    private bool isGameOver;
    private int _score;

    private void Awake()
    {
        //Just simple singleton available within scene - thats all.
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        isGameOver = false;

        gameOverObject = GameObject.FindObjectsOfType<GameObject>(true).Where(o => o.name.Equals("GameOver")).FirstOrDefault();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.PlayerHealth <= 0 && !isGameOver)
        {
            isGameOver = true;

            //Stop balls to spawn
            spawnManager.StopEnemySpawn();

            //Do the game over procedure :)
            GameOver();
        }
    }

    public void RestartGame()
    {
        _score = 0;
        isGameOver = false;
        player.ResetPlayer();
        gameOverObject.SetActive(false);
        spawnManager.StartEnemySpawn();
        RefreshScoreText();
    }

    private void GameOver()
    {
        ExplodeRemainingBalls();

        SoundManager.Instance.PlaySound(_gameOver);

        gameOverObject.SetActive(true);
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

    public void AddScore(int value)
    {
        _score += value;
        RefreshScoreText();
    }

    private void RefreshScoreText()
    {
        scoreText.text = _score.ToString();
    }
}
