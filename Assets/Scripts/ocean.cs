using UnityEngine;
using UnityEditor;
using System;
using System.Collections.Generic;
using TMPro;
using Random = UnityEngine.Random;
using System.Collections;

public class ocean : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    bool startDay;
    bool endDay;
    public int dayCounter = 1;
    public int weatherCon;
    public Rect fishSpawnArea;
    [SerializeField] GameObject fishingHole;
    [SerializeField] GameObject oceanObject;

    public TMP_Text timerText;
    public float currentTime;

    public bool stopCounting;

    public enum weatherConditions { calm, Storm, Sunny, Cloudy, Snow, Hail, rain };

    public weatherConditions weather;

    public List<GameObject> totalFish = new List<GameObject>();

    private void Awake()
    {
        FishingArea();
        weather = weatherConditions.calm;
        startDay = true;
        SpawnFish(10);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        DayTimer();
        Debug.Log(weather + dayCounter);
    }

    void DayTimer()
    {

        string mins = ((int)currentTime / 60).ToString();
        string Seconds = (currentTime % 60).ToString("f2");

        timerText.text = mins + ":" + Seconds;

        if (currentTime > 10)
        {
            Debug.Log("Day over");
            endDay = true;
            StartCoroutine("EndofDay");
            stopCounting = true;
            currentTime = 0;
        }
        else if (!stopCounting)
        {
            currentTime += Time.deltaTime;
            
        }

        //Debug.Log(currentTime);

    }
    public void SpawnFish(int count)
    {
        for (int i = 0; i < count; i++)
        {
            float xMax = oceanObject.transform.position.x;
            float xPos = (Random.Range(fishSpawnArea.xMin, fishSpawnArea.xMax) / 10) /*- (Screen.width / 4)*/;
            float yPos = (Random.Range(fishSpawnArea.yMin, fishSpawnArea.yMax) / 10) /*- (Screen.height / 4)*/;
            GameObject newFish = Instantiate(fishingHole, new Vector3(xPos, 0, yPos), Quaternion.identity, gameObject.transform);
            newFish.transform.localScale = new Vector3(gameObject.transform.localScale.x * 2, gameObject.transform.localScale.y * 2, gameObject.transform.localScale.z * 2);
            totalFish.Add(newFish);
        }
        
    }

    public void StartNewDay()
    {
        weatherCon = Random.Range(1, 8);
        int fishCount = Random.Range(5, 15);
        dayCounter += 1;
        GenerateWeather(weatherCon);
        SpawnFish(fishCount);
        DayTimer();
    }

    public int GenerateWeather(int number)
    {
        weatherConditions currentDish = weather;

        switch (currentDish)
        {
            case weatherConditions.calm:
                number = 1;
                return number;
            //break;

            case weatherConditions.Cloudy:
                number = 2;
                return number;
            //break;

            case weatherConditions.Hail:
                number = 3;
                return number;
            //break;

            case weatherConditions.rain:
                number = 4;
                return number;
            //break;

            case weatherConditions.Storm:
                number = 5;
                return number;
            //break;

            case weatherConditions.Snow:
                number = 6;
                return number;
            //break;

            case weatherConditions.Sunny:
                number = 7;
                return number;
            //break;

        }

        return 0;
    }

    private IEnumerator EndofDay()
    {
        endDay = true;
        foreach (GameObject fish in totalFish)
        {
            totalFish.Remove(fish);
            Destroy(fish);
        }
        yield return new WaitForSeconds(5);
        StartNewDay();
        endDay = false;
        stopCounting = false;
    }

    public void FishingArea()
    {
        fishSpawnArea = new Rect(0, 0, Screen.width, Screen.height);
    }

    private void OnGUI()
    {
        GUI.Box(fishSpawnArea, "box");
    }
}
