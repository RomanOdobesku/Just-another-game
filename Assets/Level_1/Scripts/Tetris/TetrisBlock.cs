using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TetrisBlock : MonoBehaviour
{
    private double previousTime;
    public static int height = 22;
    public static int width = 10;
    public Vector3 rotationPoint;
    public static Transform[,] grid = new Transform[width, height];
    SpawnerBlock Spawner;

    // Start is called before the first frame update
    void Start()
    {
        Spawner = GameObject.FindObjectOfType<SpawnerBlock>();
        previousTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.position += new Vector3(-1, 0, 0);
            if (!ValidMove())
            {
                transform.position -= new Vector3(-1, 0, 0);
            }
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.position += new Vector3(1, 0, 0);
            if (!ValidMove())
            {
                transform.position -= new Vector3(1, 0, 0);
            }
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            transform.RotateAround(transform.TransformPoint(rotationPoint), new Vector3(0, 0, 1), 90);
                if (!ValidMove())
                {
                    transform.RotateAround(transform.TransformPoint(rotationPoint), new Vector3(0, 0, 1), -90);
                }
        }

        if(Time.time - previousTime > (Input.GetKey(KeyCode.DownArrow)? Spawner.fallTime/10 : Spawner.fallTime))
        {
            transform.position += new Vector3(0, -1, 0);
            if (!ValidMove())
            {
                transform.position -= new Vector3(0, -1, 0);
                if (!GameOver())
                {
                    Spawner.game = 0;
                    this.enabled = false;
                }
                else if(Spawner.game != 0)
                {
                    AddToGrid();
                    CheckLines();
                    this.enabled = false;
                    FindObjectOfType<SpawnerBlock>().NewBlock();
                }
            }
            previousTime = Time.time;
        }
    }

    void CheckLines()
    {
        for(int i = height-1; i>= 0; i--)
        {
            if (Line(i))
            {
                DeleteLine(i);
                Spawner.point += 10;
                Spawner.predpoint += 10;
                Spawner.ChangeRecord = true;
                RowDown(i);
            }
        }

    }

    bool Line(int i)
    {
        for(int j = 0; j< width; j++)
        {
            if (grid[j, i] == null) return false;
        }
        return true;
    }

    void DeleteLine(int i)
    {
        for (int j = 0; j < width; j++)
        {
            Destroy(grid[j, i].gameObject);
            grid[j, i] = null;
        }
    }

    void RowDown(int i)
    {
        for (int k = i; k < height; k++)
        {
            for (int j = 0; j < width; j++)
            {
                if(grid[j,k] != null)
                {
                    grid[j, k - 1] = grid[j, k];
                    grid[j, k] = null;
                    grid[j, k - 1].transform.position += new Vector3(0, -1, 0);
                }
            }
        }
    }

    void AddToGrid()
    {
        foreach (Transform children in transform)
        {
            int roundedX = Mathf.RoundToInt(children.transform.position.x);
            int roundedY = Mathf.RoundToInt(children.transform.position.y);

            grid[roundedX, roundedY] = children;
        }

    }
    bool ValidMove()
    {
        foreach(Transform children in transform)
        {
            int roundedX = Mathf.RoundToInt(children.transform.position.x);
            int roundedY = Mathf.RoundToInt(children.transform.position.y);

            if( roundedX < 0 || roundedX >= width || roundedY < 0)
            {
                return false;
            }
            if (grid[roundedX, roundedY] != null) return false;
        }
        return true;
    }

    bool GameOver()
    {
        foreach (Transform children in transform)
        {
            int roundedX = Mathf.RoundToInt(children.transform.position.x);
            int roundedY = Mathf.RoundToInt(children.transform.position.y);
            if ( roundedY >= height-1)
            {
                return false;
            }
        }
        return true;
    }
    public void Clear()
    {
        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < width; j++)
            {
                grid[j, i] = null;
            }
        }
    }
}
