using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class Bulllet : MonoBehaviour
{
    [SerializeField] List<Sprite> Slime_Pictures;

    public float Speed;        //オブジェクトのスピード

    private GameObject player;
    private GameObject water_Gauge;
    private GameObject cactus;
    private PlayerControler playerC;
    private Tween tween;
    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        player = GameObject.FindGameObjectWithTag("Player");
        playerC = player.GetComponent<PlayerControler>();
        if(playerC.type == PlayerControler.SLIME_TYPE.NOMAL)
        {
            spriteRenderer.sprite = Slime_Pictures[0];
        }
        else if(playerC.type == PlayerControler.SLIME_TYPE.COLA)
        {
            spriteRenderer.sprite = Slime_Pictures[1];
        }
        else
        {
            spriteRenderer.sprite = Slime_Pictures[2];
        }

        tween = transform.DOScale(new Vector3(0.1f, 0.1f, 0.1f), 1.5f);
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x >= 10.83f)
        {
            StartCoroutine("BulletDestroy");
        }
        else
        {
            transform.position += Vector3.right * (Speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Ground")
        {
            return;
        }

        if(collision.gameObject.tag == "COLA" || collision.gameObject.tag == "ENEGRY")
        {
            StartCoroutine("BulletDestroy");
        }
        else if(collision.gameObject.tag == "Rock" || collision.gameObject.tag == "Cactus")
        {
            if(collision.gameObject.tag == "Cactus")
            {
                cactus = GameObject.FindGameObjectWithTag("Cactus");
                water_Gauge = GameObject.FindGameObjectWithTag("Gauge");
                water_Gauge.GetComponent<Water_Gauge>().Recovery();
                cactus.GetComponent<Cactus>().Cat_Cactus();
            }
            else
            {
                if (playerC.type == PlayerControler.SLIME_TYPE.COLA)
                {
                    Destroy(collision.gameObject);
                }
            }
            StartCoroutine("BulletDestroy");
        }
        else
        {
            Destroy(collision.gameObject);
            StartCoroutine("BulletDestroy");
        }
    }

    IEnumerator BulletDestroy()
    {
        tween.Kill();

        yield return new WaitForSeconds(0.01f);

        Destroy(gameObject);
    }
}
