using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField]
    private Snake snake;
    [SerializeField]
    private FoodManager foodManager;
    [SerializeField]
    private RootController rootController;

    public void StartGame()
    {
        snake.gameObject.SetActive(true);
        foodManager.SetFoodFirstPos();
    }

    public void GameOver()
    {
        Debug.Log("GameOver");
        rootController.ChangeController(ControllerTypeEnum.GameOver);
    }

    public void ResetFoodPos()
    {
        foodManager.ResetFoodPos();
        snake.AddNewTile();
    }


    public List<Vector2> GetSnakeTilesPos()
    {
        return snake.GetSnakeTilesPos();
    }

}
