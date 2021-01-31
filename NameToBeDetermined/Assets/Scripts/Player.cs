using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    //Declaring all needed global variables
    Vector3 startingSpot;
    Rigidbody2D rigidBody;
    int piecesCollected = 0;
    float speed = 1.3f;
    bool inAir;
    public Animator lydiaAnimator;
    public Transform dropPoint;
    public GameObject conePrefab;
    bool canDrop = true;
    int coneCollisionCounter;

    // Start is called before the first frame update
    void Start()
    {
        startingSpot = transform.position;
        rigidBody = GetComponent<Rigidbody2D>();
        inAir = false;
       
    }

    // Update is called once per frame
    void Update()
    {
        //Player movement
        var playerInput = Input.GetAxis("Horizontal");
        var movement = speed * playerInput;
        rigidBody.velocity = new Vector3(movement, rigidBody.velocity.y, 0);

        //Changes sprite from idle to running animation
        lydiaAnimator.SetFloat("Speed", Mathf.Abs(movement));

        //Changes direction of sprite to face right
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (transform.rotation != Quaternion.Euler(0, 0, 0))
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
        }

        //Changes direction of sprite to face left
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (transform.rotation != Quaternion.Euler(0, 180, 0))
            {
                transform.rotation = Quaternion.Euler(0, 180, 0);
            }
        }
       
       

        //Player jump
        if (Input.GetKeyDown(KeyCode.Space) && inAir == false)//Check if space is being pressed and inAir is true. inAir exists so that you cannot jump when in the air.
        {
            rigidBody.AddForce(new Vector3(0, 220, 0));
            inAir = true;
        }

        if (Input.GetKeyDown(KeyCode.R) && canDrop == true)
        {
            Instantiate(conePrefab, dropPoint.position, dropPoint.rotation);
            canDrop = false;
            coneCollisionCounter = 0;
        }
        

    }

    //This is a method for collision. It allows us to detect the "type" of thing we collided with. Each object is assigned a tag representing their type,
    //and we choose how to handle the collision based on this type.
    void OnTriggerEnter2D(Collider2D collider)
    {
        var tag = collider.tag;
        switch (tag)
        {
            case "Paper": //These are collectable items, so each time we collide with one it gets destroyed, and the counter for how many we have goes up by one
                inAir = false;
                piecesCollected++;
                Destroy(collider.gameObject);
                break;
            case "Obstacle": //Obstacles are anything that hurts the player, such as a spike. When we collide with one, we respawn at start.
                transform.position = startingSpot;
                break;
            case "End": //This is the "end" zone. Currently undetermined. 
                if (piecesCollected > 3)
                {
                    SceneManager.LoadScene(0);
                }
                
                break;
            case "Platform": //This is any sort of platform or ground. When we land on it, we are no longer in air. 
                inAir = false;
                break;
            case "Cone":
                if (coneCollisionCounter > 0) { 
                Destroy(collider.gameObject);
                canDrop = true;

        }
                coneCollisionCounter++;
                break;
        }
    }
 
}
