using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRB;
    private AudioSource playerAudio;
    public int jumpForce = 10;
    public float gravityModifier;
    public bool isOnGround = true;
    public bool gameOver = false;
    private Animator playerAnimation;
    public ParticleSystem explosionParticle;
    public ParticleSystem dustParticle;
    public AudioClip jumpSound;
    public AudioClip crashSound;
    private AudioSource cameraAudio;
    // Start is called before the first frame update
    void Start()
    {
        //Once player class is created, obtain references to the player object 
        //Rigidbody and Animator components
        playerRB = this.GetComponent<Rigidbody>();
        playerAnimation=this.GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
        cameraAudio = GameObject.Find("Main Camera").GetComponent<AudioSource>();
        
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
            //Turn off dirt whilst jumping
            dustParticle.Stop();
            playerAudio.PlayOneShot(jumpSound, 1.0f); //Play jumpSound
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        if(collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            dustParticle.Play();
        }else if (collision.gameObject.CompareTag("Obstacle")) //Game Over State
        {
            Debug.Log("***** GAME OVER MAN ******");
            gameOver = true;
            //Play Crash sound
            
            //play the death animation and start explosion particle effect
            playerAnimation.SetInteger("DeathType_int", 1);
            playerAnimation.SetBool("Death_b", true);
            explosionParticle.Play();
            dustParticle.Stop();
            playerAudio.PlayOneShot(crashSound, 1.0f); //Play crashSound
            cameraAudio.Stop();//Stop the main tune
        }

    }
}
