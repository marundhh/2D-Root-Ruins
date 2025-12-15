using UnityEngine;

public class FarmGrid : MonoBehaviour
{
    public GameObject farmTilePrefab;
    public int rows = 5;
    public int cols = 5;
    public float tileSpacing = 1.1f;

    void Start()
    {
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                Vector3 position = new Vector3(i * tileSpacing, j * tileSpacing, 0);
                Instantiate(farmTilePrefab, position, Quaternion.identity, transform);
            }
        }
    }
}