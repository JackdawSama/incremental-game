using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    [Header("Units Count")]
    [SerializeField] int transistorCount = 0;
    [SerializeField] int gatesCount = 0;
    [SerializeField] int icCount = 0;
    [SerializeField] int processingUnitsCount = 0;

    void Start()
    {
        currentCompute = baseCompute;   
    }

    void Compute()
    {
        totalCompute += currentCompute;
    }

    void UpgradeCompute(string value)
    {
        if(value == "Transistor")
        {
            transistorCount++;
            currentCompute = Mathf.Pow(transistorIncrement, transistorCount) * baseCompute;
        }
    }
}
