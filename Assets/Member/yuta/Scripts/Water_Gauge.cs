using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Water_Gauge : MonoBehaviour
{
    [SerializeField] PlayerControler PlayerC;
    [SerializeField] Image Water_drop;
    [SerializeField] List<Sprite> Gauge_Pictures;
    [SerializeField] List<Sprite> W_drop_Pictures;

    private Image TimeGage;
    private float time;

    // Start is called before the first frame update
    void Start()
    {
        TimeGage = GetComponent<Image>();
        TimeGage.fillAmount = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerC.type == PlayerControler.SLIME_TYPE.NOMAL)
        {
            TimeGage.sprite = Gauge_Pictures[0];
            Water_drop.sprite = W_drop_Pictures[0];
        }
        else if (PlayerC.type == PlayerControler.SLIME_TYPE.COLA)
        {
            TimeGage.sprite = Gauge_Pictures[1];
            Water_drop.sprite = W_drop_Pictures[1];
        }
        else
        {
            TimeGage.sprite = Gauge_Pictures[2];
            Water_drop.sprite = W_drop_Pictures[2];
        }

        //アイテムゲット時は0.167回復させる(メモリ1個分)
        //ジャンプ時や攻撃時は0.0668失う(メモリ1個の半分)

        //天気で減らす量を変えてり増やしたりする
        //晴れ :- 0.0668(通常の2倍)
        //曇り :- 0.0334(通常)
        //雨   :+ 0.0334(通常の2倍)

        if (PlayerC.gameMode == PlayerControler.SLIME_MODE.RUN)
        {
            time += Time.deltaTime;
            if (time > 1)
            {
                TimeGage.fillAmount -= 0.0334f;
                time = 0;
            }

            Check_TimeGage();
        }
    }

    private void Check_TimeGage()
    {
        if (TimeGage.fillAmount <= 1f && TimeGage.fillAmount >= 0.834f)
        {
            PlayerC.Slime_Size(1);
        }
        else if (TimeGage.fillAmount < 0.834f && TimeGage.fillAmount >= 0.667f)
        {
            PlayerC.Slime_Size(2);
        }
        else if (TimeGage.fillAmount < 0.667f && TimeGage.fillAmount >= 0.5f)
        {
            PlayerC.Slime_Size(3);
        }
        else if (TimeGage.fillAmount < 0.5f && TimeGage.fillAmount >= 0.333f)
        {
            PlayerC.Slime_Size(4);
        }
        else if (TimeGage.fillAmount < 0.333f && TimeGage.fillAmount >= 0.166f)
        {
            PlayerC.Slime_Size(5);
        }
        else if (TimeGage.fillAmount < 0.166f && TimeGage.fillAmount >= 0.001f)
        {
            PlayerC.Slime_Size(6);
        }
        else if (TimeGage.fillAmount == 0)
        {
            PlayerC.Slime_Size(7);
        }
    }

    public void Recovery()
    {
        TimeGage.fillAmount += 0.167f;
    }

    public void Lose()
    {
        TimeGage.fillAmount -= 0.0668f;
        Check_TimeGage();
    }
}
