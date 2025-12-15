using UnityEngine;

public class FarmTile : MonoBehaviour
{
    public TileState currentState = TileState.Empty;

    // Các Prefab cho các loại cây khác nhau
    public GameObject[] seedlingPrefabs;
    public GameObject[] growingPlantPrefabs;
    public GameObject[] maturePlantPrefabs;
    public GameObject[] fruitPrefab; // Prefab của quả

    private GameObject currentPlant;
    private int currentPlantType; // Loại cây hiện tại
    public float growthTime = 5f; // Thời gian để cây từ Planted sang Growing
    public float harvestTime = 10f; // Thời gian để cây từ Growing sang Harvestable
    private float growthTimer = 0f; // Thời gian đã trôi qua


    private void Update()
    {

        if (currentState == TileState.Planted)
        {
            growthTimer += Time.deltaTime;
            if (growthTimer >= growthTime)
            {
                // Tự động chuyển sang trạng thái Growing
                Destroy(currentPlant);
                currentPlant = Instantiate(growingPlantPrefabs[currentPlantType], transform.position, Quaternion.identity);
                currentState = TileState.Growing;
                growthTimer = 0f; // Đặt lại bộ đếm
            }
        }
        else if (currentState == TileState.Growing)
        {
            growthTimer += Time.deltaTime;
            if (growthTimer >= harvestTime)
            {
                // Tự động chuyển sang trạng thái Harvestable
                Destroy(currentPlant);
                currentPlant = Instantiate(maturePlantPrefabs[currentPlantType], transform.position, Quaternion.identity);
                currentState = TileState.Harvestable;
            }
        }
    }



    public void PlantSeed(int plantType)
    {
        Vector3 newPosition = new Vector3(transform.position.x, transform.position.y, 1);
        transform.position = newPosition;
        if (currentState == TileState.Empty)
        {
            currentPlantType = plantType;
            // Tạo cây non tại vị trí trung tâm của ô đất
            currentPlant = Instantiate(seedlingPrefabs[plantType], transform.position, Quaternion.identity);
            currentState = TileState.Planted;
        }
    }

    public void Water()
    {
        if (currentState == TileState.Planted)
        {
            // Tưới nước cho cây đã trồng
            growthTimer = 0f; // Đặt lại bộ đếm thời gian
        }
        else if (currentState == TileState.Growing)
        {
            // Tưới nước cho cây đang phát triển
            currentState = TileState.Harvestable; // Chuyển trạng thái trực tiếp
            Destroy(currentPlant);
            currentPlant = Instantiate(maturePlantPrefabs[currentPlantType], transform.position, Quaternion.identity);
        }
    }

    public void Harvest()
    {
        if (currentState == TileState.Harvestable)
        {
            // Hủy bỏ cây trưởng thành
            Destroy(currentPlant);
            currentState = TileState.Empty;

            // Tạo quả tại vị trí hiện tại của ô đất
            Instantiate(fruitPrefab[currentPlantType], transform.position, Quaternion.identity);
        }
    }
}

public enum TileState
{
    Empty,
    Planted,
    Growing,
    Harvestable
}