using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static WetherList;

public class WetherChange : MonoBehaviour
{
    private WeatherState currentWeather;
    [SerializeField]
    private float changeInterval; // �V���ς���Ԋu�i�b�j
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
        // �����_���ɓV���I��
        currentWeather = (WeatherState)Random.Range(0, 3);

        // �V��ɉ��������������s
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
        // ����̂Ƃ��̏����������ɏ���
    }

    void SetCloudy()
    {
        Debug.Log("Weather changed to Cloudy.");
        // �܂�̂Ƃ��̏����������ɏ���
    }

    void SetRainy()
    {
        Debug.Log("Weather changed to Rainy.");
        // �J�̂Ƃ��̏����������ɏ���
    }
}
