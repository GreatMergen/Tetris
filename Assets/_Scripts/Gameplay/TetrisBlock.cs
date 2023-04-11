using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TetrisBlock : MonoBehaviour
{
  
    public Vector3 rotationPoint;
    private float _previousTime;
    public float fallTime = 0.8f;
    public static int Height = 20;
    public static int Width = 10;
    private static Transform[,] grid = new Transform[Width, Height];
    private void Start()
    {
        
    }

   
   private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.position += new Vector3(-1, 0, 0);
            if (!ValidMove())
            {
                transform.position -= new Vector3(-1, 0, 0);
            }
        }
        else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.position += new Vector3(1, 0, 0);
            if (!ValidMove())
            {
                transform.position -= new Vector3(1, 0, 0);
            }
        }
        
        else if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            //rotation
            transform.RotateAround(transform.TransformPoint(rotationPoint) ,new Vector3(0,0,1),90);
            if (!ValidMove())
            {
                transform.RotateAround(transform.TransformPoint(rotationPoint),new Vector3(0,0,1),-90);
            }
        }

        if (Time.time - _previousTime > (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow) ? fallTime /10 :  fallTime))
        {
            transform.position += new Vector3(0, -1, 0);
            if (!ValidMove())
            {
                transform.position -= new Vector3(0, -1, 0);
                AddToGrid();
                CheckForLines();
                this.enabled = false;
                Spawner.Instance.SpawnNewBlock();
            }
            _previousTime = Time.time;
        }
    }
   
   
   private void CheckForLines()
   {
       for (int i = Height -1; i>= 0; i--)
       {
           if (HasLine(i))
           {
               DeleteLine(i);
               RowDown(i);
           }
       }
   }
   
   private bool HasLine(int i)
   {
       for (int j = 0; j < Width; j++)
       {
           if (grid[j, i] == null) 
               return false;
       }
       return true;
   }
   private void DeleteLine(int i)
   {
       for (int j = 0; j < Width; j++)
       {
          Destroy(grid[j,i].gameObject);
          grid[j, i] = null;
       }
   }
   private void RowDown(int i)
   {
       for (int y = i; y < Height; y++)
       {
           for (int j = 0; j < Width; j++)
           {
               if (grid[j, y] != null)
               {
                   grid[j, y - 1] = grid[j, y];
                   grid[j, y ]= null;
                   grid[j, y - 1].transform.position -= new Vector3(0, 1, 0);
               }
           }
       }
   }
   private void AddToGrid()
   {
       foreach (Transform children in transform)
       {
           var roundedX = Mathf.RoundToInt(children.transform.position.x);
           var roundedY = Mathf.RoundToInt(children.transform.position.y);

           grid[roundedX, roundedY] = children;
       }
   }

   
   private bool ValidMove()
   {
       foreach (Transform children in transform)
       {
           var roundedX = Mathf.RoundToInt(children.transform.position.x);
           var roundedY = Mathf.RoundToInt(children.transform.position.y);

           if (roundedX < 0 || roundedX >= Width || roundedY < 0 || roundedY >= Height)
           {
               return false;
           }

           if (grid[roundedX, roundedY] != null)
           {
               return false;
           }
       }

       return true;
   }
}
