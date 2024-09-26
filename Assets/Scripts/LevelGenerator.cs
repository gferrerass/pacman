using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public GameObject outsideCorner;  // 1
    public GameObject outsideWall;    // 2
    public GameObject insideCorner;   // 3
    public GameObject insideWall;     // 4
    public GameObject standardPellet; // 5
    public GameObject powerPellet;    // 6
    public GameObject tJunctionPiece; // 7

    public int[,] levelMap =
    {
        {1,2,2,2,2,2,2,2,2,2,2,2,2,7},
        {2,5,5,5,5,5,5,5,5,5,5,5,5,4},
        {2,5,3,4,4,3,5,3,4,4,4,3,5,4},
        {2,6,4,0,0,4,5,4,0,0,0,4,5,4},
        {2,5,3,4,4,3,5,3,4,4,4,3,5,3},
        {2,5,5,5,5,5,5,5,5,5,5,5,5,5},
        {2,5,3,4,4,3,5,3,3,5,3,4,4,4},
        {2,5,3,4,4,3,5,4,4,5,3,4,4,3},
        {2,5,5,5,5,5,5,4,4,5,5,5,5,4},
        {1,2,2,2,2,1,5,4,3,4,4,3,0,4},
        {0,0,0,0,0,2,5,4,3,4,4,3,0,3},
        {0,0,0,0,0,2,5,4,4,0,0,0,0,0},
        {0,0,0,0,0,2,5,4,4,0,3,4,4,0},
        {2,2,2,2,2,1,5,3,3,0,4,0,0,0},
        {0,0,0,0,0,0,5,0,0,0,4,0,0,0},
    };

    // Start is called before the first frame update
    void Start()
    {
        DeleteLevel();

        // Safety check
        if (outsideCorner == null || outsideWall == null || insideCorner == null || insideWall == null || standardPellet == null || powerPellet == null || tJunctionPiece == null)
        {
            Debug.LogWarning("GameObjects for the Level Layout have not been assigned properly");
            return;
        }

        // Map gets generated
        GenerateMap();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void DeleteLevel()
    {
        // Obtaining the parent Gameobject that contains all the tiles
        GameObject grid = GameObject.Find("Grid");

        if (grid != null) // For safety reasons
        {
            // Looping through each child and destroying them
            foreach (Transform child in grid.transform)
            {
                Destroy(child.gameObject);
            }
        }
        else
        {
            Debug.LogWarning("Grid object not found");
            return;
        }
    }

    void GenerateMap()
    {
        // Creating a new Grid for the map (parent GameObject)
        GameObject newGrid = new GameObject("NewGrid");

        for (int y = 0; y < levelMap.GetLength(0); y++)
        {
            for (int x = 0; x < levelMap.GetLength(1); x++)
            {
                int prefabIndex = levelMap[y, x];

                // If it's empty, we simply continue
                if (prefabIndex == 0) continue;

                // The position and rotation of the GameObject gets calculated
                Vector3 position = new Vector3(x, -y, 0);
                float calculatedRotation = calculateRotation(prefabIndex, x, y);
                Quaternion rotation = Quaternion.Euler(0, 0, calculatedRotation);

                // The tiles will be assigned to a variable to be able to organize them under a parent GameObject
                // (for better control and management of the level structure)
                GameObject newTile = null;

                // Level layout gets generated
                switch (prefabIndex)
                {
                    case 1:
                        newTile = Instantiate(outsideCorner, position, rotation);
                        break;
                    case 2:
                        newTile = Instantiate(outsideWall, position, rotation);
                        break;
                    case 3:
                        newTile = Instantiate(insideCorner, position, rotation);
                        break;
                    case 4:
                        newTile = Instantiate(insideWall, position, rotation);
                        break;
                    case 5:
                        newTile = Instantiate(standardPellet, position, rotation);
                        break;
                    case 6:
                        newTile = Instantiate(powerPellet, position, rotation);
                        break;
                    case 7:
                        newTile = Instantiate(tJunctionPiece, position, rotation);
                        break;
                }

                // Setting the parent of the new tile to the grid
                if (newTile != null)
                {
                    newTile.transform.parent = newGrid.transform;
                }
            }
        }
    }

    float calculateRotation(int prefabIndex, int x, int y)
    {
        int upTile = (y > 0) ? levelMap[y - 1, x] : 0; // Checking for tile above
        int downTile = (y + 1 < levelMap.GetLength(0)) ? levelMap[y + 1, x] : 0; // Checking for tile below
        int leftTile = (x > 0) ? levelMap[y, x - 1] : 0; // Checking for tile to the left
        int rightTile = (x + 1 < levelMap.GetLength(1)) ? levelMap[y, x + 1] : 0; // Checking for tile to the right

        int up2Tile = (y > 1) ? levelMap[y - 2, x] : 0; // Checking for tile two spaces above
        int down2Tile = (y + 2 < levelMap.GetLength(0)) ? levelMap[y + 2, x] : 0; // Checking for tile two spaces below
        int left2Tile = (x > 1) ? levelMap[y, x - 2] : 0; // Checking for tile two spaces to the left
        int right2Tile = (x + 2 < levelMap.GetLength(1)) ? levelMap[y, x + 2] : 0; // Checking for tile two spaces to the right

        if (prefabIndex == 1) // If it's an outside corner
        {
            if (upTile == 2 && rightTile == 2) return 90;
            else if (upTile == 2 && leftTile == 2) return 180;
            else if (downTile == 2 && leftTile == 2) return 270;
        }
        else if (prefabIndex == 2) // If it's an outside wall
        {
            if (leftTile == 2 || rightTile == 2 || leftTile == 1 || rightTile == 1) return 90;   
        }
        else if (prefabIndex == 3) // If it's an inside corner
        {
            
            if ((upTile == 4 || upTile == 3) && (leftTile !=3 && leftTile != 4) && (downTile !=3 && downTile != 4)) return 90;
            else if (upTile == 4 && leftTile == 4 && (up2Tile == 3 || up2Tile == 4)) return 180;
            else if ((downTile == 4 || downTile ==3) && (rightTile != 3 && rightTile != 4) && (upTile != 3 && upTile != 4)) return 270;
            else if (upTile == 3 && leftTile == 4) return 180;
            else if (downTile == 3 && leftTile == 4) return 270;
        }
        else if (prefabIndex == 4) // If it's an inside wall
        {
            if ((upTile != 4 && upTile !=3) || (downTile != 4 && downTile != 3))
            {
                if (leftTile == 4 || rightTile == 4 || leftTile == 3 || rightTile == 3) return 90;
            }
            if ((leftTile == 4 && left2Tile != 4 && left2Tile != 3) || (rightTile == 4 && right2Tile != 4 && right2Tile != 3)) return 90;
        }

        // no rotation
        return 0.0f;
    }
}
