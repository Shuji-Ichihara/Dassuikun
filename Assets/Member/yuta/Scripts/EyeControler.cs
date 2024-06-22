using System.Collections.Generic;
using UnityEngine;

public class EyeControler : MonoBehaviour
{
    [SerializeField] PlayerControler PlayerC;
    [SerializeField] GameObject EyeBrows;
    [SerializeField] List<Sprite> Eye_Pictures;
    [SerializeField] SpriteRenderer Eye_Sprite;
    [SerializeField] Animator Eye_Anime;

    private SpriteRenderer spriteRenderer;

    //ÉQÅ[ÉÄèÛë‘íËã`
    public enum Eye
    {
        RIGHT,
        LEFT,
    }

    public Eye eye;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (eye == Eye.RIGHT)
        {
            switch (PlayerC.gameMode)
            {
                case PlayerControler.SLIME_MODE.RUN:
                    spriteRenderer.enabled = false;
                    Eye_Sprite.enabled = true;
                    Eye_Anime.enabled = true;
                    EyeBrows.gameObject.SetActive(false);
                    break;
                case PlayerControler.SLIME_MODE.JUMP:
                    spriteRenderer.enabled = true;
                    Eye_Sprite.enabled = false;
                    Eye_Anime.enabled = false;
                    spriteRenderer.sprite = Eye_Pictures[0];
                    EyeBrows.gameObject.SetActive(true);
                    break;
                case PlayerControler.SLIME_MODE.ATTACK:
                    spriteRenderer.enabled = true;
                    Eye_Sprite.enabled = false;
                    Eye_Anime.enabled = false;
                    spriteRenderer.sprite = Eye_Pictures[0];
                    EyeBrows.gameObject.SetActive(true);
                    break;
                case PlayerControler.SLIME_MODE.DAMAGE:
                    spriteRenderer.enabled = true;
                    Eye_Sprite.enabled = false;
                    Eye_Anime.enabled = false;
                    spriteRenderer.sprite = Eye_Pictures[2];
                    EyeBrows.gameObject.SetActive(false);
                    break;
                case PlayerControler.SLIME_MODE.DEATH:
                    spriteRenderer.enabled = true;
                    Eye_Sprite.enabled = false;
                    Eye_Anime.enabled = false;
                    spriteRenderer.sprite = Eye_Pictures[4];
                    EyeBrows.gameObject.SetActive(false);
                    break;
            }
        }
        else
        {
            switch (PlayerC.gameMode)
            {
                case PlayerControler.SLIME_MODE.RUN:
                    spriteRenderer.enabled = false;
                    Eye_Sprite.enabled = true;
                    Eye_Anime.enabled = true;
                    EyeBrows.gameObject.SetActive(false);
                    break;
                case PlayerControler.SLIME_MODE.JUMP:
                    spriteRenderer.enabled = true;
                    Eye_Sprite.enabled = false;
                    Eye_Anime.enabled = false;
                    spriteRenderer.sprite = Eye_Pictures[0];
                    EyeBrows.gameObject.SetActive(true);
                    break;
                case PlayerControler.SLIME_MODE.ATTACK:
                    spriteRenderer.enabled = true;
                    Eye_Sprite.enabled = false;
                    Eye_Anime.enabled = false;
                    spriteRenderer.sprite = Eye_Pictures[1];
                    EyeBrows.gameObject.SetActive(true);
                    break;
                case PlayerControler.SLIME_MODE.DAMAGE:
                    spriteRenderer.enabled = true;
                    Eye_Sprite.enabled = false;
                    Eye_Anime.enabled = false;
                    spriteRenderer.sprite = Eye_Pictures[3];
                    EyeBrows.gameObject.SetActive(false);
                    break;
                case PlayerControler.SLIME_MODE.DEATH:
                    spriteRenderer.enabled = false;
                    Eye_Sprite.enabled = false;
                    Eye_Anime.enabled = false;
                    EyeBrows.gameObject.SetActive(false);
                    break;
            }
        }
            
    }
}
