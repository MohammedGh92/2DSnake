using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeTile : MonoBehaviour
{

    [SerializeField]
    private SnakeTile NextSnakeTile;
    private Vector2 currentPos;
    
    public void Move(Vector2 Pos)
    {
        if (NextSnakeTile != null)
            NextSnakeTile.Move(currentPos);
        currentPos = Pos;
        transform.position = currentPos;
    }

    public void SetNext(SnakeTile NextSnakeTile)
    {
        this.NextSnakeTile = NextSnakeTile;
    }

    public SnakeTile GetNext()
    {
        return NextSnakeTile;
    }

    public void Move(Direction direction)
    {
        if (direction == Direction.Up)
            Move(new Vector2(currentPos.x, currentPos.y + 1));
        else if (direction == Direction.Down)
            Move(new Vector2(currentPos.x, currentPos.y - 1));
        else if (direction == Direction.Left)
            Move(new Vector2(currentPos.x - 1, currentPos.y));
        else if (direction == Direction.Right)
            Move(new Vector2(currentPos.x + 1, currentPos.y));
    }

    public Vector2 GetPos()
    {
        return this.currentPos;
    }
}