using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodManager : MonoBehaviour
{

    public GameObject FoodPrefabGO;
    [SerializeField]
    private GameManager gameManager;
    private List<Vector2> SnakeTilesPos;

    public void SetFoodFirstPos()
    {
        FoodPrefabGO.SetActive(true);
        ResetFoodPos();
    }

    public void ResetFoodPos()
    {

        FoodPrefabGO.transform.position = GetAvailablePlaceForFood();
    }

    private Vector2 GetAvailablePlaceForFood()
    {
        SnakeTilesPos = gameManager.GetSnakeTilesPos();

        Vector2 RandomPos = new Vector2(Random.Range(-10, 10), Random.Range(-19, 19));

        while (!IsThisPosAvailable(RandomPos))
        {
            RandomPos = new Vector2(Random.Range(-10, 10), Random.Range(-19, 19));
        }

        return RandomPos;
    }

    private bool IsThisPosAvailable(Vector2 Pos)
    {
        for (int i = 0; i < SnakeTilesPos.Count; i++)
            if (SnakeTilesPos[i] == Pos)
                return false;
        return true;
    }

}