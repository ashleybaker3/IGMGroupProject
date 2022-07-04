using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    SpriteRenderer mainSprite;
    Animator animator;
    Rigidbody rigidBody;
    // Start is called before the first frame update
    void Start()
    {
        mainSprite = GetComponentInChildren<SpriteRenderer>();
        animator = mainSprite.GetComponent<Animator>();
        rigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // update the speed and isjumping values in the animator based on the player's speed in the x-axis, and whether their y-velocity isn't 0 
        animator.SetFloat("Speed", Mathf.Abs(rigidBody.velocity.x));
        animator.SetBool("IsJumping", rigidBody.velocity.y > 0.2);

        // if the player is moving
        if (rigidBody.velocity.sqrMagnitude > 0.01)
        {
            //if the player is moving right, don't flip the sprite
            if (rigidBody.velocity.x > 0)
            {
                mainSprite.flipX = false;
            }
            else if (rigidBody.velocity.x < 0)
            {
                //if the player is moving left, flip the sprite
                mainSprite.flipX = true;
            }
        }
    }
}