using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Bulllet : MonoBehaviour
{
    public float Speed;        //オブジェクトのスピード

    Tween tween;

    // Start is called before the first frame update
    void Start()
    {
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
        //Ground
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Ground")
        {
            return;
        }
        Destroy(collision.gameObject);
        StartCoroutine("BulletDestroy");
    }

    IEnumerator BulletDestroy()
    {
        tween.Kill();

        yield return new WaitForSeconds(0.01f);

        Destroy(gameObject);
    }
}
