using InventorySampleScene;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerController : Singleton<PlayerController>
{
    public List<TextMeshProUGUI> soHat = new List<TextMeshProUGUI>();
    public List<int> soHatInt = new List<int>() { 0, 0, 0, 0 };
    public bool FacingLeft { get { return facingLeft; } }

    [SerializeField] public float moveSpeed = 1f;
    [SerializeField] private float dashSpeed = 4f;
    [SerializeField] private TrailRenderer myTrailRenderer;
    [SerializeField] private Transform weaponCollider;

    private PlayerControls playerControls;
    private Vector2 movement;
    private Rigidbody2D rb;
    private Animator myAnimator;
    private SpriteRenderer mySpriteRender;
    private float startingMoveSpeed;

    private bool facingLeft = false;
    private bool isDashing = false;

    public GameObject hack;

    protected override void Awake()
    {
        base.Awake();

        playerControls = new PlayerControls();
        rb = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        mySpriteRender = GetComponent<SpriteRenderer>();

    }

    private void Start()
    {
        playerControls.Combat.Dash.performed += _ => Dash();

        startingMoveSpeed = moveSpeed;
        ActiveInventory.Instance.EquipStartingWeapon();
    }

    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void Update()
    {
        PlayerInput();
        HandleToolSelection();
        HandleAction();
        UpdateCoinDisplay();
        UpdateSoHat();
        Hack();
    }

    private void FixedUpdate()
    {
        AdjustPlayerFacingDirection();
        Move();
    }

    public Transform GetWeaponCollider()
    {
        return weaponCollider;
    }

    private void PlayerInput()
    {
        movement = playerControls.Movement.Move.ReadValue<Vector2>();

        myAnimator.SetFloat("moveX", movement.x);
        myAnimator.SetFloat("moveY", movement.y);
    }

    private void Move()
    {
        if (PlayerHealth.Instance.isDead) { return; }

        rb.MovePosition(rb.position + movement * (moveSpeed * Time.fixedDeltaTime));
    }

    private void AdjustPlayerFacingDirection()
    {
        Vector3 mousePos = Input.mousePosition;
        Vector3 playerScreenPoint = Camera.main.WorldToScreenPoint(transform.position);

        if (mousePos.x < playerScreenPoint.x)
        {
            mySpriteRender.flipX = true;
            facingLeft = true;
        }
        else
        {
            mySpriteRender.flipX = false;
            facingLeft = false;
        }
    }

    private void Dash()
    {
        if (!isDashing && Stamina.Instance.CurrentStamina > 0)
        {
            Stamina.Instance.UseStamina();
            isDashing = true;
            moveSpeed *= dashSpeed;
            myTrailRenderer.emitting = true;
            StartCoroutine(EndDashRoutine());
        }
    }

    private IEnumerator EndDashRoutine()
    {
        float dashTime = .2f;
        float dashCD = .25f;
        yield return new WaitForSeconds(dashTime);
        moveSpeed = startingMoveSpeed;
        myTrailRenderer.emitting = false;
        yield return new WaitForSeconds(dashCD);
        isDashing = false;
    }

    public ToolType selectedTool = ToolType.None;
    //public GameObject wateringEffect;
    public LayerMask tileLayerMask;
    public List<ToolType> tools = new List<ToolType>();

    public Animator animator;
    Vector2 velocity;
    public Inventory inventory;
    public TextMeshProUGUI coinText1;
    public TextMeshProUGUI coinText2;
    public int coins;

    private void Awakes()
    {
        inventory = new Inventory(18);
    }

    public void DropItem(Items item)
    {
        Vector2 spawnLocation = transform.position;
        Vector2 spawmOffset = Random.insideUnitCircle * 1.25f;
        Items droppedItem = Instantiate(item, spawnLocation + spawmOffset, Quaternion.identity);
        droppedItem.rb2d.AddForce(spawmOffset * 2f, ForceMode2D.Impulse);
    }

    private void UpdateCoinDisplay()
    {
        coinText1.text = coins.ToString();
        coinText2.text = coins.ToString();
    }

    public void AddCoins(int amount)
    {
        coins += amount;
        UpdateCoinDisplay();
    }

    public void SubtractCoins(int amount)
    {
        coins -= amount;
        UpdateCoinDisplay();
    }
    public void UpdateSoHat()
    {


        soHatInt[0] = inventory.GetItem(CollectableType.HatBiNgo_);
        soHatInt[1] = inventory.GetItem(CollectableType.HatKhoaiLang_);
        soHatInt[2] = inventory.GetItem(CollectableType.HatCarrot_);
        soHatInt[3] = inventory.GetItem(CollectableType.HatCaChua_);
        soHat[0].text = soHatInt[0].ToString();
        soHat[1].text = soHatInt[1].ToString();
        soHat[2].text = soHatInt[2].ToString();
        soHat[3].text = soHatInt[3].ToString();
    }
    public float scrollSpeed = 0.1f;
    int current;
    int nextToolIndex;
    int thongtoolindex;
    void HandleToolSelection()
    {
        for(int i = 0; i < tools.Count; i++)
        {
            if (Input.GetKeyDown((KeyCode)((int)KeyCode.Alpha1 + i)))
            {
                selectedTool = tools[i];
                
            }
        }
        

        if (Input.mouseScrollDelta.y != 0)
        {
            float scrollDelta = (int)Input.mouseScrollDelta.y;
            current = current + (int)scrollDelta;
            nextToolIndex = current;
            thongtoolindex = nextToolIndex;
            Debug.Log("tthong" + thongtoolindex);
            if(thongtoolindex > 6)
            {
                thongtoolindex = 2;
            }  else if(thongtoolindex < 1)
            {
                thongtoolindex = 6;
            }
            if (current > 7)
             {
                 current = 0;
             }
             else if (current < 0)
             {
                 current = 7;
             }
            if( thongtoolindex <= 6 && thongtoolindex > 0)
            {
                selectedTool = tools[thongtoolindex-1];
            } 
            if(nextToolIndex >5)
            {
                selectedTool = tools[5];
            }
            Debug.Log("tthong" + thongtoolindex);
            FindAnyObjectByType<ActiveInventory>().ToggleActiveSlot(nextToolIndex);
        }
    }
  public List<int> availablePlantTypes = new List<int> { 0, 1, 2, 3, 4 }; // Các loại cây sẵn có
    public int selectedPlantType = 0;
    public int selectedPlantType1 = 0;
    public int selectedPlantType2 = 0;
    public int selectedPlantType3 =0;
  
    void Hack()
    {
        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.F1))
        {
            Debug.Log("hcakkkkk");
            hack.SetActive(true);
        } else if(Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.F2))
        {
            hack.SetActive(false);
        }
       
    }
    void HandleAction()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity, tileLayerMask);
            if (hit.collider != null)
            {
                FarmTile tile = hit.collider.GetComponent<FarmTile>();
                if (tile != null)
                {
                    if (selectedTool == ToolType.Seed && tile.currentState == TileState.Empty && soHatInt[0] > 0)
                    {
                        int selectedPlantType = 0; // Giả sử giá trị 1 là loại cây bạn muốn trồng
                        tile.PlantSeed(selectedPlantType);
                        int index = inventory.getSlots(CollectableType.HatBiNgo_);
                        inventory.Remove(index);
                    }
                    if (selectedTool == ToolType.Potato && tile.currentState == TileState.Empty && soHatInt[1] > 0)
                    {
                        selectedPlantType = 1; // Giả sử giá trị 1 là loại cây bạn muốn trồng
                        tile.PlantSeed(selectedPlantType);
                        int index = inventory.getSlots(CollectableType.HatKhoaiLang_);
                        inventory.Remove(index);
                    }
                    if (selectedTool == ToolType.Carrot && tile.currentState == TileState.Empty && soHatInt[2] > 0)
                    {
                        selectedPlantType = 2; // Giả sử giá trị 1 là loại cây bạn muốn trồng
                        tile.PlantSeed(selectedPlantType);
                        int index = inventory.getSlots(CollectableType.HatCarrot_);
                        inventory.Remove(index);
                    }
                    if (selectedTool == ToolType.Apple && tile.currentState == TileState.Empty && soHatInt[3] > 0)
                    {
                        selectedPlantType = 3; // Giả sử giá trị 1 là loại cây bạn muốn trồng
                        tile.PlantSeed(selectedPlantType);
                        inventory.Remove(1);
                        int index = inventory.getSlots(CollectableType.HatCaChua_);
                        inventory.Remove(index);
                    }
                    if (selectedTool == ToolType.WateringCan && (tile.currentState == TileState.Planted || tile.currentState == TileState.Growing))
                    {
                        tile.Water();
                        //Instantiate(wateringEffect, tile.transform.position, Quaternion.identity);
                    }
                    else if (tile.currentState == TileState.Harvestable)
                    {
                        tile.Harvest();
                    }
                }
            }
        }
    }

    private IEnumerator DestroyEffectAfterDelay(GameObject effect, float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(effect);
    }
}