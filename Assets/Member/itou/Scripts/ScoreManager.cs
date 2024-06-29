using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public float Score;
    public int Scoremagnification;
    public int EndScore;
    [SerializeField]
    SceneChange scenechange;
    [SerializeField]
    private TextMeshProUGUI scoretext;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (GameUIManager.Instance.IsPauseMenu)
            return;

        Score += Scoremagnification * Time.deltaTime;
        scoretext.text = "" + Score.ToString("0000");
        if (Score >= EndScore)
        {
            scenechange.Happyend = true;
        }
    }
}
