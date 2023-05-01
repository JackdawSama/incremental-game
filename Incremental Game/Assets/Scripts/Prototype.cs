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

    [Header("Compute Variables")]
    public float totalCompute;
    public float currentCompute;
    [SerializeField] float handCompute;

    [Header("Compute Checks")]
    [SerializeField] bool handCheck;

    [Header("Timer Variables")]
    float handTimer;
    [SerializeField] float handCooldown;

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

    void Start()
    {
        //Set all Component References to Inactive


        //Set All Timers to 0
        handTimer = 0;

        //Set checks
        handCheck = true;

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
        ActivateUI();
        CostsCheck();
        UpdateUI();

        if(!handCheck)
        {
            handTimer += Time.deltaTime;
        }

        if(handTimer >= handCooldown)
        {
            handCheck = true;
            handTimer = 0;
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
    }

    public void ActivateUI()
    {
        if(totalCompute == transistorCost)
        {
            buyTransistor.gameObject.SetActive(true);
            transistorSlider.gameObject.SetActive(true);
            transistorCountText.gameObject.SetActive(true);
        }

        if(totalCompute == gatesCost)
        {
            Debug.Log("Gates UI Activated");
            buyGates.gameObject.SetActive(true);
            gatesSlider.gameObject.SetActive(true);
            gatesCountText.gameObject.SetActive(true);
        }

        if(totalCompute == icCost)
        {
            Debug.Log("IC UI Activated");
            buyIc.gameObject.SetActive(true);
            icSlider.gameObject.SetActive(true);
            icCountText.gameObject.SetActive(true);
        }

        if(totalCompute == microprocessorCost)
        {
            buyMicroprocessors.gameObject.SetActive(true);
            microprocessorSlider.gameObject.SetActive(true);
            microprocessorCountText.gameObject.SetActive(true);
        }

        if(totalCompute == cpuCost)
        {
            buyCpus.gameObject.SetActive(true);
            cpuSlider.gameObject.SetActive(true);
            cpuCountText.gameObject.SetActive(true);
        }

        if(totalCompute == gpuCost)
        {
            buyGpus.gameObject.SetActive(true);
            gpuSlider.gameObject.SetActive(true);
            gpuCountText.gameObject.SetActive(true);
        }

        if(totalCompute == gpuFarmCost)
        {
            buyGpuFarms.gameObject.SetActive(true);
            gpuFarmSlider.gameObject.SetActive(true);
            gpuFarmCountText.gameObject.SetActive(true);
        }
    }

    public void BuyTransistor()
    {
        transistor.Buy();
        currentCompute -= transistorCost;
    }

    public void BuyGates()
    {
        gates.Buy();
        currentCompute -= gatesCost;
    }

    public void BuyIC()
    {
        ic.Buy();
        currentCompute -= icCost;
    }

    public void BuyMicroprocessor()
    {
        microprocessor.Buy();
        currentCompute -= microprocessorCost;
    }

    public void BuyCPU()
    {
        cpu.Buy();
        currentCompute -= cpuCost;
    }

    public void BuyGPU()
    {
        gpu.Buy();
        currentCompute -= gpuCost;
    }

    public void BuyGPUFarm()
    {
        gpu.Buy();
        currentCompute -= gpuFarmCost;
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
