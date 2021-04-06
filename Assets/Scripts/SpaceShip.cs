using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpaceShip : MonoBehaviour
{
    [SerializeField]
        GameObject Fire;
    [SerializeField]
        Transform nozzle;

    [SerializeField]
        float velocity = 0f;

    [SerializeField]
        Score Score;
    [SerializeField]
        int Nhearts = 0;    //Nhearts is the number of hearts the palyer has left      
    [SerializeField]
        Text Life;          //Text <Life> displays <Nhearts>

    float minX, maxX;
    float time;

    void Start()
    {
        minX = Camera.main.ViewportToWorldPoint(Vector2.zero).x + 0.3f;
        maxX = Camera.main.ViewportToWorldPoint(Vector2.one).x - 0.3f;
        Life.text = "Hearts: " + Nhearts;
    }

    public void OnCollisionEnter2D (Collision2D collision)
    {
        if(collision.gameObject.tag == "EnemyFire")
        {
            if (Nhearts > 1)    // player has <Nhearts> HP left
            {
                Nhearts -= 1;
                Destroy(collision.gameObject);
                Score.Hearts(Nhearts);
            }
            else                // player has no HP left
            {   
                Destroy(collision.gameObject);
                Destroy(gameObject);
                Life.text = "GAME OVER";
                //Reset Game
            }
        }
    }

    void Update()
    {
        time += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (time > 0.4f) // fire cooldown time
            {
                Instantiate(Fire,nozzle.position,nozzle.rotation);
                time = 0f;
            }
        }

        MoveShip(); 
    }

    void MoveShip()
    {
        float hMov = Input.GetAxis("Horizontal");                                       // hMov = [-1,1]
        transform.position += hMov * velocity * Vector3.right * Time.deltaTime;         // hMov = 1 -> move right   //  hMov = -2 -> move left  // hMov = 0 -> stactic

        Vector3 position = transform.position;
        position.x = Mathf.Clamp(position.x, minX, maxX);
        transform.position = position;
    }
}


