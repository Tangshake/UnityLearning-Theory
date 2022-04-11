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
    public int damageDone;   //Damage done by the enemy when it collides with player

    [SerializeField]
    private int hitsToDestroy;  //Hits needed to destroy the enemy

    [SerializeField]
    public Transform target; //Player is our target. This variable store his position

    [SerializeField]
    private int destroyPositionZ = -50;

    protected virtual int EnemyScore => 1;
        

    public int currentHit = 0;

    private void Awake()
    {
        Introduction();
    }

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        Move();
        DestroyEnemy();
    }

    private void DestroyEnemy()
    {
        //Destroy the enemy if he goes behind the player
        if(transform.position.z < destroyPositionZ)
        {
            Destroy(gameObject);
        }
        
        if(currentHit >= hitsToDestroy)
        {
            Destroy(gameObject);
        }
    }

    //This method move enemy. It is protected so it is visible to the classes that inherit it. It is also virtual so it can be overriden
    protected virtual void Move()
    {
        //Move enemy
        transform.Translate(Vector3.back * moveSpeed * Time.deltaTime, Space.World);
    }

    protected virtual void Introduction()
    {
        Debug.Log($"Hello my name is: {enemyName}. My movement speed is {moveSpeed}. I deal {damageDone} and You need to hit me {hitsToDestroy} times to destroy me.");
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name.Equals("Player"))
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);
        if (other.gameObject.CompareTag("Bullet"))
        {
            currentHit++;
        }
    }
}
