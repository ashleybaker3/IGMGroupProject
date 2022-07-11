using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionSound : MonoBehaviour
{
    AudioSource source;
    public bool onlyPlayOnce;

    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider collision)
    {
        //if we detect a collision, and the object we collided with is the player
        //play the AudioSource 
        if (collision.gameObject.GetComponent<PlatformerController>() && onlyPlayOnce == true)
        {
            source.Play();
            Debug.Log("Played sound");
            onlyPlayOnce=false;
        }
    }
}
