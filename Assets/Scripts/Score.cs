using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Score : MonoBehaviour
{
    [SerializeField]
    Text Life;
    
    public void Hearts(int Nhearts) // Nhearts is transported from <SpaceShip> script
    {
        Life.text = "Hearts: " + Nhearts;   // text board <Life> displays <Nhearts>
    }
}
