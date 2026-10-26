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
    [SerializeField] GameObject shopPanel;
    GameObject oceanFloor;
    public TMP_Text moneyText;
    public int money;

    bool isOpen = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        oceanFloor = GameObject.Find("Plane");
        oc = oceanFloor.GetComponent<ocean>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isOpen)
        {
            shopPanel.SetActive(true);
        }
        else
        {
            shopPanel.SetActive(false);
        }
    }

    public void UpgradeBoat()
    {
        if(money > 0)
        {
            playerBoat = upgradedBoat;
            money -= 1;
        }
        else
        {
            print("you cant buy");
        }
        
    }

    public void UpgradeEquipment()
    {
        if(money > 0)
        {
            money -= 1;
            oc.isUpgraded = true;
        }
        else
        {
            print("you can't buy");
        }
        
    }

    public void OpenPanel()
    {
        // shopPanel.SetActive(shopPanel.activeSelf);

        isOpen = !isOpen;
    }

    public void Sell()
    {
        if(oc.fishCount > 0)
        {
            int sellAmount = oc.fishCount * 7;
            money += sellAmount;
            print(oc.fishCount + " SOLD");
        }
        else
        {
            print("you have nothing to sell");
        }
        
        moneyText.text = "$" + money; 
    }
}
