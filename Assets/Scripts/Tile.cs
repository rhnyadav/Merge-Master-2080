using UnityEngine;
using UnityEngine.UI;

public class Tile : MonoBehaviour
{
    public int value;
    public int x, y;
    public Text valueText;

    public void SetValue(int number)
    {
        value = number;
        valueText.text = value.ToString();
        GameManager.instance.CheckLevelComplete(value);
    }

    public void Merge(Tile other)
    {
        SetValue(value * 2);
        Destroy(other.gameObject);
    }
}
