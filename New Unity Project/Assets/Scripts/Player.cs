using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //Declaring all needed global variables
    Vector3 startingSpot;
    Rigidbody2D rigidBody;
    int piecesCollected = 0;
    float speed = 3f;
    bool canJump;
    
   

    // Start is called before the first frame update
    void Start()
    {
        startingSpot = transform.position;
        rigidBody = GetComponent<Rigidbody2D>();
        canJump = true;
       
    }

    // Update is called once per frame
    void Update()
    {
        //Player movement
        var playerInput = Input.GetAxis("Horizontal");
        var movement = speed * playerInput;
        rigidBody.velocity = new Vector3(movement, rigidBody.velocity.y, 0);

        //Player jump
        if (Input.GetKeyDown(KeyCode.Space) && canJump == true)//Check if space is being pressed and canJump is true. canJump exists so that you cannot jump when not on the ground.
        {
            rigidBody.AddForce(new Vector3(0, 300, 0));
            canJump = false;
        }
        
        
    }

    //This is a method for collision. It allows us to detect the "type" of thing we collided with. Each object is assigned a tag representing their type,
    //and we choose how to handle the collision based on this type.
    void OnTriggerEnter2D(Collider2D collider)
    {
        var tag = collider.tag;
        switch (tag)
        {
            case "MachinePiece": //These are collectable items, so each time we collide with one it gets destroyed, and the counter for how many we have goes up by one
                piecesCollected++;
                Destroy(collider.gameObject);
                break;
            case "Obstacle": //Obstacles are anything that hurts the player, such as a spike. When we collide with one, we respawn at start.
                transform.position = startingSpot;
                break;
            case "End": //This is the "end" zone. Currently undetermined. 
                //I have no freaking clue yet
                break;
            case "Platform": //This is any sort of platform or ground. When we land on it, it resents our ability to jump to true. 
                canJump = true;
                break;

        }
    }
}
