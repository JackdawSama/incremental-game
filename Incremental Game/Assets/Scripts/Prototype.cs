using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Prototype : MonoBehaviour
{
    [Header("Component References")]
    [SerializeField] ComponentSys transistor;
    [SerializeField] ComponentSys gates;
    [SerializeField] ComponentSys ic;
    [SerializeField] ComponentSys microprocessor;
    [SerializeField] ComponentSys cpu;
    [SerializeField] ComponentSys gpu;
    [SerializeField] ComponentSys gpuFarm;

    [Header("Power Requirement")]
    [SerializeField] float currentPower;
    [SerializeField] float maxPower = 500f;
    [SerializeField] int powerIncCount;

    [SerializeField] float basePowerCost;
    [SerializeField] float powerCost;

    [Header("Compute Variables")]
    public float totalCompute;
    public float currentCompute;
    public float maxCompute;
    [SerializeField] float handCompute;

    [Header("Checks")]
    [SerializeField] bool gameOver = false;
    [SerializeField] bool handCheck;

    [Header("Timer Variables")]
    float handTimer;
    [SerializeField] float handCooldown;
    float globalTimer;

    [Header("Heading Text")]
    [SerializeField] TextMeshProUGUI unitHeadingText;
    [SerializeField] TextMeshProUGUI countHeadingText;
    [SerializeField] TextMeshProUGUI costHeadingText;
    [SerializeField] TextMeshProUGUI powerHeadingText;

    [Header("Button References")]
    [SerializeField] Button restartGameButton;
    [SerializeField] Button computeButton;
    [SerializeField] Button buyTransistor;
    [SerializeField] Button buyGates;
    [SerializeField] Button buyIc;
    [SerializeField] Button buyMicroprocessors;
    [SerializeField] Button buyCpus;
    [SerializeField] Button buyGpus;
    [SerializeField] Button buyGpuFarms;
    [SerializeField] Button buyPower;

    [Header("Slider References")]
    [SerializeField] Slider handSlider;
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
    [SerializeField] TextMeshProUGUI transistorCountText;
    [SerializeField] TextMeshProUGUI gatesCountText;
    [SerializeField] TextMeshProUGUI icCountText;
    [SerializeField] TextMeshProUGUI microprocessorCountText;
    [SerializeField] TextMeshProUGUI cpuCountText;
    [SerializeField] TextMeshProUGUI gpuCountText;
    [SerializeField] TextMeshProUGUI gpuFarmCountText;

    [Header("Timer Text References")]
    [SerializeField] TextMeshProUGUI globalTimerText;

    [Header("Power Text References")]
    [SerializeField] Color powerColorGood;
    [SerializeField] Color powerColorMed;
    [SerializeField] Color powerColorHigh;
    [SerializeField] TextMeshProUGUI powerText;
    [SerializeField] TextMeshProUGUI powerCostText;
    float powerColorThreshold;

    [Header("Cost Text References")]
    [SerializeField] TextMeshProUGUI transistorCostText;
    [SerializeField] TextMeshProUGUI gatesCostText;
    [SerializeField] TextMeshProUGUI icCostText;
    [SerializeField] TextMeshProUGUI microprocessorCostText;
    [SerializeField] TextMeshProUGUI cpuCostText;
    [SerializeField] TextMeshProUGUI gpuCostText;
    [SerializeField] TextMeshProUGUI gpuFarmCostText;

    [Header("Game Over Text")]
    [SerializeField] TextMeshProUGUI gameOverText;

    void Start()
    {
        //Set Costs
        powerCost = basePowerCost;

        //Set All Timers to 0
        globalTimer = 0;
        handTimer = 0;

        //Set checks
        handCheck = true;
        gameOver = false;

        //Set GameOver text to Inactive
        gameOverText.gameObject.SetActive(false);
        restartGameButton.gameObject.SetActive(false);

        //Set All Buttons to Inactive
        buyTransistor.gameObject.SetActive(false);
        buyGates.gameObject.SetActive(false);
        buyIc.gameObject.SetActive(false);
        buyMicroprocessors.gameObject.SetActive(false);
        buyCpus.gameObject.SetActive(false);
        buyGpus.gameObject.SetActive(false);
        buyGpuFarms.gameObject.SetActive(false);

        //Set All Sliders to Inactive
        transistorSlider.gameObject.SetActive(false);
        gatesSlider.gameObject.SetActive(false);
        icSlider.gameObject.SetActive(false);
        microprocessorSlider.gameObject.SetActive(false);
        cpuSlider.gameObject.SetActive(false);
        gpuSlider.gameObject.SetActive(false);
        gpuFarmSlider.gameObject.SetActive(false);

        //Set All Count Text to Inactive
        transistorCountText.gameObject.SetActive(false);
        gatesCountText.gameObject.SetActive(false);
        icCountText.gameObject.SetActive(false);
        microprocessorCountText.gameObject.SetActive(false);
        cpuCountText.gameObject.SetActive(false);
        gpuCountText.gameObject.SetActive(false);
        gpuFarmCountText.gameObject.SetActive(false);

        //Set All Cost Text to Inactive
        transistorCostText.gameObject.SetActive(false);
        gatesCostText.gameObject.SetActive(false);
        icCostText.gameObject.SetActive(false);
        microprocessorCostText.gameObject.SetActive(false);
        cpuCostText.gameObject.SetActive(false);
        gpuCostText.gameObject.SetActive(false);
        gpuFarmCostText.gameObject.SetActive(false);

        //Set all button interactability to false
        buyTransistor.interactable = false;
        buyGates.interactable = false;
        buyIc.interactable = false;
        buyMicroprocessors.interactable = false;
        buyCpus.interactable = false;
        buyGpus.interactable = false;
        buyGpuFarms.interactable = false;

        //Set UI Sliders Min Val
        handSlider.minValue = 0;
        transistorSlider.minValue = 0;
        gatesSlider.minValue = 0;
        icSlider.minValue = 0;
        microprocessorSlider.minValue = 0;
        cpuSlider.minValue = 0;
        gpuSlider.minValue = 0;
        gpuFarmSlider.minValue = 0;

        //Set UI Sliders Max Val
        handSlider.maxValue = handCooldown;
        transistorSlider.maxValue = transistor.cooldown;
        gatesSlider.maxValue = gates.cooldown;
        icSlider.maxValue = ic.cooldown;
        microprocessorSlider.maxValue = microprocessor.cooldown;
        cpuSlider.maxValue = cpu.cooldown;
        gpuSlider.maxValue = gpu.cooldown;
        gpuFarmSlider.maxValue = gpuFarm.cooldown; 
    }

    void Update()
    {

        if(!gameOver)
        {
            globalTimer += Time.deltaTime;
            ActivateUI();
            CostsCheck();
            UpdateUI();
        }

        if(!handCheck)
        {
            handTimer += Time.deltaTime;
        }

        if(handTimer >= handCooldown)
        {
            handCheck = true;
            handTimer = 0;
        }

        if(currentPower >= maxPower)
        {
            //Set Lose state
            gameOver = true;
            DeactivateUI();
            Debug.Log("Power Surge");
            gameOverText.gameObject.SetActive(true);
            gameOverText.text = "Power Surge @ : " + globalTimerText.text +
                                "\n" + "All Data Corrupted";

            restartGameButton.gameObject.SetActive(true);
            DeactivateSystems();
        }

        if(totalCompute >= maxCompute)
        {
            //Set Win State
            gameOver = true;
            DeactivateUI();
            Debug.Log("Data Compilation Complete @ : " + globalTimerText.text);
            gameOverText.gameObject.SetActive(true);
            gameOverText.text = "Data Compilation Complete @ : " + globalTimerText.text + "\n" +
                                "With" + transistor.count + " Transistors" + "\n" +
                                       + gates.count + " Gates" + "\n" +
                                       + ic.count + " ICs" + "\n" +
                                       + microprocessor.count + " Microprocessors" + "\n" +
                                       + cpu.count + " CPUs" + "\n" +
                                       + gpu.count + " GPUs" + "\n" +
                                       + gpuFarm.count + " GPU Farms";

            restartGameButton.gameObject.SetActive(true);
            DeactivateSystems();
        }
    }

    void UpdateUI()
    {
        //Update UI Sliders
        handSlider.value = handTimer;
        transistorSlider.value = transistor.timer;
        gatesSlider.value = gates.timer;
        icSlider.value = ic.timer;
        microprocessorSlider.value = microprocessor.timer;
        cpuSlider.value = cpu.timer;
        gpuSlider.value = gpu.timer;
        gpuFarmSlider.value = gpuFarm.timer;

        //Update Data Text
        totalText.text = totalCompute.ToString();
        currentComputeText.text = currentCompute.ToString();

        //Update Count Text
        transistorCountText.text = transistor.count.ToString();
        gatesCountText.text = gates.count.ToString();
        icCountText.text = ic.count.ToString();
        microprocessorCountText.text = microprocessor.count.ToString();
        cpuCountText.text = cpu.count.ToString();
        gpuCountText.text = gpu.count.ToString();
        gpuFarmCountText.text = gpuFarm.count.ToString();

        //Update Cost Text
        transistorCostText.text = transistor.cost.ToString();
        gatesCostText.text = gates.cost.ToString();
        icCostText.text = ic.cost.ToString();
        microprocessorCostText.text = microprocessor.cost.ToString();
        cpuCostText.text = cpu.cost.ToString();
        gpuCostText.text = gpu.cost.ToString();
        gpuFarmCostText.text = gpuFarm.cost.ToString();

        //Update Power Text
        CalculateCurrentPower();
        SetPowerTextColour();
        powerCostText.text = "Power Cost : " + powerCost.ToString();
        powerText.text = currentPower.ToString() + " / " + maxPower.ToString();

        //Update Time
        DisplayTime(globalTimer);
    }

    public void ActivateUI()
    {
        if(totalCompute >= transistor.baseCost)
        {
            buyTransistor.gameObject.SetActive(true);
            transistorSlider.gameObject.SetActive(true);
            transistorCountText.gameObject.SetActive(true);
            transistorCostText.gameObject.SetActive(true);
        }

        if(totalCompute >= gates.baseCost)
        {
            buyGates.gameObject.SetActive(true);
            gatesSlider.gameObject.SetActive(true);
            gatesCountText.gameObject.SetActive(true);
            gatesCostText.gameObject.SetActive(true);
        }

        if(totalCompute >= ic.baseCost)
        {
            buyIc.gameObject.SetActive(true);
            icSlider.gameObject.SetActive(true);
            icCountText.gameObject.SetActive(true);
            icCostText.gameObject.SetActive(true);
        }

        if(totalCompute >= microprocessor.baseCost)
        {
            buyMicroprocessors.gameObject.SetActive(true);
            microprocessorSlider.gameObject.SetActive(true);
            microprocessorCountText.gameObject.SetActive(true);
            microprocessorCostText.gameObject.SetActive(true);
        }

        if(totalCompute >= cpu.baseCost)
        {
            buyCpus.gameObject.SetActive(true);
            cpuSlider.gameObject.SetActive(true);
            cpuCountText.gameObject.SetActive(true);
            cpuCostText.gameObject.SetActive(true);
        }

        if(totalCompute >= gpu.baseCost)
        {
            buyGpus.gameObject.SetActive(true);
            gpuSlider.gameObject.SetActive(true);
            gpuCountText.gameObject.SetActive(true);
            gpuCostText.gameObject.SetActive(true);
        }

        if(totalCompute >= gpuFarm.baseCost)
        {
            buyGpuFarms.gameObject.SetActive(true);
            gpuFarmSlider.gameObject.SetActive(true);
            gpuFarmCountText.gameObject.SetActive(true);
            gpuFarmCostText.gameObject.SetActive(true);
        }
    }

    void DeactivateUI()
    {
        //Set All Buttons to Inactive
        computeButton.gameObject.SetActive(false);
        buyTransistor.gameObject.SetActive(false);
        buyGates.gameObject.SetActive(false);
        buyIc.gameObject.SetActive(false);
        buyMicroprocessors.gameObject.SetActive(false);
        buyCpus.gameObject.SetActive(false);
        buyGpus.gameObject.SetActive(false);
        buyGpuFarms.gameObject.SetActive(false);
        buyPower.gameObject.SetActive(false);

        //Set All Sliders to Inactive
        handSlider.gameObject.SetActive(false);
        transistorSlider.gameObject.SetActive(false);
        gatesSlider.gameObject.SetActive(false);
        icSlider.gameObject.SetActive(false);
        microprocessorSlider.gameObject.SetActive(false);
        cpuSlider.gameObject.SetActive(false);
        gpuSlider.gameObject.SetActive(false);
        gpuFarmSlider.gameObject.SetActive(false);

        //Set All Count Text to Inactive
        transistorCountText.gameObject.SetActive(false);
        gatesCountText.gameObject.SetActive(false);
        icCountText.gameObject.SetActive(false);
        microprocessorCountText.gameObject.SetActive(false);
        cpuCountText.gameObject.SetActive(false);
        gpuCountText.gameObject.SetActive(false);
        gpuFarmCountText.gameObject.SetActive(false);

        //Set All Cost Text to Inactive
        transistorCostText.gameObject.SetActive(false);
        gatesCostText.gameObject.SetActive(false);
        icCostText.gameObject.SetActive(false);
        microprocessorCostText.gameObject.SetActive(false);
        cpuCostText.gameObject.SetActive(false);
        gpuCostText.gameObject.SetActive(false);
        gpuFarmCostText.gameObject.SetActive(false);

        //Set All Power Text to Inactive
        powerCostText.gameObject.SetActive(false);
        powerText.gameObject.SetActive(false);

        //Set All Heading Text to Inactive
        unitHeadingText.gameObject.SetActive(false);
        countHeadingText.gameObject.SetActive(false);
        costHeadingText.gameObject.SetActive(false);
        powerHeadingText.gameObject.SetActive(false);

        //Set all button interactability to false
        buyTransistor.interactable = false;
        buyGates.interactable = false;
        buyIc.interactable = false;
        buyMicroprocessors.interactable = false;
        buyCpus.interactable = false;
        buyGpus.interactable = false;
        buyGpuFarms.interactable = false;
    }

    void DeactivateSystems()
    {
        transistor.gameObject.SetActive(false);
        gates.gameObject.SetActive(false);
        ic.gameObject.SetActive(false);
        microprocessor.gameObject.SetActive(false);
        cpu.gameObject.SetActive(false);
        gpu.gameObject.SetActive(false);
        gpuFarm.gameObject.SetActive(false);
    }

    public void RestartGame()
    {
        //Renable Systems
        transistor.gameObject.SetActive(true);
        gates.gameObject.SetActive(true);
        ic.gameObject.SetActive(true);
        microprocessor.gameObject.SetActive(true);
        cpu.gameObject.SetActive(true);
        gpu.gameObject.SetActive(true);
        gpuFarm.gameObject.SetActive(true);

        //Reset Values
        totalCompute = 0;
        currentCompute = 0;
        currentPower = 0;

        //Reset Costs
        powerCost = basePowerCost;

        //Reset All Timers to 0
        globalTimer = 0;
        handTimer = 0;

        //Reset checks
        handCheck = true;
        gameOver = false;

        //Reset GameOver text to Inactive
        gameOverText.gameObject.SetActive(false);
        restartGameButton.gameObject.SetActive(false);

        //Reset Compute Button to Active
        computeButton.gameObject.SetActive(true);

        //Reset All Buttons to Inactive
        buyTransistor.gameObject.SetActive(false);
        buyGates.gameObject.SetActive(false);
        buyIc.gameObject.SetActive(false);
        buyMicroprocessors.gameObject.SetActive(false);
        buyCpus.gameObject.SetActive(false);
        buyGpus.gameObject.SetActive(false);
        buyGpuFarms.gameObject.SetActive(false);

        //Reset Upgrade Power Button to Active
        buyPower.gameObject.SetActive(true);

        //Reset Compute Slider to Active
        handSlider.gameObject.SetActive(true);

        //Reset All Sliders to Inactive
        transistorSlider.gameObject.SetActive(false);
        gatesSlider.gameObject.SetActive(false);
        icSlider.gameObject.SetActive(false);
        microprocessorSlider.gameObject.SetActive(false);
        cpuSlider.gameObject.SetActive(false);
        gpuSlider.gameObject.SetActive(false);
        gpuFarmSlider.gameObject.SetActive(false);

        //Reset All Count Text to Inactive
        transistorCountText.gameObject.SetActive(false);
        gatesCountText.gameObject.SetActive(false);
        icCountText.gameObject.SetActive(false);
        microprocessorCountText.gameObject.SetActive(false);
        cpuCountText.gameObject.SetActive(false);
        gpuCountText.gameObject.SetActive(false);
        gpuFarmCountText.gameObject.SetActive(false);

        //Reset All Cost Text to Inactive
        transistorCostText.gameObject.SetActive(false);
        gatesCostText.gameObject.SetActive(false);
        icCostText.gameObject.SetActive(false);
        microprocessorCostText.gameObject.SetActive(false);
        cpuCostText.gameObject.SetActive(false);
        gpuCostText.gameObject.SetActive(false);
        gpuFarmCostText.gameObject.SetActive(false);

        //Set All Power Text to Active
        powerCostText.gameObject.SetActive(true);
        powerText.gameObject.SetActive(true);

        //Set All Heading Text to Active
        unitHeadingText.gameObject.SetActive(true);
        countHeadingText.gameObject.SetActive(true);
        costHeadingText.gameObject.SetActive(true);
        powerHeadingText.gameObject.SetActive(true);

        //Reset all button interactability to false
        buyTransistor.interactable = false;
        buyGates.interactable = false;
        buyIc.interactable = false;
        buyMicroprocessors.interactable = false;
        buyCpus.interactable = false;
        buyGpus.interactable = false;
        buyGpuFarms.interactable = false;

        //Reset UI Sliders Min Val
        handSlider.minValue = 0;
        transistorSlider.minValue = 0;
        gatesSlider.minValue = 0;
        icSlider.minValue = 0;
        microprocessorSlider.minValue = 0;
        cpuSlider.minValue = 0;
        gpuSlider.minValue = 0;
        gpuFarmSlider.minValue = 0;

        //Reset UI Sliders Max Val
        handSlider.maxValue = handCooldown;
        transistorSlider.maxValue = transistor.cooldown;
        gatesSlider.maxValue = gates.cooldown;
        icSlider.maxValue = ic.cooldown;
        microprocessorSlider.maxValue = microprocessor.cooldown;
        cpuSlider.maxValue = cpu.cooldown;
        gpuSlider.maxValue = gpu.cooldown;
        gpuFarmSlider.maxValue = gpuFarm.cooldown;
    }

    public void BuyTransistor()
    {
        currentCompute -= transistor.cost;
        transistor.Buy();
    }

    public void BuyGates()
    {
        currentCompute -= gates.cost;
        gates.Buy();
    }

    public void BuyIC()
    {
        currentCompute -= ic.cost;
        ic.Buy();
    }

    public void BuyMicroprocessor()
    {
        currentCompute -= microprocessor.cost;
        microprocessor.Buy();
    }

    public void BuyCPU()
    {
        currentCompute -= cpu.cost;
        cpu.Buy();
    }

    public void BuyGPU()
    {
        currentCompute -= gpu.cost;
        gpu.Buy();
    }

    public void BuyGPUFarm()
    {
        currentCompute -= gpuFarm.cost;
        gpuFarm.Buy();
    }

    public void HandCompute()
    {
        if(handCheck)
        {
            handCheck = false;
            
            //Compute
            currentCompute += handCompute;
            totalCompute += handCompute;

            //reset timer
            handTimer = 0;
        }
    }

    float CalculateCurrentPower()
    {
        currentPower =  transistor.power 
                        + gates.power
                        + ic.power
                        + microprocessor.power
                        + cpu.power
                        + gpu.power
                        + gpuFarm.power;

        return currentPower;
    }

    void SetPowerTextColour()
    {
        powerColorThreshold = currentPower / maxPower;

        if(powerColorThreshold >= 0.75f)
        {
            powerText.color = powerColorHigh;
        }
        else if(powerColorThreshold >= 0.35f)
        {
            powerText.color = powerColorMed;
        }
        else if(powerColorThreshold < 0.35f)
        {
            powerText.color = powerColorGood;
        }
    }

    void DisplayTime(float time)
    {
        float minutes = Mathf.FloorToInt(time / 60);
        float seconds = Mathf.FloorToInt(time % 60);
        globalTimerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void IncreaseMaxPower()
    {
        powerIncCount++;

        maxPower = maxPower + (powerIncCount * 50f);
        powerCost = basePowerCost * (1 + (powerIncCount/10f));
    }

    #region COST CHECKS
    public void CostsCheck()
    {
        //Cost check for GPU Farms
        if(currentCompute >= gpuFarm.cost)
        {
            buyGpuFarms.interactable = true;
        }
        else if(currentCompute < gpuFarm.cost)
        {
            buyGpuFarms.interactable = false;
        }

        //Cost check for GPU
        if(currentCompute >= gpu.cost)
        {
            buyGpus.interactable = true;
        }
        else if(currentCompute < gpu.cost)
        {
            buyGpus.interactable = false;
        }
        
        //Cost check for CPU
        if(currentCompute >= cpu.cost)
        {
            buyCpus.interactable = true;
        }
        else if(currentCompute < cpu.cost)
        {
            buyCpus.interactable = false;
        }
        
        //Cost check for Microprocessors
        if(currentCompute >= microprocessor.cost)
        {
            buyMicroprocessors.interactable = true;
        }
        else if(currentCompute < microprocessor.cost)
        {
            buyMicroprocessors.interactable = false;
        }
        
        //Cost check for IC
        if(currentCompute >= ic.cost)
        {
            buyIc.interactable = true;
        }
        else if(currentCompute < ic.cost)
        {
            buyIc.interactable = false;
        }

        //Cost check for Gates
        if(currentCompute >= gates.cost)
        {
            buyGates.interactable = true;
        }
        else if(currentCompute < gates.cost)
        {
            buyGates.interactable = false;
        }
        
        //Cost check for Transistors
        if(currentCompute >= transistor.cost)
        {
            buyTransistor.interactable = true;
        }
        else if(currentCompute < transistor.cost)
        {
            buyTransistor.interactable = false;
        }

        //Cost check for Power
        if(currentCompute >= powerCost)
        {
            buyPower.interactable = true;
        }
        else if(currentCompute < powerCost)
        {
            buyPower.interactable = false;
        }
    }
    #endregion
}
