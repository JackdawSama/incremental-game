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
    [SerializeField] float transistorCompute;
    [SerializeField] float gatesCompute;
    [SerializeField] float icCompute;
    [SerializeField] float microprocessorCompute;
    [SerializeField] float cpuCompute;
    [SerializeField] float gpuCompute;
    [SerializeField] float gpuFarmCompute;

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

    [Header("Slider References")]
    [SerializeField] Slider transistorSlider;
    [SerializeField] Slider gatesSlider;
    [SerializeField] Slider icSlider;
    [SerializeField] Slider microprocessorSlider;
    [SerializeField] Slider cpuSlider;
    [SerializeField] Slider gpuSlider;
    [SerializeField] Slider gpuFarmSlider;

    [Header("Compute Text References")]
    [SerializeField] TextMeshProUGUI totalText;
    [SerializeField] TextMeshProUGUI currentComputeText;

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
        //Set All Timers to 0
        handTimer = 0;
        transistorTimer = 0;
        gatesTimer = 0;
        icTimer = 0;
        microprocessorTimer = 0;
        cpuTimer = 0;

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

        //Set checks
        handCheck = false;

        //Set all button interactability to false
        buyTransistor.interactable = false;
        buyGates.interactable = false;
        buyIc.interactable = false;
        buyMicroprocessors.interactable = false;
        buyCpus.interactable = false;
        buyGpus.interactable = false;
        buyGpuFarms.interactable = false;

        //Set UI Sliders Min Val
        transistorSlider.minValue = 0;
        gatesSlider.minValue = 0;
        icSlider.minValue = 0;
        microprocessorSlider.minValue = 0;
        cpuSlider.minValue = 0;
        gpuSlider.minValue = 0;
        gpuFarmSlider.minValue = 0;

        //Set UI Sliders Max Val
        transistorSlider.maxValue = transistorCooldown;
        gatesSlider.maxValue = gatesCooldown;
        icSlider.maxValue = icCooldown;
        microprocessorSlider.maxValue = microprocessorCooldown;
        cpuSlider.maxValue = cpuCooldown;
        gpuSlider.maxValue = gpuCooldown;
        gpuFarmSlider.maxValue = gpuFarmCooldown; 
    }

    void Update()
    {
        CostsCheck();
        UpdateUI();

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
        //Update UI Sliders
        transistorSlider.value = transistorTimer;
        gatesSlider.value = gatesTimer;
        icSlider.value = icTimer;
        microprocessorSlider.value = microprocessorTimer;
        cpuSlider.value = cpuTimer;
        gpuSlider.value = gpuTimer;
        gpuFarmSlider.value = gpuFarmTimer;

        //Update UI Text
        totalText.text = totalCompute.ToString();
        currentComputeText.text = currentCompute.ToString();

    }

    public void ComputeHandler()
    {
        switch (computeState)
        {
            case ComputeLevel.Lvl0:                 //Initial state. Hand Compute.
                break;

            case ComputeLevel.Lvl1:                 //Transistor State. 1 transistor = 1 data/second
                
                transistorTimer += Time.deltaTime;

                if(transistorTimer >= transistorCooldown)
                {
                    TransistorCompute();
                    transistorTimer = 0;
                }

                break;
            
            case ComputeLevel.Lvl2:                 //Gates State. 1 gate = 5 data/second

                transistorTimer += Time.deltaTime;
                gatesTimer += Time.deltaTime;

                if(transistorTimer >= transistorCooldown)
                {
                    TransistorCompute();
                    transistorTimer = 0;
                }

                if(gatesTimer >= gatesCooldown)
                {
                    GatesCompute();
                    gatesTimer = 0;
                }

                break;
            
            case ComputeLevel.Lvl3:                 //IC State. 1 IC = 20 data/second

                transistorTimer += Time.deltaTime;
                gatesTimer += Time.deltaTime;
                icTimer += Time.deltaTime;

                if(transistorTimer >= transistorCooldown)
                {
                    TransistorCompute();
                    transistorTimer = 0;
                }

                if(gatesTimer >= gatesCooldown)
                {
                    GatesCompute();
                    gatesTimer = 0;
                }

                if(icTimer >= icCooldown)
                {
                    ICCompute();
                    icTimer = 0;
                }

                break;

            case ComputeLevel.Lvl4:                 //Microprocessor State. 1 Microprocessor = 1 data/second
                
                transistorTimer += Time.deltaTime;
                gatesTimer += Time.deltaTime;
                icTimer += Time.deltaTime;
                microprocessorTimer += Time.deltaTime;

                if(transistorTimer >= transistorCooldown)
                {
                    TransistorCompute();
                    transistorTimer = 0;
                }

                if(gatesTimer >= gatesCooldown)
                {
                    GatesCompute();
                    gatesTimer = 0;
                }
                
                if(icTimer >= icCooldown)
                {
                    ICCompute();
                    icTimer = 0;
                }

                if(microprocessorTimer >= microprocessorCooldown)
                {
                    MicroprocessorCompute();
                    microprocessorTimer = 0;
                }

                break;

            case ComputeLevel.Lvl5:                 //CPU State. 1 CPU = 1 data/second
                
                transistorTimer += Time.deltaTime;
                gatesTimer += Time.deltaTime;
                icTimer += Time.deltaTime;
                microprocessorTimer += Time.deltaTime;
                cpuTimer += Time.deltaTime;

                if(transistorTimer >= transistorCooldown)
                {
                    TransistorCompute();
                    transistorTimer = 0;
                }

                if(gatesTimer >= gatesCooldown)
                {
                    GatesCompute();
                    gatesTimer = 0;
                }

                if(icTimer >= icCooldown)
                {
                    ICCompute();
                    icTimer = 0;
                }

                if(microprocessorTimer >= microprocessorCooldown)
                {
                    MicroprocessorCompute();
                    microprocessorTimer = 0;
                }

                if(cpuTimer >= cpuCooldown)
                {
                    CPUCompute();
                    cpuTimer = 0;
                }

                break;
            
            case ComputeLevel.Lvl6:                 //GPU State. 1 GPU = 1 data/second
                
                transistorTimer += Time.deltaTime;
                gatesTimer += Time.deltaTime;
                icTimer += Time.deltaTime;
                microprocessorTimer += Time.deltaTime;
                cpuTimer += Time.deltaTime;
                gpuTimer += Time.deltaTime;

                if(transistorTimer >= transistorCooldown)
                {
                    TransistorCompute();
                    transistorTimer = 0;
                }

                if(gatesTimer >= gatesCooldown)
                {
                    GatesCompute();
                    gatesTimer = 0;
                }

                if(icTimer >= icCooldown)
                {
                    ICCompute();
                    icTimer = 0;
                }

                if(microprocessorTimer >= microprocessorCooldown)
                {
                    MicroprocessorCompute();
                    microprocessorTimer = 0;
                }

                if(cpuTimer >= cpuCooldown)
                {
                    CPUCompute();
                    cpuTimer = 0;
                }

                if(gpuTimer >= gpuCooldown)
                {
                    GPUCompute();
                    gpuTimer = 0;
                }

                break;

            case ComputeLevel.Lvl7:                 //GPU Farms State. 1 GPU Farm = 1 data/second
                
                transistorTimer += Time.deltaTime;
                gatesTimer += Time.deltaTime;
                icTimer += Time.deltaTime;
                microprocessorTimer += Time.deltaTime;
                cpuTimer += Time.deltaTime;
                gpuTimer += Time.deltaTime;
                gpuFarmTimer += Time.deltaTime;

                if(transistorTimer >= transistorCooldown)
                {
                    TransistorCompute();
                    transistorTimer = 0;
                }

                if(gatesTimer >= gatesCooldown)
                {
                    GatesCompute();
                    gatesTimer = 0;
                }

                if(icTimer >= icCooldown)
                {
                    ICCompute();
                    icTimer = 0;
                }

                if(microprocessorTimer >= microprocessorCooldown)
                {
                    MicroprocessorCompute();
                    microprocessorTimer = 0;
                }

                if(cpuTimer >= cpuCooldown)
                {
                    CPUCompute();
                    cpuTimer = 0;
                }

                if(gpuTimer >= gpuCooldown)
                {
                    GPUCompute();
                    gpuTimer = 0;
                }

                if(gpuFarmTimer >= gpuFarmCooldown)
                {
                    GPUFarmCompute();
                    gpuFarmTimer = 0;
                }
                break;

            default:
                break;
        }
    }

    public void BuyTransistor()
    {
        transistorCount++;
        currentCompute -= transistorCost;

        if(transistorCount == 1)
        {
            computeState = ComputeLevel.Lvl1;
        }
    }

    public void BuyGates()
    {
        gatesCount++;
        currentCompute -= gatesCost;

        if(gatesCount == 1)
        {
            computeState = ComputeLevel.Lvl2;
        }
    }

    public void BuyIC()
    {
        icCount++;
        currentCompute -= icCost;

        if(icCount == 1)
        {
            computeState = ComputeLevel.Lvl3;
        }
    }

    public void BuyMicroprocessor()
    {
        microprocessorCount++;
        currentCompute -= microprocessorCost;

        if(microprocessorCount == 1)
        {
            computeState = ComputeLevel.Lvl4;
        }
    }

    public void BuyCPU()
    {
        cpuCount++;
        currentCompute -= cpuCost;

        if(cpuCount == 1)
        {
            computeState = ComputeLevel.Lvl5;
        }
    }

    public void BuyGPU()
    {
        gpuCount++;
        currentCompute -= gpuCost;

        if(gpuCount == 1)
        {
            computeState = ComputeLevel.Lvl6;
        }
    }

    public void BuyGPUFarm()
    {
        gpuFarmCount++;
        currentCompute -= gpuFarmCost;

        if(gpuFarmCount == 1)
        {
            computeState = ComputeLevel.Lvl7;
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

    private void TransistorCompute()
    {
        //Compute
        currentCompute += transistorCompute * transistorCount;
        totalCompute += currentCompute;

        //reset timer
        transistorTimer = 0;
    }

    private void GatesCompute()
    {
        //Compute
        currentCompute += gatesCompute * gatesCount;
        totalCompute += currentCompute;

        //reset timer
        gatesTimer = 0;
    }

    private void ICCompute()
    {
        //Compute
        currentCompute += icCompute * icCount;
        totalCompute += currentCompute;

        //reset timer
        icTimer = 0;
    }

    private void MicroprocessorCompute()
    {
        //Compute
        currentCompute += microprocessorCompute * microprocessorCount;
        totalCompute += currentCompute;

        //reset timer
        microprocessorTimer = 0;
    }

    private void CPUCompute()
    {
        //Compute
        currentCompute += cpuCompute * cpuCount;
        totalCompute += currentCompute;
    }

    private void GPUCompute()
    {
        //Compute
        currentCompute += gpuCompute * gpuCount;
        totalCompute += currentCompute;

        //reset timer
        gpuTimer = 0;
    }

    private void GPUFarmCompute()
    {
        //Compute
        currentCompute += gpuFarmCompute * gpuFarmCount;
        totalCompute += currentCompute;

        //reset timer
        gpuFarmTimer = 0;
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
