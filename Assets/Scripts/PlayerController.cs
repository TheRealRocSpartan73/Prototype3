using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRB;
    public int jumpForce = 10;
    public float gravityModifier;
    public bool isOnGround = true;
    public bool gameOver = false;
    private Animator playerAnimation;
    // Start is called before the first frame update
    void Start()
    {
        //Once player class is created, obtain references to the player object 
        //Rigidbody and Animator components
        playerRB = GetComponent<Rigidbody>();
        playerAnimation=this.GetComponent<Animator>();
        
        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        //Check for space bar and make player jump
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround == true && !gameOver)
        {
            playerRB.AddForce(Vector3.up * jumpForce, ForceMode.Impulse); //Burst the impulse force.
            isOnGround = false;
            //Spacebar triggers the "Running Jump" animation
            playerAnimation.SetTrigger("Jump_trig");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        if(collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }else if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("***** GAME OVER MAN ******");
            gameOver = true;
            //play the death animation
            playerAnimation.SetInteger("DeathType_int", 1);
            playerAnimation.SetBool("Death_b", true);
        }

    }
}
