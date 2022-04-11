using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float speed = 10.0f;

    [SerializeField]
    private int health = 20;

    [SerializeField]
    private float maxHealth = 20;

    [SerializeField]
    private GameObject bullet;

    [SerializeField]
    private Healthbar healthbar;

    [SerializeField]
    private AudioClip _playerHit;

    private float moveLimit = 14; //Positive and negative value

    private Transform pifpaf;

    private float horizontalInput;
    private bool isSpacePressed;

    // Start is called before the first frame update
    void Start()
    {
        pifpaf = GameObject.Find("pifpaf").transform;

        healthbar.UpdateHealthBar(maxHealth, health);
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        if(Input.GetKeyDown(KeyCode.Space))
        {
            isSpacePressed = true;
        }
    }

    private void FixedUpdate()
    {
        transform.Translate(Vector3.right * speed * horizontalInput * Time.deltaTime);

        if (transform.position.x <= -moveLimit)
            transform.position = new Vector3(-moveLimit, transform.position.y, transform.position.z);

        if(transform.position.x >= moveLimit)
            transform.position = new Vector3(moveLimit, transform.position.y, transform.position.z);

        if (isSpacePressed)
        {
            Fire();
        }
    }

    private void Fire()
    {
        isSpacePressed = false;
        Instantiate(bullet, pifpaf.position, pifpaf.rotation);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            health -= enemy.damageDone;
            
            healthbar.UpdateHealthBar(maxHealth, health);
            Debug.Log($"Current player health is {health}");

            SoundManager.Instance.PlaySound(_playerHit);
        }
    }


    public int PlayerHealth
    {
        get
        {
            return health;
        }
    }
}
