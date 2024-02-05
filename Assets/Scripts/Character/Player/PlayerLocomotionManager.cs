using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLocomotionManager : CharacterLocomotionManager
{
    // THESE VALUES ARE TAKEN FROM THE INPUT MANAGER
    PlayerManager player;

    public float verticalMovement;
    public float horizontalMovement;
    public float moveAmount;

    private Vector3 moveDirection;
    [SerializeField] float walkingSpeed = 2;
    [SerializeField] float runningSpeed = 5;


    protected override void Awake()
    {
        base.Awake();

        player = GetComponent<PlayerManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HandleAllMovement()
    {
        //GROUNDED MOVEMENT
        HandleGroundedMovement();
        //AERIAL MOVEMENT
    }

    private void GetVerticalAndHorizontalInputs()
    {
        verticalMovement = PlayerInputManager.instance.verticalInput;
        horizontalMovement = PlayerInputManager.instance.horizontalInput;

        // CLAMP THE MOVEMENTS
    }

    private void HandleGroundedMovement()
    {
        GetVerticalAndHorizontalInputs();

        // OUR MOVEMENT DIRECTION IS BASED ON OUR CAMERAS FACING PERSPECTIVE & OUR MOVEMENT INPUTS
        moveDirection = PlayerCamera.instance.transform.forward * verticalMovement;
        moveDirection = moveDirection + PlayerCamera.instance.transform.right * horizontalMovement;
        moveDirection.Normalize();
        moveDirection.y = 0;

        if (PlayerInputManager.instance.moveAmount > 0.5f)
        {
            // MOVE AT A RUNNING SPEED
            player.characterController.Move(moveDirection * runningSpeed * Time.deltaTime);
        }
        else if (PlayerInputManager.instance.moveAmount <= 0.5f)
        {
            // MOVE AT A WALKING SPEED
            player.characterController.Move(moveDirection * walkingSpeed * Time.deltaTime);
        }
    }
}
