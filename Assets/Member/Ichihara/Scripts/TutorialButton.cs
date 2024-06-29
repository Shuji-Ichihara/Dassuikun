using R3;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialButton : MonoBehaviour
{
    private Button _tutorialButton = null;
    [SerializeField]
    private Canvas _guideView = null;

    // Start is called before the first frame update
    void Start()
    {
        _tutorialButton = GetComponent<Button>();
        _tutorialButton.OnClickAsObservable()
                       .ThrottleFirst(System.TimeSpan.FromMilliseconds(1000))
                       .Subscribe(_ => _guideView.gameObject.SetActive(true))
                       .AddTo(this);
    }
}
