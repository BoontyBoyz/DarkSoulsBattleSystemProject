using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStatsManager : MonoBehaviour
{
    CharacterManager character;

    [Header("Stamina Regeneration")]
    [SerializeField] int enduranceAmount = 100;
    [SerializeField] float staminaRegenAmount = 2f;
    private float staminaRegenTimer = 0f;
    private float staminaTickTimer = 0f;
    [SerializeField] float staminaRegenDelay;

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

    public int CalculateStaminaBasedOnEnduranceLevel(int endurance)
    {
        float stamina = 0;

        //CREATE AN EQUATION FOR HOW YOU WANT YOUR STAMINA TO BE CALCULATED

        stamina = endurance * enduranceAmount;

        return Mathf.RoundToInt(stamina);
    }

    public virtual void RegenerateStamina()
    {
        // ONLY OWNERS CAN EDIT THIER NETWORK VARIABLE
        if (!character.IsOwner)
            return;

        if (character.characterNetworkManager.isSprinting.Value)
            return;

        if (character.isPerformingAction)
            return;

        staminaRegenTimer += Time.deltaTime;

        if (staminaRegenTimer >= staminaRegenDelay)
        {
            if (character.characterNetworkManager.currentStamina.Value < character.characterNetworkManager.maxStamina.Value)
            {
                staminaTickTimer = staminaTickTimer += Time.deltaTime;

                if (staminaTickTimer >= 0.1f)
                {
                    staminaTickTimer = 0;
                    character.characterNetworkManager.currentStamina.Value += staminaRegenAmount;
                }
            }
        }
    }

    public virtual void ResetStaminaRegenTimer(float previousStaminaAmount, float currentStaminaAmount)
    {
        // WE ONLY WANT TO RESET THE REGENERATION IF THE ACTION USED STAMINA
        // WE DONT WANT TO RESET THE REGENERATION IF WE ARE ALREADY REGENERATING STAMINA
        if (currentStaminaAmount < previousStaminaAmount)
        {
            staminaRegenTimer = 0;
        }
    }
}
