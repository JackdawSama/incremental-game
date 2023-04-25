using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Prototype : MonoBehaviour
{
    [Header("Compute Variables")]
    [SerializeField] float totalCompute;
    [SerializeField] float currentCompute;
    [SerializeField] float handCompute;

    [Header("Compute Checks")]
    [SerializeField] bool handCheck;
    [SerializeField] bool transistorLive;
    [SerializeField] bool gatesLive;
    [SerializeField] bool icLive;
    [SerializeField] bool microprocessorLive;
    [SerializeField] bool cpuLive;
    [SerializeField] bool gpuLive;
    [SerializeField] bool gpuFarmLive;


    [Header("Timer Variables")]
    [SerializeField] float handTimer;
    [SerializeField] float handCooldown;
    [SerializeField] float transistorTimer;
    [SerializeField] float transistorCooldown;
    [SerializeField] float gatesTimer;
    [SerializeField] float gatesCooldown;
    [SerializeField] float icTimer;
    [SerializeField] float icCooldown;
    [SerializeField] float microprocessorTimer;
    [SerializeField] float microprocessorCooldown;
    [SerializeField] float cpuTimer;
    [SerializeField] float cpuCooldown;
    [SerializeField] float gpuTimer;
    [SerializeField] float gpuCooldown;
    [SerializeField] float gpuFarmTimer;
    [SerializeField] float gpuFarmCooldown;

    [Header("Cost Variables")]
    [SerializeField] float transistorCost;
    [SerializeField] float gatesCost;
    [SerializeField] float icCost;
    [SerializeField] float microprocessorCost;
    [SerializeField] float cpuCost;
    [SerializeField] float gpuCost;
    [SerializeField] float gpuFarmCost;

    [Header("Increment Values")]
    [SerializeField] float transistorIncrement = 1.2f;
    [SerializeField] float gatesIncrement = 1.5f;
    [SerializeField] float microprocessorIncrement = 2f;
    [SerializeField] float cpuIncrement = 2.5f;
    [SerializeField] float gpuIncrement = 3f;
    [SerializeField] float gpuFarmIncrement = 3.5f;

    [Header("Button References")]
    [SerializeField] Button computeButton;
    [SerializeField] Button buyTransistor;
    [SerializeField] Button buyGates;
    [SerializeField] Button buyIc;
    [SerializeField] Button buyMicroprocessors;
    [SerializeField] Button buyCpus;
    [SerializeField] Button buyGpus;
    [SerializeField] Button buyGpuFarms;

    [Header("Text References")]
    [SerializeField] TextMeshProUGUI computeText;

    [Header("Units Count")]
    [SerializeField] int transistorCount = 0;
    [SerializeField] int gatesCount = 0;
    [SerializeField] int icCount = 0;
    [SerializeField] int microprocessorCount = 0;
    [SerializeField] int cpuCount = 0;
    [SerializeField] int gpuCount = 0;
    [SerializeField] int gpuFarmCount = 0;

    void Start()
    {
        //Set initial computing level to 0
        computeState = ComputeLevel.Lvl0;

        //Set all units to false
        transistorLive = false;
        gatesLive = false;
        icLive = false;
        microprocessorLive = false;
        cpuLive = false;
        gpuLive = false;
        gpuFarmLive = false;

        //Set all button interactability to false
        buyTransistor.interactable = false;
        buyGates.interactable = false;
        buyIc.interactable = false;
        buyMicroprocessors.interactable = false;
        buyCpus.interactable = false;
        buyGpus.interactable = false;
        buyGpuFarms.interactable = false; 
    }

    void Update()
    {
        ComputeHandler();

        if(!handCheck)
        {
            handTimer += Time.deltaTime;
        }
    }

    ComputeLevel computeState;
    public enum ComputeLevel
    {
        Lvl0,
        Lvl1,
        Lvl2,
        Lvl3,
        Lvl4,
        Lvl5,
        Lvl6,
        Lvl7
           
    }

    void UpdateUI()
    {
        
    }

    public void ComputeHandler()
    {
        switch (computeState)
        {
            case ComputeLevel.Lvl0:                 //Initial state. Hand Compute.

                CostsCheck();

                if(transistorCount > 0)
                {
                    transistorLive = true;
                }
                else
                {
                    transistorLive = false;
                }
                break;

            case ComputeLevel.Lvl1:                 //Transistor State. 1 transistor = 1 data/second
                break;
            
            case ComputeLevel.Lvl2:                 //Gates State. 1 gate = 5 data/second
                break;
            
            case ComputeLevel.Lvl3:                 //IC State. 1 IC = 20 data/second
                break;

            case ComputeLevel.Lvl4:                 //Microprocessor State. 1 Microprocessor = 1 data/second
                break;

            case ComputeLevel.Lvl5:                 //CPU State. 1 CPU = 1 data/second
                break;
            
            case ComputeLevel.Lvl6:                 //GPU State. 1 GPU = 1 data/second
                break;

            case ComputeLevel.Lvl7:                 //GPU Farms State. 1 GPU Farm = 1 data/second
                break;

            default:
                break;
        }
    }
    public void HandCompute()
    {
        if(handTimer >= handCooldown)
        {
            handCheck = true;

            //Compute
            currentCompute += handCompute;
            totalCompute += currentCompute;

            //reset timer
            handTimer = 0;
            handCheck = false;
        }
    }

    #region COST CHECKS
    public void CostsCheck()
    {
        //Cost check for GPU Farms
        if(currentCompute >= gpuFarmCost)
        {
            buyGpuFarms.interactable = true;
        }
        else if(currentCompute < gpuFarmCost)
        {
            buyGpuFarms.interactable = false;
        }

        //Cost check for GPU
        if(currentCompute >= gpuCost)
        {
            buyGpus.interactable = true;
        }
        else if(currentCompute < gpuCost)
        {
            buyGpus.interactable = false;
        }
        
        //Cost check for CPU
        if(currentCompute >= cpuCost)
        {
            buyCpus.interactable = true;
        }
        else if(currentCompute < cpuCost)
        {
            buyCpus.interactable = false;
        }
        
        //Cost check for Microprocessors
        if(currentCompute >= microprocessorCost)
        {
            buyMicroprocessors.interactable = true;
        }
        else if(currentCompute < microprocessorCost)
        {
            buyMicroprocessors.interactable = false;
        }
        
        //Cost check for IC
        if(currentCompute >= icCost)
        {
            buyIc.interactable = true;
        }
        else if(currentCompute < icCost)
        {
            buyIc.interactable = false;
        }

        //Cost check for Gates
        if(currentCompute >= gatesCost)
        {
            buyGates.interactable = true;
        }
        else if(currentCompute < gatesCost)
        {
            buyGates.interactable = false;
        }
        
        //Cost check for Transistors
        if(currentCompute >= transistorCost)
        {
            buyTransistor.interactable = true;
        }
        else if(currentCompute < transistorCost)
        {
            buyTransistor.interactable = false;
        }
    }
    #endregion
}
