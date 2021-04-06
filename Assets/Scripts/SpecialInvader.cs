using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialInvader : MonoBehaviour
{
    float time;     // time since start in seconds
    float Ptime;    // time since start in seconds

    float Position = 1f;    // position number <Movement Table>
    float MovUnit = 0.5f;   // unit of movement for each movement update

    [SerializeField]
    float UpdateTime;       // time for each movement update

    [SerializeField]
    int InvaderLife = 0;    // Special Invaders HP

    [SerializeField]
    GameObject EnemyFire;

    [SerializeField]
    float MinFireRate = 0f; // minimum time between each shot fired

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "FriendlyFire") // normal invaders have only 1 HP and are destroyed when hit by "friendly fire"
        {
            if(InvaderLife > 0)
            {
                Destroy(collision.gameObject);
                InvaderLife -= 1;
            }
            else
            {
                Destroy(collision.gameObject);
                Destroy(gameObject);
            }
        }
    }

    void Update()
    {
        //---------------------------code for invaders fire---------------------------//

        time += Time.deltaTime;

        float N = Random.Range(0f, 1f);

        if (time > MinFireRate)
        {
            if (N < 0.001f)
            {
                Instantiate(EnemyFire, transform.position, transform.rotation);
                time = 0f;
            }
        }

        //---------------------------code for invaders movement---------------------------//

        Ptime += Time.deltaTime;

        if (Ptime > 2f)
        {                                                           //  Movement Table  //      // Each invader starts in position 1.  //
            if (Position > 0f)                                      //  1   2   3   4   //      // Every 2 seconds there is an update to its position and the time is reset.    // 
            {                                                       //  -4  -3  -2  -1  //      // If an invader is in position 2 and there is an update, it will move one unit right (3).  //
                if (Position == 4)                                  //  1   2   3   4   //      // If an invader is in position 4 and there is an update, it will move 1 unit down (-1).    //
                {                                                   // -4   -3  -2  -1  //      // If an invader is in position -3 and there is an update, it will move 1 unit left (-4).   //
                    Position = -1f;
                    Ptime = 0f;
                    DownMovement();
                }
                else
                {
                    Position += 1;
                    Ptime = 0f;
                    RightMovement();
                }

            }
            else
            {
                if (Position == -4)
                {
                    Position = 1f;
                    Ptime = 0f;
                    DownMovement();
                }
                else
                {
                    Position -= 1;
                    Ptime = 0f;
                    LeftMovement();
                }
            }

        }
    }

    public void RightMovement()
    {
        Vector3 MoveRight = transform.position;
        MoveRight.x += MovUnit;
        transform.position = MoveRight;
    }

    public void LeftMovement()
    {
        Vector3 MoveLeft = transform.position;
        MoveLeft.x -= MovUnit;
        transform.position = MoveLeft;
    }

    public void DownMovement()
    {
        Vector3 MoveDown = transform.position;
        MoveDown.y -= MovUnit;
        transform.position = MoveDown;
    }
}


