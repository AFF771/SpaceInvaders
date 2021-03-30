using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShip : MonoBehaviour
{
    [SerializeField]
    float velocity = 0.5f;

    [SerializeField]
    KeyCode LeftKey = KeyCode.LeftArrow;

    [SerializeField]
    KeyCode RightKey = KeyCode.RightArrow;


    void Update()
    {
        if (Input.GetKey(LeftKey))
        {
            // x = x0 + v0 * (x,y,z) * t 
            transform.position += velocity * Vector3.left * Time.deltaTime;
        }

        else if (Input.GetKey(RightKey))
        {
            transform.position += velocity * Vector3.right * Time.deltaTime;
        }

        float camerawidth = Camera.main.orthographicSize + 1f;
        float halfSpaceship = 0.3f;

        // Clamp -> (value, min, max)
        Vector3 positionAux = transform.position;
        positionAux.x = Mathf.Clamp(transform.position.x,
                        -camerawidth + halfSpaceship,
                        camerawidth - halfSpaceship);
        transform.position = positionAux;
    }
}
