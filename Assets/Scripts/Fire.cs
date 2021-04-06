using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    [SerializeField]
    float force = 0f;

    void Start()
    {
        GetComponent<Rigidbody2D>().AddForce(Vector2.up * force);   // activated when <Fire> instantiated
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "EnemyFire")
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }
}
