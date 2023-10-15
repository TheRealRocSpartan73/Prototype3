using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    private float speed = 20f;
    private PlayerController playerControllerScript;
    private float leftBoundary = -10f; //Left X Boundary of ground object
    // Start is called before the first frame update
    void Start()
    {
        //Obtain a reference to the actual c# script attached to our player
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerControllerScript.gameOver == false) //Only move background left if game is still active.
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }

        //Destroy obstacles if they move beyound the left x boundary
        if(this.transform.position.x < leftBoundary && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }
}
