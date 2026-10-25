using UnityEngine;
using UnityEditor;
using System;
using System.Collections.Generic;
using Random = UnityEngine.Random;

public class fishingHole : ocean
{
    public int dangerLevel;

    private void Awake()
    {
        if(calculateDifficulty() == GenerateWeather(weatherCon))
        {
            print("YIPPEE");
        }
    }

    public int calculateDifficulty()
    {
        int number;
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
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
