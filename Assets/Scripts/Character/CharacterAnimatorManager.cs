using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimatorManager : MonoBehaviour
{
    CharacterManager character;

    float vertical;
    float horizontal;

    protected virtual void Awake()
    {
        character = GetComponent<CharacterManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateAnimatorMovementParameters(float horizontalValue, float verticalValue)
    {
        // OPTION 1
        character.animator.SetFloat("Horizontal", horizontalValue, 0.1f, Time.deltaTime);
        character.animator.SetFloat("Vertical", verticalValue, 0.1f, Time.deltaTime);

    }

    public virtual void PlayTargetActionAnimation(
        string targetAnimation,
        bool isPerformingAction,
        bool applyRootMotion = true,
        bool canRotate = false,
        bool canMove = false)
    {
        // applying root motion uses the motion in the animation (keep note of this in case of future problems)
        character.animator.applyRootMotion = applyRootMotion;
        character.animator.CrossFade(targetAnimation, 0.2f);

        // CAN BE USED TO STOP CHARACTER FROM ATTEMPTING NEW ACTIONS (EG, ADDING SOME KIND OF TIMER TO DODGE ROLL WILL MAKE IT CANCEL LIKE MH)
        // FOR EXAMPLE, IF YOU GET DAMAGED, AND BEGIN PERFORMING A DAMAGE ANIMATION
        // THIS FLAG WILL TURN TRUE IF YOU ARE STUNNED
        //WE CAN THEN CHECK FOR THIS BEFORE ATEMPTING NEW ACTIONS
        character.isPerformingAction = isPerformingAction;
        character.canRotate = canRotate;
        character.canMove = canMove;
    }
}
