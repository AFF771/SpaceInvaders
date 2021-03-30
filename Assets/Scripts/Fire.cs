using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{

    [SerializeField]
    float force = 0f;

    [SerializeField]
    GameObject Paddle;

    float AddTime= 0f;
    float Cooldown = 0f;


    void Update()
    {
        AddTime = Time.deltaTime;
        Cooldown += AddTime;

        if (Cooldown > 1f)
        {
        GetComponent<Rigidbody2D>().AddForce(Vector2.up * force);
            Cooldown = 0f;
        }


    }
}
