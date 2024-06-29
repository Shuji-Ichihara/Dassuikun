using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BGMPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().name == SceneChange.Instance.SceneNames[0])
        {
            AudioManager.Instance.PlayBGM(BGMType.TitleBGM);
        }
        if (SceneManager.GetActiveScene().name == SceneChange.Instance.SceneNames[1])
        {
            AudioManager.Instance.PlayBGM(BGMType.GameBGM);
        }
        else if (SceneManager.GetActiveScene().name == SceneChange.Instance.SceneNames[2])
        {
            AudioManager.Instance.PlayBGM(BGMType.ClearBGM);
        }
        else if (SceneManager.GetActiveScene().name == SceneChange.Instance.SceneNames[3])
        {
            AudioManager.Instance.PlayBGM(BGMType.GameOverBGM);
        }

    }
}
