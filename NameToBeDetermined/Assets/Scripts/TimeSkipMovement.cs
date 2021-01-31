using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeSkipMovement : MonoBehaviour
{
    int timeSkipCount;


    // Start is called before the first frame update
    void Start()
    {
        timeSkipCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //When Q is pressed, this teleports whatever object this script is attatched to up or down by 20 units depending on how many times it has been pressed so far.
        //This creates the effect of moving from present to future. This script is applied to the player and the main camera. 
        if (Input.GetKeyDown(KeyCode.Q) && timeSkipCount < 5)
        {
            timeSkipCount++;
            if (timeSkipCount % 2 == 0)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y - 50, transform.position.z);
            }
            else
            {
                transform.position = new Vector3(transform.position.x, transform.position.y + 50, transform.position.z);
            }


        }
    }
}
