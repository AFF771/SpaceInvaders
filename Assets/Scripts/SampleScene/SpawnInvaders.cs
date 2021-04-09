using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnInvaders : MonoBehaviour
{
    [SerializeField]
    int NInvaders = 0;   //number of Invaders per line
    [SerializeField]
    float InvadersY = 0; //height of Invaders A first row (determines the height of Invaders B & C rows)

    [SerializeField]
    GameObject[] SpecialInvaders;

    [SerializeField]
    GameObject[] Invaders; // ****indexed variable****

    [SerializeField]
    float DistanceBTW = 0; //Distance between each row of invaders

    private void Awake()
    {

        for (int line = 0; line < Invaders.Length; line++)  // Invaders.Length is the size of the indexed variable <Invaders>
        {
            float xMin = ((-((NInvaders / 2f) - 1 / 2f))-0.2f); // makes sure the horizontal distance between each invader is the same on each row
            float x = xMin;
            float y = InvadersY;

                for (int i = 1; i <= NInvaders; i++)
                {
                    float Prob = Random.Range(0f, 1f);
                    
                    if (Prob <= 0.1f)
                    {
                        GameObject SpecialInvader = Instantiate(SpecialInvaders[line], transform);          //Instantiate: duplicates given gameobject in given position
                        SpecialInvader.transform.position = new Vector3(x, y, 0);
                        x += 0.8f;
                    }
                    else
                    {
                        GameObject newinvader = Instantiate(Invaders[line], transform);          //Instantiate: duplicates given gameobject in given position
                        newinvader.transform.position = new Vector3(x, y, 0);
                        x += 0.8f;
                    }
                }
            InvadersY = y + DistanceBTW;
        }
    } 
}

        
        
        


