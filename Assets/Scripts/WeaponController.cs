using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public float speed = 30f;
    private float topBoundary = 25;
    private float bottomBoundary = -15;
    public bool isPlayerBullet;
    private GameManager gameManagerScript;
    private Enemy enemyScript;
    public ParticleSystem explosionParticle;
    public AudioClip crashSound;
    public AudioClip gameOverAudio;

    // Start is called before the first frame update
    void Start()
    {
        gameManagerScript = GameObject.Find("Game Manager").GetComponent<GameManager>();
        enemyScript = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Enemy>();
    }

    // Update is called once per frame
    void Update()
    {
        ProjectileMovement();
        ProjectileYBoundary();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy") && isPlayerBullet)
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
            gameManagerScript.UpdateScore(enemyScript.pointValueOnDestroy);
            Instantiate(explosionParticle, other.transform.position, Quaternion.identity);
            AudioSource.PlayClipAtPoint(crashSound, other.transform.position);
        }

        else if (other.gameObject.CompareTag("Player") && !isPlayerBullet)
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
            gameManagerScript.isGameActive = false;
            gameManagerScript.GameOver();
            explosionParticle.Play();
            Instantiate(explosionParticle, other.transform.position, Quaternion.identity);
            AudioSource.PlayClipAtPoint(gameOverAudio, other.transform.position);
        }
    }

    private void ProjectileMovement()
    {
        if (gameObject.CompareTag("Player Projectile"))
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime, Space.World);
        }

        if (gameObject.CompareTag("Enemy Projectile"))
        {
            transform.Translate(Vector3.down * speed * Time.deltaTime, Space.World);
        }
    }

    private void ProjectileYBoundary()
    {
        if (gameObject.CompareTag("Player Projectile") && transform.position.y > topBoundary)
        {
            Destroy(gameObject);
        }

        if (gameObject.CompareTag("Enemy Projectile") && transform.position.y < bottomBoundary)
        {
            Destroy(gameObject);
        }
    }
}
