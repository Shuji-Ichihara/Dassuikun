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
        //SceneFadeManager���A�^�b�`����Ă���I�u�W�F�N�g���擾
        ManageObject = GameObject.Find("SceneChangeObject");
        //�I�u�W�F�N�g�̒���SceneFadeManager���擾
        fadeSceneManager = ManageObject.GetComponent<FadeScene>();
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name != "GameScene")
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                //SceneFadeManager���A�^�b�`����Ă���I�u�W�F�N�g���擾
                ManageObject = GameObject.Find("SceneChangeObject");
                //�I�u�W�F�N�g�̒���SceneFadeManager���擾
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
                //SceneFadeManager�̒��̃t�F�[�h�A�E�g�J�n�֐����Ăяo��
                fadeSceneManager.fadeOutStart(0, 0, 0, 0, "HappyEnd");
                Happyend = false;
            }
            else if(Happyend == false)
            {
                //SceneFadeManager�̒��̃t�F�[�h�A�E�g�J�n�֐����Ăяo��
                fadeSceneManager.fadeOutStart(0, 0, 0, 0, "GameOver");
            }
        }
        else if (SceneManager.GetActiveScene().name == "Title")
        {
            //SceneFadeManager�̒��̃t�F�[�h�A�E�g�J�n�֐����Ăяo��
            fadeSceneManager.fadeOutStart(0, 0, 0, 0, "GameScene");
        }
        else if (SceneManager.GetActiveScene().name == "GameOver")
        {
            //SceneFadeManager�̒��̃t�F�[�h�A�E�g�J�n�֐����Ăяo��
            fadeSceneManager.fadeOutStart(0, 0, 0, 0, "Title");
            fadeSceneManager.Destorycount += 1;
        }
        else if (SceneManager.GetActiveScene().name == "HappyEnd")
        {
            //SceneFadeManager�̒��̃t�F�[�h�A�E�g�J�n�֐����Ăяo��
            fadeSceneManager.fadeOutStart(0, 0, 0, 0, "Title");
            fadeSceneManager.Destorycount += 1;
        }
    }
}
