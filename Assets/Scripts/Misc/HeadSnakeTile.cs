using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadSnakeTile : SnakeTile
{

    [SerializeField]
    private Snake snake;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Boundaries" || other.tag == "SnakeTile")
        {
            snake.GameOver();
            Debug.Log(name + "Lose");
        }
        else if (other.tag == "Food")
            snake.ResetFoodPos();
    }

}