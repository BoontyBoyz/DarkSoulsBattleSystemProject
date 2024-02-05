using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerInputManager : MonoBehaviour
{

    public static PlayerInputManager instance;
    // THINK ABOUT GOALS IN STEPS
    // 2. MOVE CHARACTER BASED ON THOSE VALUES

    PlayerControls playerControls;

    [SerializeField] Vector2 movementInput;
    public float verticalInput;
    public float horizontalInput;
    public float moveAmount;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }       
    }

    // Start is called before the first frame update
    private void Start()
    {
        DontDestroyOnLoad(gameObject);

        // WHEN THE SCENE CHANGES, RUN THIS SCENE
        SceneManager.activeSceneChanged += OnSceneChange;

        instance.enabled = false;
    }

    // Update is called once per frame
    private void Update()
    {
        HandleMovementInput();
    }

    private void OnSceneChange(Scene oldScene, Scene newScene)
    {
        // IF WE ARE LOADING INTO OUR WORLD SCENE ENABLE OUR PLAYERS CONTROLS
        if (newScene.buildIndex == WorldSaveGameManager.instance.GetWorldSceneIndex())
        {
            instance.enabled = true;
        }
        // OTHERWISE WE MUST BE AT THE MAIN MENU, DISABLE OUR PLAYERS CONTROLS
        // THIS IS SO OUR PLAYER CANT MOVE AROUND IF WE ENTER THINGS LIKE A CHARACTER CREATION MENU ETC
        else
        {
            instance.enabled = false;
        }
    }

    private void OnEnable()
    {
        if (playerControls == null)
        {
            playerControls = new PlayerControls();

            playerControls.PlayerMovement.Movement.performed += i => movementInput = i.ReadValue<Vector2>();
        }

        playerControls.Enable();
    }

    private void OnDestroy()
    {
        // IF WE DESTROY THIS OBJECT, UNSUBCRIBE FROM THIS EVENT
        SceneManager.activeSceneChanged -= OnSceneChange;
    }

    private void HandleMovementInput()
    {
        verticalInput = movementInput.y;
        horizontalInput = movementInput.x;

        // RETURNS THE ABSOLUTE NUMBER, (Meaning number without the negative sign, sits always positive)
        moveAmount = Mathf.Clamp01(Mathf.Abs(verticalInput) + Mathf.Abs(horizontalInput));

        // WE CLAMP THE VALUES, SO THEY ARE 0, 0.5 OR 1 (OPTIONAL)
        if (moveAmount <= 0.5 && moveAmount > 0)
        {
            moveAmount = 0.5f;
        }
        else if(moveAmount > 0.5 && moveAmount <= 1)
        {
            moveAmount = 1;
        }
    }
}
