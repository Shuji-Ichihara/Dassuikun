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

        //�A�C�e���Q�b�g����0.167�񕜂�����(������1��)
        //�W�����v����U������0.0668����(������1�̔���)

        //�V�C�Ō��炷�ʂ�ς��Ă葝�₵���肷��
        //���� :- 0.0668(�ʏ��2�{)
        //�܂� :- 0.0334(�ʏ�)
        //�J   :+ 0.0334(�ʏ��2�{)

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
