using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimatorManager : MonoBehaviour
{
    CharacterManager character;

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
        character.animator.SetFloat("Horizontal", horizontalValue);
        character.animator.SetFloat("Vertical", verticalValue);

    }
}