using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    public int health = 3;
    public float moveSpeed;

    public GameObject explosion;
    public float enemyRange = 10f;
    public Rigidbody2D theRB;

    public bool shouldShoot;
    public float fireRate = .5f;
    private float shoutCounter;
    public GameObject bullet;
    public Transform firePoint;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(transform.position, PlayerController.instance.transform.position) < enemyRange)
        {
            Vector3 playerDirection = PlayerController.instance.transform.position - transform.position;

            theRB.velocity = playerDirection.normalized * moveSpeed;

            if(shouldShoot)
            {
                shoutCounter -= Time.deltaTime;
                if(shoutCounter <= 0)
                {
                    Instantiate(bullet, firePoint.position, firePoint.rotation);
                    shoutCounter = fireRate;
                    AudioController.instance.PlayEnemyShot();
                }
            }

        } else 
        {
            theRB.velocity = Vector2.zero;
        }
    }
    
    public void TakeDamage()
    {
        health--;
        if(health <= 0){
            Destroy(gameObject);
            AudioController.instance.PlayEnemyDeath();
            Instantiate(explosion, transform.position, transform.rotation);
        }
    }
}
