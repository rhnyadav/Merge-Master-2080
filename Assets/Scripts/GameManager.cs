using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int currentLevel = 1;
    public int maxLevel = 100;
    public int targetValue;

    public GridManager gridManager;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    void Start()
    {
        SetupLevel();
    }

    public void SetupLevel()
    {
        targetValue = CalculateTarget(currentLevel);

        if (currentLevel <= 30)
            gridManager.SetGridSize(4);
        else if (currentLevel <= 80)
            gridManager.SetGridSize(5);
        else
            gridManager.SetGridSize(6);

        gridManager.ResetBoard();

        Debug.Log($"LEVEL {currentLevel} | TARGET {targetValue}");
    }

    int CalculateTarget(int level)
    {
        return (int)(10 * Mathf.Pow(2, level + 3));
    }

    public void CheckLevelComplete(int value)
    {
        if (value >= targetValue)
        {
            if (currentLevel < maxLevel)
            {
                currentLevel++;
                SetupLevel();
            }
            else
            {
                Debug.Log("🏆 ALL 100 LEVELS COMPLETED!");
            }
        }
    }
}
