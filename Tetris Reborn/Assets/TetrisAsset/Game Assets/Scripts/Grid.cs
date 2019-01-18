using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour {

    // The grid itself
    public static int w = 20;
    public static int h = 10;
    // grid storing the Transform element
    public static Transform[,] grid = new Transform[w, h];

    // convert a real vector to discret coordinates using Mathf.Round
    public static Vector2 roundVector2(Vector2 v) {
        return new Vector2 (Mathf.Round (v.x), Mathf.Round (v.y));
    }

    // check if some vector is inside the limits of game (borders left, right and down)
    public static bool insideBorder(Vector2 pos) {
        return ((int)pos.y >= 0 &&
                (int)pos.y < h &&
                (int)pos.x < w-1);
    }

    // destroy the row at y line
    public static void deleteRow(int x) {
        for (int y = 0; y < h; y++) {
            Destroy(grid[x, y].gameObject);
            grid[x, y] = null;
        }
    }


    // Whenever a row was deleted, the above rows should fall towards the bottom by one unit. 
    // The following function will take care of that:
    public static void decreaseRow(int x) {
        for (int y = 0; y < h; y++) {
            if (grid[x, y] != null) {
                // move one twoards bottom
                grid[x + 1, y] = grid[x, y];
                grid[x,y] = null;

                // Update block position
                grid[x + 1,y].position += new Vector3(1, 0, 0);
            }
        }
    }

    // whenever a row is deleted, all the above rows should be increased by 1
    public static void decreaseRowAbove(int y) {
        for (int i = y; i >= 0; i--) {
            decreaseRow(i);
        }
    }

    // check if a row is full and, then, can be deleted (score +1)
    public static bool isRowFull(int x){
        for (int y = 0; y < h; y++) {
            if (grid[x, y] == null) {
                return false;
            }
        }
        return true;

    }

    public static void deleteFullRows() {
        for (int y = w-1; y >=0; y--) {
            if (isRowFull(y)) {
                deleteRow(y);
                decreaseRowAbove(y - 1);
                // add new points to score when a row is deleted
                ScoreManager.score += (w - y) * 10;
                ++y;
                // NOTE: --y decreases y by one whenever a row was deleted.
                // it's to make sure that the next step of the for loop continues
                // at the correct index (which must be decreased by one, because we just deleted a row).
            }
        }
    }
}
