using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsInteract : MonoBehaviour
{
    public GameObject visualsParent;
    bool hasTriggered;

    private void Awake()
    {
        //if we haven't assigned anything into the visuals parent slot, we can assume we want to hide the entire object
        if(visualsParent == null)
        {
            visualsParent = gameObject;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //we are assuming that only a player character will have the platformer controller script
        //if we were to change the script the player uses, we would need to create an updated if statement
        if (other.gameObject.GetComponent<PlatformerController>() && !hasTriggered)
        {
            visualsParent.gameObject.SetActive(false);
            hasTriggered = true;
            //we use the hasTriggered boolean to stop this script from executing all the time
            //Even though it probably wouldn't break, this is slightly more performant
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        print("Collision!");
        //we are assuming that only a player character will have the platformer controller script
        //if we were to change the script the player uses, we would need to create an updated if statement
        if (other.gameObject.tag == "Player" && !hasTriggered)
        {
            visualsParent.gameObject.SetActive(false);
            hasTriggered = true;
            //we use the hasTriggered boolean to stop this script from executing all the time
            //Even though it probably wouldn't break, this is slightly more performant
        }
    }
}
