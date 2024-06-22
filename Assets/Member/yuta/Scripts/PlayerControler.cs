using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    [SerializeField] Water_Gauge water_Gauge;

    [SerializeField] List<Sprite> Slime_Pictures;
    [SerializeField] GameObject Eye_Right;
    [SerializeField] GameObject Eye_Left;
    [SerializeField] GameObject Eye_Right_A;
    [SerializeField] GameObject Eye_Left_A;
    [SerializeField] GameObject Bullet;
    [SerializeField] Transform BulletPoint;
    [SerializeField] Animator P_Animator;

    //public float JumpPower;             //ジャンプ力

    private Rigidbody2D rbody;          //プレイヤー制御用Rigidbody2D
    private SpriteRenderer slime_Sprite;

    private float changeTime;
    private bool action;

    //ゲーム状態定義
    public enum SLIME_MODE
    {
        RUN,                         
        JUMP,                        
        ATTACK,                      
        DAMAGE,                      
        DEATH,                       
    }

    public SLIME_MODE gameMode = SLIME_MODE.RUN; //ゲーム状態

    public enum SLIME_TYPE
    {
        NOMAL,
        COLA,
        ENEGRY,
    }

    public SLIME_TYPE type = SLIME_TYPE.NOMAL;

    // Start is called before the first frame update
    void Start()
    {
        slime_Sprite = GetComponent<SpriteRenderer>();
        slime_Sprite.sprite = Slime_Pictures[0];

        Slime_Size(1);
        SlimeEye_Posi(1);
        action = false;

        rbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(gameMode != SLIME_MODE.DEATH)
        {
            if (Input.GetKey(KeyCode.Space) && !action)
            {
                P_Animator.SetTrigger("Jump");
                gameMode = SLIME_MODE.JUMP;
                water_Gauge.Lose();
                action = true;
            }

            if (Input.GetKey(KeyCode.A) && !action)
            {
                P_Animator.SetTrigger("Attack");
                gameMode = SLIME_MODE.ATTACK;
                Instantiate(Bullet, BulletPoint.position, Quaternion.identity);
                water_Gauge.Lose();
                action = true;
            }

            if (gameMode == SLIME_MODE.RUN)
            {
                if(transform.localScale.x <= 0.4f && !action)
                {
                    P_Animator.SetTrigger("Death");
                    type = SLIME_TYPE.NOMAL;
                    gameMode = SLIME_MODE.DEATH;
                }
            }
        }
        
        if(type == SLIME_TYPE.ENEGRY || type == SLIME_TYPE.COLA)
        {
            changeTime += Time.deltaTime;
            if (changeTime > 10f)
            {
                type = SLIME_TYPE.NOMAL;
            }
        }
    }

    //スライムサイズ
    public void Slime_Size(int i)
    {
        switch(i)
        {
            case 1:
                transform.localScale = new Vector2(1f, 1f);
                break;
            case 2:
                transform.localScale = new Vector2(0.9f, 0.9f);
                break;
            case 3:
                transform.localScale = new Vector2(0.8f, 0.8f);
                break;
            case 4:
                transform.localScale = new Vector2(0.7f, 0.7f);
                break;
            case 5:
                transform.localScale = new Vector2(0.6f, 0.6f);
                break;
            case 6:
                transform.localScale = new Vector2(0.5f, 0.5f);
                break;
            case 7:
                transform.localScale = new Vector2(0.4f, 0.4f);
                break;
        }

        SlimeEye_Posi(1);
    }

    //スライムの目
    public void SlimeEye_Posi(int i)
    {
        switch (i)
        {
            //通常目 と ジャンプ３
            case 1:
                if (transform.localScale.x > 0.9f)
                {
                    Eye_Right.transform.localScale = new Vector2(1.1f, 1.1f);
                    Eye_Left.transform.position = new Vector2(transform.position.x, transform.position.y + 1.45f);
                    Eye_Left.transform.localScale = new Vector2(1.1f, 1.1f);

                    Eye_Right_A.transform.localScale = new Vector2(1.1f, 1.1f);
                    Eye_Left_A.transform.position = new Vector2(transform.position.x, transform.position.y + 1.45f);
                    Eye_Left_A.transform.localScale = new Vector2(1.1f, 1.1f);
                }
                if (transform.localScale.x <= 0.9f && transform.localScale.x > 0.8f)
                {
                    Eye_Right.transform.localScale = new Vector2(1.15f, 1.15f);
                    Eye_Left.transform.position = new Vector2(transform.position.x, transform.position.y + 1.29f);
                    Eye_Left.transform.localScale = new Vector2(1.15f, 1.15f);

                    Eye_Right_A.transform.localScale = new Vector2(1.15f, 1.15f);
                    Eye_Left_A.transform.position = new Vector2(transform.position.x, transform.position.y + 1.29f);
                    Eye_Left_A.transform.localScale = new Vector2(1.15f, 1.15f);
                }
                else if (transform.localScale.x <= 0.8f && transform.localScale.x > 0.7f)
                {
                    Eye_Right.transform.localScale = new Vector2(1.38f, 1.38f);
                    Eye_Left.transform.position = new Vector2(transform.position.x - 0.2f, transform.position.y + 1.167f);
                    Eye_Left.transform.localScale = new Vector2(1.38f, 1.38f);

                    Eye_Right_A.transform.localScale = new Vector2(1.38f, 1.38f);
                    Eye_Left_A.transform.position = new Vector2(transform.position.x - 0.2f, transform.position.y + 1.167f);
                    Eye_Left_A.transform.localScale = new Vector2(1.38f, 1.38f);
                }
                else if (transform.localScale.x <= 0.7f && transform.localScale.x > 0.6f)
                {
                    Eye_Right.transform.localScale = new Vector2(1.56f, 1.56f);
                    Eye_Left.transform.position = new Vector2(transform.position.x - 0.25f, transform.position.y + 1.02f);
                    Eye_Left.transform.localScale = new Vector2(1.56f, 1.56f);

                    Eye_Right_A.transform.localScale = new Vector2(1.56f, 1.56f);
                    Eye_Left_A.transform.position = new Vector2(transform.position.x - 0.25f, transform.position.y + 1.02f);
                    Eye_Left_A.transform.localScale = new Vector2(1.56f, 1.56f);
                }
                else if (transform.localScale.x <= 0.6f && transform.localScale.x > 0.5f)
                {
                    Eye_Right.transform.localScale = new Vector2(1.81f, 1.81f);
                    Eye_Left.transform.position = new Vector2(transform.position.x - 0.3f, transform.position.y + 0.87f);
                    Eye_Left.transform.localScale = new Vector2(1.81f, 1.81f);

                    Eye_Right_A.transform.localScale = new Vector2(1.81f, 1.81f);
                    Eye_Left_A.transform.position = new Vector2(transform.position.x - 0.3f, transform.position.y + 0.87f);
                    Eye_Left_A.transform.localScale = new Vector2(1.81f, 1.81f);
                }
                else if (transform.localScale.x <= 0.5f && transform.localScale.x > 0.4f)
                {
                    Eye_Right.transform.localScale = new Vector2(2.16f, 2.16f);
                    Eye_Left.transform.position = new Vector2(transform.position.x - 0.35f, transform.position.y + 0.73f);
                    Eye_Left.transform.localScale = new Vector2(2.16f, 2.16f);

                    Eye_Right_A.transform.localScale = new Vector2(2.16f, 2.16f);
                    Eye_Left_A.transform.position = new Vector2(transform.position.x - 0.35f, transform.position.y + 0.73f);
                    Eye_Left_A.transform.localScale = new Vector2(2.16f, 2.16f);
                }
                else if (transform.localScale.x <= 0.4f)
                {
                    Eye_Right.transform.localScale = new Vector2(2.68f, 2.68f);
                    Eye_Left.transform.position = new Vector2(transform.position.x - 0.35f, transform.position.y + 0.58f);
                    Eye_Left.transform.localScale = new Vector2(2.68f, 2.68f);

                    Eye_Right_A.transform.localScale = new Vector2(2.68f, 2.68f);
                    Eye_Left_A.transform.position = new Vector2(transform.position.x - 0.35f, transform.position.y + 0.58f);
                    Eye_Left_A.transform.localScale = new Vector2(2.68f, 2.68f);
                }
                break;

            //ジャンプ１
            case 2:
                if (transform.localScale.x > 0.9f)
                {
                    Eye_Left_A.transform.position = new Vector2(Eye_Left_A.transform.position.x, Eye_Left_A.transform.position.y - 0.15f);
                }
                if (transform.localScale.x <= 0.9f && transform.localScale.x > 0.8f)
                {
                    Eye_Left_A.transform.position = new Vector2(Eye_Left_A.transform.position.x, Eye_Left_A.transform.position.y - 0.095f);
                }
                else if (transform.localScale.x <= 0.8f && transform.localScale.x > 0.7f)
                {
                    Eye_Left_A.transform.position = new Vector2(Eye_Left_A.transform.position.x, Eye_Left_A.transform.position.y - 0.09f);
                }
                else if (transform.localScale.x <= 0.7f && transform.localScale.x > 0.6f)
                {
                    Eye_Left_A.transform.position = new Vector2(Eye_Left_A.transform.position.x, Eye_Left_A.transform.position.y - 0.09f);
                }
                else if (transform.localScale.x <= 0.6f && transform.localScale.x > 0.5f)
                {
                    Eye_Left_A.transform.position = new Vector2(Eye_Left_A.transform.position.x, Eye_Left_A.transform.position.y - 0.088f);
                }
                else if (transform.localScale.x <= 0.5f)
                {
                    Eye_Left_A.transform.position = new Vector2(Eye_Left_A.transform.position.x, Eye_Left_A.transform.position.y - 0.088f);
                }
                break;

            //ジャンプ２
            case 3:
                if(transform.localScale.x > 0.9f)
                {
                    Eye_Left_A.transform.position = new Vector2(Eye_Left_A.transform.position.x, Eye_Left_A.transform.position.y + 1.25f);
                }
                if(transform.localScale.x <= 0.9f && transform.localScale.x > 0.8f)
                {
                    Eye_Left_A.transform.position = new Vector2(Eye_Left_A.transform.position.x, Eye_Left_A.transform.position.y + 1.125f);
                }
                else if(transform.localScale.x <= 0.8f && transform.localScale.x > 0.7f)
                {
                    Eye_Left_A.transform.position = new Vector2(Eye_Left_A.transform.position.x, Eye_Left_A.transform.position.y + 0.95f);
                }
                else if(transform.localScale.x <= 0.7f && transform.localScale.x > 0.6f)
                {
                    Eye_Left_A.transform.position = new Vector2(Eye_Left_A.transform.position.x, Eye_Left_A.transform.position.y + 0.89f);
                }
                else if(transform.localScale.x <= 0.6f && transform.localScale.x > 0.5f)
                {
                    Eye_Left_A.transform.position = new Vector2(Eye_Left_A.transform.position.x, Eye_Left_A.transform.position.y + 0.73f);
                }
                else if(transform.localScale.x <= 0.5f)
                {
                    Eye_Left_A.transform.position = new Vector2(Eye_Left_A.transform.position.x, Eye_Left_A.transform.position.y + 0.62f);
                }
                break;
        }
    }

    public void SlimeJump()
    {
        if(type == SLIME_TYPE.ENEGRY)
        {
            rbody.gravityScale = 0.7f;
            rbody.AddForce(Vector2.up * 550);
        }
        else
        {
            rbody.gravityScale = 2f;
            rbody.AddForce(Vector2.up * 700);
        }
        SlimeEye_Posi(3);
    }

    public void Action_Finish()
    {
        action = false;
        gameMode = SLIME_MODE.RUN;
    }

    //当たり判定用
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(gameMode != SLIME_MODE.DEATH)
        {
            if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Bullet")
            {
                return;
            }

            //アイテムの当たり判定
            if (collision.gameObject.tag == "COLA")
            {
                changeTime = 0;
                type = SLIME_TYPE.COLA;
                water_Gauge.Recovery();
            }
            else if (collision.gameObject.tag == "ENEGRY")
            {
                changeTime = 0;
                type = SLIME_TYPE.ENEGRY;
                water_Gauge.Recovery();
            }
            else if (collision.gameObject.tag == "Cactus")
            {

            }
            else
            {
                gameMode = SLIME_MODE.DAMAGE;
                water_Gauge.Lose();
                P_Animator.SetTrigger("Damage");
                action = true;
            }
            Destroy(collision.gameObject);
        }
    }

    //姿変更
    public void Slime_ChangeType(int i)
    {
        slime_Sprite = GetComponent<SpriteRenderer>();
        switch (i)
        {
            //歩き1＆ジャンプ3＆攻撃＆死亡
            case 1:
                if(type == SLIME_TYPE.NOMAL)
                {
                    slime_Sprite.sprite = Slime_Pictures[0];
                }
                else if(type == SLIME_TYPE.COLA)
                {
                    slime_Sprite.sprite = Slime_Pictures[3];
                }
                else
                {
                    if (gameMode == SLIME_MODE.ATTACK)
                    {
                        slime_Sprite.sprite = Slime_Pictures[9];
                    }
                    else
                    {
                        slime_Sprite.sprite = Slime_Pictures[6];
                    }
                }
                break;
            //歩き2
            case 2:
                if (type == SLIME_TYPE.NOMAL)
                {
                    slime_Sprite.sprite = Slime_Pictures[1];
                }
                else if (type == SLIME_TYPE.COLA)
                {
                    slime_Sprite.sprite = Slime_Pictures[4];
                }
                else
                {
                    slime_Sprite.sprite = Slime_Pictures[7];
                }
                break;
            //歩き3
            case 3:
                if (type == SLIME_TYPE.NOMAL)
                {
                    slime_Sprite.sprite = Slime_Pictures[2];
                }
                else if (type == SLIME_TYPE.COLA)
                {
                    slime_Sprite.sprite = Slime_Pictures[5];
                }
                else
                {
                    slime_Sprite.sprite = Slime_Pictures[8];
                }
                break;
            //ジャンプ1
            case 4:
                if (type == SLIME_TYPE.NOMAL)
                {
                    slime_Sprite.sprite = Slime_Pictures[10];
                }
                else if (type == SLIME_TYPE.COLA)
                {
                    slime_Sprite.sprite = Slime_Pictures[12];
                }
                else
                {
                    slime_Sprite.sprite = Slime_Pictures[14];
                }
                break;
            //ジャンプ2
            case 5:
                if (type == SLIME_TYPE.NOMAL)
                {
                    slime_Sprite.sprite = Slime_Pictures[11];
                }
                else if (type == SLIME_TYPE.COLA)
                {
                    slime_Sprite.sprite = Slime_Pictures[13];
                }
                else
                {
                    slime_Sprite.sprite = Slime_Pictures[15];
                }
                break;
            //ダメージ
            case 6:
                if (type == SLIME_TYPE.NOMAL)
                {
                    slime_Sprite.sprite = Slime_Pictures[16];
                }
                else if (type == SLIME_TYPE.COLA)
                {
                    slime_Sprite.sprite = Slime_Pictures[17];
                }
                else
                {
                    slime_Sprite.sprite = Slime_Pictures[18];
                }
                break;
        }
    }
}
