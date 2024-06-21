using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[DisallowMultipleComponent]
public class SceneChange : MonoBehaviour
{
    GameObject ManageObject;
    FadeScene fadeSceneManager;
    public bool Happyend;
    // Start is called before the first frame update
    void Start()
    {
        //SceneFadeManagerがアタッチされているオブジェクトを取得
        ManageObject = GameObject.Find("SceneChangeObject");
        //オブジェクトの中のSceneFadeManagerを取得
        fadeSceneManager = ManageObject.GetComponent<FadeScene>();
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name != "GameScene")
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                //SceneFadeManagerがアタッチされているオブジェクトを取得
                ManageObject = GameObject.Find("SceneChangeObject");
                //オブジェクトの中のSceneFadeManagerを取得
                fadeSceneManager = ManageObject.GetComponent<FadeScene>();
                SceneChanges();
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                SceneChanges();
            }
        }
    }

    public void SceneChanges()
    {
        if (SceneManager.GetActiveScene().name == "GameScene")
        {
            if (Happyend == true)
            {
                //SceneFadeManagerの中のフェードアウト開始関数を呼び出し
                fadeSceneManager.fadeOutStart(0, 0, 0, 0, "HappyEnd");
                Happyend = false;
            }
            else if(Happyend == false)
            {
                //SceneFadeManagerの中のフェードアウト開始関数を呼び出し
                fadeSceneManager.fadeOutStart(0, 0, 0, 0, "GameOver");
            }
        }
        else if (SceneManager.GetActiveScene().name == "Title")
        {
            //SceneFadeManagerの中のフェードアウト開始関数を呼び出し
            fadeSceneManager.fadeOutStart(0, 0, 0, 0, "GameScene");
        }
        else if (SceneManager.GetActiveScene().name == "GameOver")
        {
            //SceneFadeManagerの中のフェードアウト開始関数を呼び出し
            fadeSceneManager.fadeOutStart(0, 0, 0, 0, "Title");
            fadeSceneManager.Destorycount += 1;
        }
        else if (SceneManager.GetActiveScene().name == "HappyEnd")
        {
            //SceneFadeManagerの中のフェードアウト開始関数を呼び出し
            fadeSceneManager.fadeOutStart(0, 0, 0, 0, "Title");
            fadeSceneManager.Destorycount += 1;
        }
    }
}
