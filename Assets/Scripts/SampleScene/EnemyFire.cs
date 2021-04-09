using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFire : MonoBehaviour
{
    [SerializeField]
    float force = 0f;

    void Start()
    {
        GetComponent<Rigidbody2D>().AddForce(Vector2.down * force);
    }


}
