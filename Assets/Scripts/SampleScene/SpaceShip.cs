using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SpaceShip : MonoBehaviour
{
    [SerializeField]
        GameObject Fire;
    [SerializeField]
        Transform nozzle;

    [SerializeField]
        float velocity = 0f;

    [SerializeField]
        int Nhearts = 0;    //Nhearts is the number of hearts the palyer has left      
    [SerializeField]
        Text Life;          //Text <Life> displays <Nhearts>

    [SerializeField]
    float cool;

    float minX, maxX;
    float firetime;
    float cooldowntime;

    bool cooldown = false;

    bool TimeTrue = false;

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
                Destroy(collision.gameObject);   
                
                if (cooldown == false)
                {
                    Nhearts -= 1;
                    Life.text = "Hearts: " + Nhearts;

                    Vector2 AuxPosition = transform.position;
                    AuxPosition.x = (minX + maxX) / 2;
                    transform.position = AuxPosition;

                    GetComponent<Rigidbody2D>().velocity = new Vector3 (0,0,0);
                    cooldown = true;
                    TimeTrue = true;
                }

            }
            else                // player has no HP left
            {   
                Destroy(collision.gameObject);

                if (cooldown == false)
                {
                    Destroy(gameObject);

                    //change scene
                    SceneManager.LoadScene("GameOver");
                }
            }
        }
    }

    void Update()
    {
        firetime += Time.deltaTime;

        cooldowntime += Time.deltaTime;

        if (cooldown == true)
        {
            if (TimeTrue == true) // cooldowntime is set to 0 on the first update cooldown==true
            {
                cooldowntime = 0f;
                TimeTrue = false;

            }

            if (cooldowntime > cool) 
            {
                cooldown = false;
            }
        }

        if (cooldown == false)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (firetime > 0.4f) // fire cooldown time
                {
                   Instantiate(Fire,nozzle.position,nozzle.rotation);
                    firetime = 0f;
                }
            }

            MoveShip(); 
        }

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


