using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 10f;
    private float minSpawnInterval = 1f;
    private float maxSpawnInterval = 2f;
    public GameObject projectilePrefab;
    public int pointValueOnDestroy;
    private GameManager gameManagerScript;

    // Start is called before the first frame update
    void Start()
    {
        gameManagerScript = GameObject.Find("Game Manager").GetComponent<GameManager>();
        StartCoroutine("SpawnBullets");
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);

        if (transform.position.y < -10)
        {
            Destroy(gameObject);
        }
    }

    IEnumerator SpawnBullets()
    {
        while (gameManagerScript.isGameActive)
        {
            float spawnInterval = Random.Range(minSpawnInterval, maxSpawnInterval);
            yield return new WaitForSeconds(spawnInterval);
            Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
        }
    }
}
