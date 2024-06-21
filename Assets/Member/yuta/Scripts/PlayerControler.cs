using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    [SerializeField] GameObject Eye_Right;
    [SerializeField] GameObject Eye_Left;
    [SerializeField] GameObject Eye_Right_A;
    [SerializeField] GameObject Eye_Left_A;
    [SerializeField] GameObject Bullet;
    [SerializeField] Transform BulletPoint;
    [SerializeField] Animator P_Animator;

    public float JumpPower;             //ジャンプ力

    private Rigidbody2D rbody;          //プレイヤー制御用Rigidbody2D

    private float timeLimit;
    private bool finish;
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

    // Start is called before the first frame update
    void Start()
    {
        transform.localScale = Vector2.one;
        SlimeEye_Posi(1);
        finish = false;
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
                action = true;
            }

            if (Input.GetKey(KeyCode.A) && !action)
            {
                P_Animator.SetTrigger("Attack");
                gameMode = SLIME_MODE.ATTACK;
                Instantiate(Bullet, BulletPoint.position, Quaternion.identity);
                action = true;
            }

            if (gameMode == SLIME_MODE.RUN)
            {
                timeLimit += Time.deltaTime;
                if (timeLimit > 1f && !finish)
                {
                    transform.localScale = new Vector2(transform.localScale.x - 0.1f, transform.localScale.y - 0.1f);
                    SlimeEye_Posi(1);
                    timeLimit = 0;
                }

                //0.5までジャンプ可能
                //0.4
                if (transform.localScale.x <= 0.5f)
                {
                    finish = true;
                    //gameMode = SLIME_MODE.DEATH;
                    Debug.Log("ガ目オペラ");
                }

                if(transform.localScale.x <= 0.4f && !action)
                {
                    //finish = true;
                    P_Animator.SetTrigger("Death");
                    gameMode = SLIME_MODE.DEATH;
                }
            }
        }
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
                Eye_Left_A.transform.position = new Vector2(Eye_Left_A.transform.position.x, Eye_Left_A.transform.position.y - 0.065f);
                break;

            //ジャンプ２
            case 3:
                if(transform.localScale.x > 0.9f)
                {
                    Eye_Left_A.transform.position = new Vector2(Eye_Left_A.transform.position.x, Eye_Left_A.transform.position.y + 1.15f);
                }
                if(transform.localScale.x <= 0.9f && transform.localScale.x > 0.8f)
                {
                    Eye_Left_A.transform.position = new Vector2(Eye_Left_A.transform.position.x, Eye_Left_A.transform.position.y + 1.05f);
                }
                else if(transform.localScale.x <= 0.8f && transform.localScale.x > 0.7f)
                {
                    Eye_Left_A.transform.position = new Vector2(Eye_Left_A.transform.position.x, Eye_Left_A.transform.position.y + 0.95f);
                }
                else if(transform.localScale.x <= 0.7f && transform.localScale.x > 0.6f)
                {
                    Eye_Left_A.transform.position = new Vector2(Eye_Left_A.transform.position.x, Eye_Left_A.transform.position.y + 0.81f);
                }
                else if(transform.localScale.x <= 0.6f && transform.localScale.x > 0.5f)
                {
                    Eye_Left_A.transform.position = new Vector2(Eye_Left_A.transform.position.x, Eye_Left_A.transform.position.y + 0.71f);
                }
                else if(transform.localScale.x <= 0.5f)
                {
                    Debug.Log("チェック");
                    Eye_Left_A.transform.position = new Vector2(Eye_Left_A.transform.position.x, Eye_Left_A.transform.position.y + 0.62f);
                }
                break;
        }
    }

    public void SlimeJump()
    {
        rbody.AddForce(Vector2.up * JumpPower);
        SlimeEye_Posi(3);
    }

    public void Jump_Finish()
    {
        action = false;
        gameMode = SLIME_MODE.RUN;
    }

    public void Attack_Finish()
    {
        action = false;
        gameMode = SLIME_MODE.RUN;
    }

    public void Damage_Finish()
    {
        action = false;
        gameMode = SLIME_MODE.RUN;
    }

    //当たり判定用
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Bullet")
        {
            return;
        }
        Destroy(collision.gameObject);
        gameMode = SLIME_MODE.DAMAGE;
        transform.localScale = new Vector2(transform.localScale.x - 0.1f, transform.localScale.y - 0.1f);
        SlimeEye_Posi(1);
        P_Animator.SetTrigger("Damage");
        action = true;
    }
}
