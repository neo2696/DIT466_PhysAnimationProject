using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMaster : MonoBehaviour
{
    public int points;
    public Text pointsText;
    public Text gameoverText;

    void Update()
    {

        pointsText.text = ("Points: " + points);
        gameoverText.text = pointsText.text;
    }
}
