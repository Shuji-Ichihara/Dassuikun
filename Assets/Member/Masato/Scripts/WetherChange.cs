using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static WetherList;

public class WetherChange : MonoBehaviour
{
    private WeatherState currentWeather;
    [SerializeField]
    private float changeInterval; // 天候を変える間隔（秒）
    private float changeTimer;

    void Start()
    {
        changeTimer = changeInterval;
        ChangeWeather();
    }

    void Update()
    {
        changeTimer -= Time.deltaTime;
        if (changeTimer <= 0f)
        {
            ChangeWeather();
            changeTimer = changeInterval;
        }
    }

    void ChangeWeather()
    {
        // ランダムに天候を選択
        currentWeather = (WeatherState)Random.Range(0, 3);

        // 天候に応じた処理を実行
        switch (currentWeather)
        {
            case WeatherState.Sunny:
                SetSunny();
                break;
            case WeatherState.Cloudy:
                SetCloudy();
                break;
            case WeatherState.Rainy:
                SetRainy();
                break;
        }
    }

    void SetSunny()
    {
        Debug.Log("Weather changed to Sunny.");
        // 晴れのときの処理をここに書く
    }

    void SetCloudy()
    {
        Debug.Log("Weather changed to Cloudy.");
        // 曇りのときの処理をここに書く
    }

    void SetRainy()
    {
        Debug.Log("Weather changed to Rainy.");
        // 雨のときの処理をここに書く
    }
}
