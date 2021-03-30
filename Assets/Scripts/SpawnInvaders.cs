using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnInvaders : MonoBehaviour
{
    [SerializeField]
    GameObject InvaderA;
    [SerializeField]
    GameObject InvaderB;
    [SerializeField]
    GameObject InvaderC;

    [SerializeField]
    int NInvaders = 0;   //number of Invaders per row
    [SerializeField]
    float InvadersY = 0; //height of Invaders A first row (determines the height of Invaders B & C rows)

    [SerializeField]
    GameObject[] Invaders; // ****indexed variable****

    [SerializeField]
    float DistanceBTW = 0; //Distance between each row of invaders

    private void Awake()
    {
        for (int line = 0; line < Invaders.Length; line++)
        {
            float xMin = -((NInvaders / 2f) - 1 / 2f);
            float x = xMin;
            float y = InvadersY;

            for (int i = 1; i <= NInvaders; i++)
            {
                GameObject newinvader = Instantiate(Invaders[line], transform);          //Instantiate: duplicates given gameobject in given position
                newinvader.transform.position = new Vector3(x, y, 0);
                x += 1f;
            }
            InvadersY = y + DistanceBTW;
        }
    } 
}

        
        
        


