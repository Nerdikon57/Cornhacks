using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeSkipMovement : MonoBehaviour
{
    public int timeSkipCount;
    public bool inFuture;
    public GameObject camera1;
    public GameObject camera2;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {

        timeSkipCount = 0;
        inFuture = false;
    }

    // Update is called once per frame
    void Update()
    {
        //When Q is pressed, this teleports whatever object this script is attatched to up or down by 20 units depending on how many times it has been pressed so far.
        //This creates the effect of moving from present to future. This script is applied to the player and the main camera. 
        if (Input.GetKeyDown(KeyCode.Q) && timeSkipCount < 8)
        {
            timeSkipCount++;
            if (inFuture)
            {
                player.transform.position = new Vector3(transform.position.x, transform.position.y - 50, transform.position.z);
                camera1.SetActive(true);
                camera2.SetActive(false);
                inFuture = false;
            }
            else
            {
                player.transform.position = new Vector3(transform.position.x, transform.position.y + 50, transform.position.z);
                camera1.SetActive(false);
                camera2.SetActive(true);
                inFuture = true;
            }


        }


    }
}