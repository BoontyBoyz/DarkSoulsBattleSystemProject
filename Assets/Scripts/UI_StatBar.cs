using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_StatBar : MonoBehaviour
{
    [HideInInspector] private Slider slider;
    // VARIABLE TO SCALE THE BAR SIZE DEPENDING ON STAT (HIGH STAT = LONGER BAR ACROSS SCREEN)
    // SECONDARY BAR BEHIND MAIN BAR FOR POLISH EFFECT (YELLOW BAR THATS SHOWS HOW MUCH AN ACTION/DAMAGE TAKES AWAY FROM CURRENT STAT) 

    protected virtual void Awake()
    {
        slider = GetComponent<Slider>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void SetStat(int newValue)
    {
        slider.value = newValue;
    }

    public virtual void SetMaxStat(int maxValue)
    {
        slider.maxValue = maxValue;
        slider.value = maxValue;
    }
}
