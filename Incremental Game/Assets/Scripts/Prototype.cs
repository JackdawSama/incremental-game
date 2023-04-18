using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Prototype : MonoBehaviour
{
    [Header("Compute Variables")]
    [SerializeField] float totalCompute;
    [SerializeField] float baseCompute;
    [SerializeField] float currentCompute;

    [Header("Increment Values")]
    [SerializeField] float transistorIncrement = 1.2f;
    [SerializeField] float gatesIncrement = 1.5f;
    [SerializeField] float icIncrement = 2f;
    [SerializeField] float processingUnitsIncrement = 2.5f;

    [Header("Button References")]
    [SerializeField] Button computeButton;
    [SerializeField] Button buyTransistor;
    [SerializeField] Button buyGates;
    [SerializeField] Button buyIc;
    [SerializeField] Button buyProcessingUnits;

    [Header("Text References")]
    [SerializeField] TextMeshProUGUI computeText;

    [Header("Units Count")]
    [SerializeField] int transistorCount = 0;
    [SerializeField] int gatesCount = 0;
    [SerializeField] int icCount = 0;
    [SerializeField] int processingUnitsCount = 0;

    void Start()
    {
        currentCompute = baseCompute;
        buyTransistor.interactable = false; 
    }

    void Update()
    {
        if(totalCompute >= 100)
        {
            buyTransistor.interactable = true;
        }
        else
        {
            buyTransistor.interactable = false;
        }

        UpdateUI();
    }

    void UpdateUI()
    {
        computeText.text = totalCompute.ToString() + "bits";
    }
    public void Compute()
    {
        totalCompute += currentCompute;
    }

    public void BuyTransistor()
    {
        transistorCount++;
        currentCompute = Mathf.Pow(transistorIncrement, transistorCount) * baseCompute;
        totalCompute -= 100;
    }
}
