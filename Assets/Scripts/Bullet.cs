using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem hitExplosion;

    private float speed = 20.0f;
    private float destroyAtPosZ = 50;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        MoveBullet();
        if(transform.position.z > destroyAtPosZ)
        {
            Destroy(gameObject);
        }
    }

    private void MoveBullet()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            Instantiate(hitExplosion, transform.position, Quaternion.identity);
        }
    }
}
