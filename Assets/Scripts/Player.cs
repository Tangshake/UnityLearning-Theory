using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float speed = 10.0f;

    [SerializeField]
    private int health = 100;

    [SerializeField]
    private GameObject bullet;

    private Transform pifpaf;

    private float horizontalInput;
    private bool isSpacePressed;

    // Start is called before the first frame update
    void Start()
    {
        pifpaf = GameObject.Find("pifpaf").transform;
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

        if(isSpacePressed)
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

            Debug.Log($"Current player health is {health}");
        }
    }
}
