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

    [Header("Timers")]
    [HideInInspector]public float timer;
    public float cooldown;

    [Header("Cost Modifiers")]
    [SerializeField] float costMod;
    
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

        if(count == 1)
        {
            isActive = true;
        }
    }
}
