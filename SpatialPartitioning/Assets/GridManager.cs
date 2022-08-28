using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    [SerializeField] private int gridSize;

    [SerializeField] private int gridCellSize;

    [SerializeField] private GameObject gridCellPrefab;

    private void Start()
    {
        GenerateGrid();
    }

    private void GenerateGrid()
    {
        for (int x = 0; x < gridCellSize; x++)
        {
            for (int y = 0; y < gridCellSize; y++)
            {
                Vector3 cellPos = new Vector3(x, 0, y) * gridCellSize;

                GameObject cellInstance = Instantiate(gridCellPrefab, transform);

                cellInstance.transform.localScale = Vector3.one * gridCellSize;

                cellInstance.transform.position = cellPos;
            }
        }
    }
        
}

