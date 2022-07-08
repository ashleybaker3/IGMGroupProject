using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformerController : MonoBehaviour
{

    //Speed of character movement and height of the jump. Set these values in the inspector.
    public float speed;
    public float jumpHeight;
    private float timer = 40;
    public bool slowingPlayer;
    public float timeScaleLevel;

    //Assigning a variable where we'll store the Rigidbody component.
    private Rigidbody rb;

    private bool onGround;
    private bool canJump;
    private float percentTimeLeft = 1;


    // Start is called before the first frame update
    void Start()
    {
        //Sets our variable 'rb' to the Rigidbody component on the game object where this script is attached.
        rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        SlowingOverTime(speed, jumpHeight, timer, percentTimeLeft);


        //Check if the player is on the ground. If we are, then we are able to jump.
        if (onGround == true)
        {
            canJump = true;
        }
        //If we're able to jump and the player has pressed the space bar, then we jump!
        if (Input.GetKeyDown(KeyCode.Space) && canJump == true)
        {
            rb.velocity = Vector2.up * jumpHeight;
            canJump = false;
        }


        //Movement code for left and right arrow keys.
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
            if (Input.GetKey(KeyCode.LeftShift))
            {
                rb.velocity = new Vector2(-speed*2, rb.velocity.y);
                print(true);
            }
        }

        else if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.velocity = new Vector2(+speed, rb.velocity.y);
            if (Input.GetKey(KeyCode.LeftShift))
            {
                rb.velocity = new Vector2(+speed*2, rb.velocity.y);
                print(true);
            }
        }
        //ELSE if we're not pressing an arrow key, our velocity is 0 along the X axis, and whatever the Y velocity is (determined by jump)
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        //If we collide with an object tagged "ground" then our jump resets and we can now jump.
        if (collision.gameObject.tag == "ground")
        {
            onGround = true;
            print(onGround);
            //print statements print to the Console panel in Unity. 
            //This will print the value of onGround, which is a boolean, so either True or False.
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        //If we exit our collision with the "ground" object, then we are unable to jump.
        if (collision.gameObject.tag == "ground")
        {
            onGround = false;
            print(onGround);
        }
    }

    private void SlowingOverTime(float speed, float jumpHeight, float timer, float percentTimeLeft)
    {
        float fullTimer = timer;
    //     while(slowingPlayer)
    //     {
    //         timer-= 0.01f;
    //         print(timer);
    //         percentTimeLeft = timer/fullTimer;
    //         speed *= percentTimeLeft;
    //         jumpHeight *= percentTimeLeft;
    //         if(timer<=0)
    //         {
    //             slowingPlayer=false;
    //             print("Timer at 0");
    //             print(fullTimer);
    //         }
    //     }

        if(slowingPlayer)
        {
            for (int i = 0; i < fullTimer; i++)
            {
                StartCoroutine(Wait());
                timer-=0.5f;
                percentTimeLeft = timer/fullTimer;
                speed *= percentTimeLeft;
                jumpHeight *= percentTimeLeft;
                print(timer);
            }
        }

        slowingPlayer = false;

    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.5f);
    }

    // private void TimeScaleSlowMethod()
    // {
    //     while(slowingPlayer)
    //     {

    //     }
    // }
}
