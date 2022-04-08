using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private string enemyName;   //Name of the enemy

    [SerializeField]
    private float moveSpeed;    //Move speed of the enemy

    [SerializeField]
    private float damageDone;   //Damage done by the enemy when it collides with player

    [SerializeField]
    private int hitsToDestroy;  //Hits needed to destroy the enemy

    [SerializeField]
    public Transform playerPosition; //Player is our target. This variable store his position

    private void Awake()
    {
        Introduction();
    }

    // Start is called before the first frame update
    void Start()
    {
        playerPosition = GameObject.Find("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        Move();
    }

    //This method move enemy. It is protected so it is visible to the classes that inherit it. It is also virtual so it can be overriden
    protected virtual void Move()
    {
        //Move enemy
        transform.Translate(Vector3.back * moveSpeed * Time.deltaTime);
    }

    protected virtual void Introduction()
    {
        Debug.Log($"Hello my name is: {enemyName}. My movement speed is {moveSpeed}. I deal {damageDone} and You need to hit me {hitsToDestroy} times to destroy me.");
    }
}
