using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComponentSys : MonoBehaviour
{   
    [Header("Reference")]
    [SerializeField] Prototype UIRef;

    [Header("Component Info")]
    public bool isActive = false;
    public int count;
    [SerializeField] float baseCompute;
    float compute;
    [SerializeField] float  basePower = 1f;
    public float power;

    [Header("Timers")]
    [HideInInspector]public float timer;
    public float cooldown;

    [Header("Cost Modifiers")]
    [HideInInspector]public float cost;
    [SerializeField] float baseCost;
    [SerializeField] float costMod;
    [SerializeField] float deltaPowerMod = 0.05f;
    //[SerializeField] float gammaPowerMod;
    
    void Update()
    {
        //When transistor is active calls TransistorCompute
        if(isActive)
        {
            timer += Time.deltaTime;

                if(timer >= cooldown)
                {
                    TransistorCompute();
                    timer = 0;
                }
        }
        else
        {
            timer = 0;
        }
    }

    private void TransistorCompute()
    {
        //Computes current
        compute = baseCompute * count;

        //Adds to current
        UIRef.currentCompute += compute;

        //Adds to total
        UIRef.totalCompute += compute;

        //reset timer
        timer = 0;
    }

    public void Buy()
    {
        count++;
        PowerCost();
        CostIncrement();

        if(count == 1)
        {
            isActive = true;
        }
    }

    public void PowerCost()
    {
        float modifier = deltaPowerMod * (1f - count/100f);
        if(count == 0)
        {
            modifier = 0;
        }
        power = basePower * (1 + (count * modifier));
    }

    public void CostIncrement()
    {
        float modifier = costMod * (1f - count/10f);
        if(count == 0)
        {
            modifier = 0;
        }
        cost = baseCost * (1 + (count * modifier));
    }
}
