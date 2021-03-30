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
        float InvadersY = 0; //height of Invaders A row (determines the height of Invaders B & C rows)

        int NinvaderB;   //number of Invaders B
        float InvaderBy; //height of Invader B row

        int NinvaderC= 0;   //number of Invaders C
        float InvaderCy= 0; //height of Invaders C row

    [SerializeField]
        float DistanceBTW = 0; //Distance between each row of invaders

    private void Awake()
    {
        if (NInvaders < 9)
        { 
            float xMin = -((NInvaders / 2f) - 1/2f);
            float x = xMin;

                for (int i = 1; i <= NInvaders; i++)
                {GameObject newinvader = Instantiate(InvaderA, transform);          //Instantiate: duplicates given gameobject in given position
                newinvader.transform.position = new Vector3(x, InvadersY, 0);
                x += 1f;}

            NinvaderB = NInvaders;
            NinvaderC = NInvaders;
        }
        else
        {
            InvadersExcess(); // if NInvaders > 9 no invader will be displayed
        }

        if (NinvaderB < 9)
        {
        InvaderBy = InvadersY + DistanceBTW;
            float xMin = -((NinvaderB / 2f) - 1 / 2f);
            float x = xMin;

            for (int i = 1; i <= NinvaderB; i++)
            {GameObject newinvader = Instantiate(InvaderB, transform);
                newinvader.transform.position = new Vector3(x, InvaderBy, 0);
                x += 1f;}
        }
        else
        {
            InvadersExcess();
        }

        if (NinvaderC < 9)
        {
            InvaderCy = InvaderBy + DistanceBTW;
            float xMin = -((NinvaderC / 2f) - 1 / 2f);
            float x = xMin;

            for (int i = 1; i <= NinvaderC; i++)
            {GameObject newinvader = Instantiate(InvaderC, transform);
                newinvader.transform.position = new Vector3(x, InvaderCy, 0);
                x += 1f;}
        }
        else
        {
            InvadersExcess();
        }
    }

    void InvadersExcess()
    {
        Debug.Log("<N Invaders> must be lower than 9!");
    }
}
