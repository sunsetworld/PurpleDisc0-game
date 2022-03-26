using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [Header("Player Movement")]
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float padding = 1f;
    [Header("Projectile")]
    [SerializeField] GameObject pP;
    [SerializeField] float projectileSpeed = 5f;
    [SerializeField] float projectileMovingSpeed = 0.1f;
    Coroutine firingCoroutine;
    [Header("Player Health")]
    [SerializeField] float health = 200;
    [Header("Game Sounds")]
    [SerializeField]AudioSource myAS;
    [SerializeField] float SoundVolume = 1f;
    [SerializeField] AudioClip deathClip;
    [SerializeField] AudioClip soundClip;
    [SerializeField] Levels lvls;


    float xMin;
    float xMax;
    float yMin;
    float yMax;




    // Start is called before the first frame update
    void Start()
    {
        SetupMoveBoundaries();
        StartCoroutine(printToTheUnityConsole());
        myAS.GetComponent<AudioSource>();
        lvls.GetComponent<Levels>();
    }

    void SetupMoveBoundaries()
    {
        Camera gameCamera = Camera.main;
        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + padding;
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - padding;
        yMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + padding;
        yMax = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - padding;
    }

    // Update is called once per frame
    void Update()
    {
        move();
        Fire();
    }

    private void move()
    {
        float deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        float deltaY = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;
        var newXpos = Mathf.Clamp(transform.position.x + deltaX, xMin, xMax);
        var newYpos = Mathf.Clamp(transform.position.y + deltaY, yMin, yMax);
        transform.position = new Vector2(newXpos, newYpos);
    }

    void Fire()
    {
        if (Input.GetButtonDown("Fire1"))
        {
           firingCoroutine = StartCoroutine(shootingBullets());
        }
        if (Input.GetButtonUp("Fire1"))
        {
            StopCoroutine(firingCoroutine);
        }
    }

    IEnumerator printToTheUnityConsole()
    {
        Debug.Log("This should do something");
        yield return new WaitForSeconds(3);
        Debug.Log("This should do something else");
    }

    IEnumerator shootingBullets()
    {
        while (true)
        {
            GameObject laser = Instantiate(pP, transform.position, Quaternion.identity) as GameObject;
            laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, projectileSpeed);
            AudioSource.PlayClipAtPoint(soundClip, Camera.main.transform.position, SoundVolume);
            yield return new WaitForSeconds(projectileMovingSpeed);
        }


    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        DamageDealer dd = other.gameObject.GetComponent<DamageDealer>();

        if (!dd) { return;  }
        dealingDamage(dd);
    }

    private void dealingDamage(DamageDealer dd)
    {
        health -= dd.GetDamage();
        dd.hit();
        if (health <= 0)
        {
            AudioSource.PlayClipAtPoint(deathClip, Camera.main.transform.position, SoundVolume);
            Destroy(gameObject);
            loadGameOver();
        }
    }

    private void loadGameOver()
    {
        lvls.loadGameOver();
    }

    public float GetHealth()
    {
        return health;
    }

}
