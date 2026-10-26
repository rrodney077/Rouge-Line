using UnityEngine;
using UnityEditor;
using System;
using System.Collections.Generic;
using TMPro;
using Random = UnityEngine.Random;
using System.Collections;

public class UIManager : MonoBehaviour
{
    [SerializeField] MeshFilter playerBoat;
    [SerializeField] MeshFilter upgradedBoat;
    [SerializeField] ocean oc;
    GameObject oceanFloor;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        oceanFloor = GameObject.Find("Plane");
        oc = oceanFloor.GetComponent<ocean>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpgradeBoat()
    {
        playerBoat = upgradedBoat;
    }

    public void UpgradeEquipment()
    {
        oc.isUpgraded = true;
    }
}
