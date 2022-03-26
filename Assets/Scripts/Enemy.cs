using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Enemy Stats")]
    [SerializeField] float health = 100;
    [SerializeField] int scoreValue = 150;
    [Header("Shooting at player")]
    [SerializeField] float shotCounter;
    [SerializeField] float minTimeBetweenShots = 0.2f;
    [SerializeField] float maxTimeBetweenShots = 3f;
    [SerializeField] GameObject projectile;
    [SerializeField] float projectileSpeed = 5.0f;

    [Header("Visual Effects")]
    [SerializeField] GameObject deathVFX;
    [SerializeField] float durationOfExplosion;

    [Header("Sounds")]
    [SerializeField]AudioSource myass;
    [SerializeField] float vol = 1f;
    [SerializeField] AudioClip shootingsound;
    [SerializeField] AudioClip dyingsound;
    [SerializeField] float soundDeathDelay = 0.1f;


    // Start is called before the first frame update
    void Start()
    {
        shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
        myass.GetComponent<AudioSource>();
    }

    private void CountDownAndShoot()
    {
        shotCounter -= Time.deltaTime;
        if (shotCounter <= 0f)
        {
            Fire();
            shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
    
        }
    }

    private void Fire()
    {
        GameObject laser = Instantiate(projectile, transform.position, Quaternion.identity) as GameObject;
        laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -projectileSpeed);
        AudioSource.PlayClipAtPoint(dyingsound, Camera.main.transform.position, vol);
    }

    // Update is called once per frame
    void Update()
    {
        CountDownAndShoot();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        DamageDealer dd = other.gameObject.GetComponent<DamageDealer>();
        dealingDamage(dd);
    }

    private void dealingDamage(DamageDealer dd)
    {
        health -= dd.GetDamage();
        dd.hit();
        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        FindObjectOfType<GameManager>().AddToScore(scoreValue);
        Destroy(gameObject);
        GameObject explosion = Instantiate(deathVFX, transform.position, transform.rotation);
        Destroy(explosion, durationOfExplosion);
        AudioSource.PlayClipAtPoint(dyingsound, Camera.main.transform.position, vol);
    }

    private void KillingOffEnemy()
    {
    }

}
