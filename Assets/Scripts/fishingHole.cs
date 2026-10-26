using UnityEngine;
using UnityEditor;
using System;
using System.Collections.Generic;
using Random = UnityEngine.Random;

public class fishingHole : ocean
{
    public int dangerLevel;
    public string condition;

    public void Awake()
    {
        weatherConditions currentWeather = weather;

        switch (currentWeather)
        {
            case weatherConditions.calm:
                condition = "calm";
                return;
            //break;

            case weatherConditions.Cloudy:
                condition = "cloudy";
                return;
            //break;

            case weatherConditions.Hail:
                condition = "hail";
                return;
            //break;

            case weatherConditions.rain:
                condition = "rain";
                return;
            //break;

            case weatherConditions.Storm:
                condition = "storm";
                return;
            //break;

            case weatherConditions.Snow:
                condition = "snow";
                return;
            //break;

            case weatherConditions.Sunny:
                condition = "sunny";
                return;
                //break;
        }

        return;
        print(condition);
        Debug.Log(weather);

        /* if(weather == weatherConditions.calm)
         {
             print("CALM");
         }*/

        fishYield = calculateFishYield(weatherCon);

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
