using UnityEngine;

public class GridManager : MonoBehaviour
{
    public int gridSize = 4;
    public Tile[,] grid;

    public GameObject tilePrefab;
    public Transform board;

    public void SetGridSize(int size)
    {
        gridSize = size;
    }

    public void ResetBoard()
    {
        foreach (Transform child in board)
            Destroy(child.gameObject);

        grid = new Tile[gridSize, gridSize];

        SpawnTile();
        SpawnTile();
    }

    public void SpawnTile()
    {
        for (int i = 0; i < 100; i++)
        {
            int x = Random.Range(0, gridSize);
            int y = Random.Range(0, gridSize);

            if (grid[x, y] == null)
            {
                GameObject obj = Instantiate(tilePrefab, board);
                Tile tile = obj.GetComponent<Tile>();

                tile.SetValue(GetStartTileValue());
                tile.x = x;
                tile.y = y;

                obj.transform.localPosition = new Vector2(x * 120, y * 120);
                grid[x, y] = tile;
                break;
            }
        }
    }

    int GetStartTileValue()
    {
        int level = GameManager.instance.currentLevel;

        if (level <= 10) return Random.value < 0.9f ? 10 : 20;
        if (level <= 30) return Random.value < 0.8f ? 20 : 40;
        if (level <= 50) return Random.value < 0.7f ? 40 : 80;
        if (level <= 80) return Random.value < 0.6f ? 80 : 160;
        return Random.value < 0.5f ? 160 : 320;
    }
}
