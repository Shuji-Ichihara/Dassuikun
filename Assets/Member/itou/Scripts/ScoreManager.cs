using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public float Score;
    public int Scoremagnification;
    public int EndScore;
    [SerializeField]
    SceneChange scenechange;
    [SerializeField]
    private Text scoretext;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Score += Scoremagnification * Time.deltaTime;
        scoretext.text = "" + Score.ToString("0000");
        if(Score >= EndScore) 
        {
            scenechange.Happyend = true;
        }
    }
}
