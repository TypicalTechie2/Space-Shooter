using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    public float backgroundSpeed = 15;
    private Vector3 startPos;
    private float repeatHeight;
    private GameManager gameManagerScript;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        repeatHeight = GetComponent<BoxCollider>().size.y / 2;
        gameManagerScript = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        moveBackground();
    }

    void moveBackground()
    {
        if (gameManagerScript.isGameActive == true)
        {
            transform.Translate(Vector3.down * backgroundSpeed * Time.deltaTime);
        }

        if (transform.position.y < startPos.y - repeatHeight)
        {
            transform.position = startPos;
        }
    }
}
