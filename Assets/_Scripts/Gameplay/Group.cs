using UnityEngine;
using System.Collections;
public class Group : MonoBehaviour
{
    
    float lastFall = 0;
    void Update() {
        // Move Left
        if (Input.GetKeyDown(KeyCode.LeftArrow)) {
            // Modify position
            transform.position += new Vector3(-1, 0, 0);
       
            // See if valid
            if (isValidGridPos())
                // It's valid. Update grid.
                updateGrid();
            else
                // It's not valid. revert.
                transform.position += new Vector3(1, 0, 0);
        }

        // Move Right
        else if (Input.GetKeyDown(KeyCode.RightArrow)) {
            // Modify position
            transform.position += new Vector3(1, 0, 0);
       
            // See if valid
            if (isValidGridPos())
                // It's valid. Update grid.
                updateGrid();
            else
                // It's not valid. revert.
                transform.position += new Vector3(-1, 0, 0);
        }

        // Rotate
        else if (Input.GetKeyDown(KeyCode.UpArrow)) {
            transform.Rotate(0, 0, -90);
       
            // See if valid
            if (isValidGridPos())
                // It's valid. Update grid.
                updateGrid();
            else
                // It's not valid. revert.
                transform.Rotate(0, 0, 90);
        }

        // Move Downwards and Fall
        else if (Input.GetKeyDown(KeyCode.DownArrow) ||
                 Time.time - lastFall >= 1) {
            // Modify position
            transform.position += new Vector3(0, -1, 0);

            // See if valid
            if (isValidGridPos()) {
                // It's valid. Update grid.
                updateGrid();
            } else {
                // It's not valid. revert.
                transform.position += new Vector3(0, 1, 0);

                // Clear filled horizontal lines
                GridController.deleteFullRows();

                // Spawn next Group
                FindObjectOfType<BlockSpawner>().spawnNext();

                // Disable script
                enabled = false;
            }

            lastFall = Time.time;
        }
    }
    
    bool isValidGridPos()
    {        
        foreach (Transform child in transform) {
            Vector2 v = GridController.roundVec2(child.position);

            // Not inside Border?
            if (!GridController.insideBorder(v))
                return false;

            // Block in grid cell (and not part of same group)?
            if (GridController.grid[(int)v.x, (int)v.y] != null &&
                GridController.grid[(int)v.x, (int)v.y].parent != transform)
                return false;
        }
        return true;
    }
    
    void updateGrid() {
        // Remove old children from grid
        for (int y = 0; y < GridController.h; ++y)
        for (int x = 0; x < GridController.w; ++x)
            if (GridController.grid[x, y] != null)
                if (GridController.grid[x, y].parent == transform)
                    GridController.grid[x, y] = null;

        // Add new children to grid
        foreach (Transform child in transform) {
            Vector2 v = GridController.roundVec2(child.position);
            GridController.grid[(int)v.x, (int)v.y] = child;
        }        
    }
}
