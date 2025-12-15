using UnityEngine;
using UnityEngine.UI;

public class ToolbarController : MonoBehaviour
{
    public Image[] toolImages;
    public PlayerController playerController;

    private int selectedIndex = 0;

    void Start()
    {
        UpdateSelectedTool();
    }

    void Update()
    {
        HandleToolSelection();
    }

    void HandleToolSelection()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) SelectTool(0);
        if (Input.GetKeyDown(KeyCode.Alpha2)) SelectTool(1);
        if (Input.GetKeyDown(KeyCode.Alpha3)) SelectTool(2);

        // Add more if you have more tools

        if (Input.mouseScrollDelta.y > 0) ScrollTool(-1);
        if (Input.mouseScrollDelta.y < 0) ScrollTool(1);
    }

    void SelectTool(int index)
    {
        if (index >= 0 && index < toolImages.Length)
        {
            selectedIndex = index;
            UpdateSelectedTool();
        }
    }

    void ScrollTool(int direction)
    {
        selectedIndex = (selectedIndex + direction + toolImages.Length) % toolImages.Length;
        UpdateSelectedTool();
    }

    void UpdateSelectedTool()
    {
        for (int i = 0; i < toolImages.Length; i++)
        {
            if (i == selectedIndex)
            {
                toolImages[i].color = Color.green; // Highlight selected image
            }
            else
            {
                toolImages[i].color = Color.white; // Default color
            }
        }

        // Update the player's selected tool
        switch (selectedIndex)
        {
            case 0:
                playerController.selectedTool = ToolType.Seed;
                break;
            case 1:
                playerController.selectedTool = ToolType.Potato;
                break;
            case 2:
                playerController.selectedTool = ToolType.Carrot;
                break;
            case 3:
                playerController.selectedTool = ToolType.Apple;
                break;
            case 4:
                playerController.selectedTool = ToolType.WateringCan;
                break;
                // Add more cases if you have more tools
        }
    }
}
