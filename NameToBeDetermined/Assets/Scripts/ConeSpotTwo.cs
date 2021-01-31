using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConeSpotTwo : MonoBehaviour
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
                platformOne.SetActive(true);
                platformTwo.SetActive(true);
                platformThree.SetActive(true);

                platformFour.SetActive(true);
                platformFive.SetActive(true);
                platformSix.SetActive(true);
                platformSeven.SetActive(true);
                platformEight.SetActive(true);

                break;
        }
    }
}
