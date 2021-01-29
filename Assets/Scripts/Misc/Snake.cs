using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{

    [SerializeField]
    private SnakeTile snakeHeadTile, snakeTailTile;
    public Observable<Direction> currentDirection = new Observable<Direction>();
    private bool ChangeingDir;
    public GameObject snakeTilePrefabGO;
    [SerializeField]
    private GameManager gameManager;

    public RootController rootController;

    public void Start()
    {
        InvokeRepeating("MoveSnake", 0.15f, 0.15f);
        currentDirection.Changed += OnValueChanged;
        currentDirection.Value = Direction.Up;
    }

    private void OnValueChanged(object sender, Observable<Direction>.ChangedEventArgs e)
    {
        snakeHeadTile.Move(currentDirection.Value);
        ChangeingDir = true;
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.UpArrow) && currentDirection.Value != Direction.Down)
            currentDirection.Value = Direction.Up;
        else if (Input.GetKeyDown(KeyCode.DownArrow) && currentDirection.Value != Direction.Up)
            currentDirection.Value = Direction.Down;
        else if (Input.GetKeyDown(KeyCode.LeftArrow) && currentDirection.Value != Direction.Right)
            currentDirection.Value = Direction.Left;
        else if (Input.GetKeyDown(KeyCode.RightArrow) && currentDirection.Value != Direction.Left)
            currentDirection.Value = Direction.Right;
    }

    private void MoveSnake()
    {
        //Skipping move when change direction, there is a little difference between them
        if (ChangeingDir)
        {
            ChangeingDir = false;
            return;
        }
        snakeHeadTile.Move(currentDirection.Value);
    }

    public void AddNewTile()
    {

        GameObject NewTileGO = Instantiate(snakeTilePrefabGO, new Vector2(-50, -50), Quaternion.identity, transform);
        SnakeTile NewTailTile = NewTileGO.GetComponent<SnakeTile>();

        //First way using preloaded inspector objects
        // snakeTailTile.SetNext(NewTailTile);

        //Socend way using recursion and linked list to get tail tile
        snakeTailTile = GetTailTile(snakeHeadTile);
        snakeTailTile.SetNext(NewTailTile);

        snakeTailTile = NewTailTile;
    }

    private SnakeTile GetTailTile(SnakeTile snakeTile)
    {
        if (snakeTile.GetNext() == null)
            return snakeTile;
        else
            return GetTailTile(snakeTile.GetNext());
    }

    public void GameOver()
    {
        gameManager.GameOver();
        CancelInvoke();
    }

    public void ResetFoodPos()
    {
        gameManager.ResetFoodPos();
    }

    public List<Vector2> GetSnakeTilesPos()
    {
        List<Vector2> SnakeTilesPos = new List<Vector2>();
        SnakeTilesPos.Add(snakeHeadTile.GetPos());
        SnakeTilesPos.Add(snakeHeadTile.GetPos());

        SnakeTile CurrentSnakeTile = snakeHeadTile.GetNext();
        while (CurrentSnakeTile.GetNext() != null)
        {
            CurrentSnakeTile = CurrentSnakeTile.GetNext();
            SnakeTilesPos.Add(CurrentSnakeTile.GetPos());
        }


        return SnakeTilesPos;
    }

    void OnDestroy()
    {
        currentDirection.Changed -= OnValueChanged;
    }

}