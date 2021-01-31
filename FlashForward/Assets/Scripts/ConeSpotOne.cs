using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConeSpotOne : MonoBehaviour
{
    public GameObject platformOne;
    public GameObject platformTwo;
    public GameObject platformThree;
    public GameObject platformFour;
    public GameObject platformFive;
    public GameObject platformSix;
    public GameObject platformSeven;
    public GameObject platformEight;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        var tag = collider.tag;
        switch (tag)
        {

            case "Cone":
                platformOne.SetActive(false);
                platformTwo.SetActive(false);
                platformThree.SetActive(false);

                platformFour.SetActive(false);
                platformFive.SetActive(false);
                platformSix.SetActive(false);
                platformSeven.SetActive(false);
                platformEight.SetActive(false);
                
                break;
        }
    }
}
