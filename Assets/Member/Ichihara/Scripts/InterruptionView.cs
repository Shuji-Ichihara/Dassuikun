using R3;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InterruptionView : MonoBehaviour
{
    #region ButtonName
    private readonly string _toTitleButtonName = "ToTitleButton";
    private readonly string _returnButtonName = "ReturnButton";
    #endregion

    // このボタンを押したら、タイトル画面に戻る
    [SerializeField]
    private Button _toTitleButton = null;
    // このボタンを押したら、何もせずにメニュー画面に戻る
    [SerializeField]
    private Button _returnButton = null;

    // Start is called before the first frame update
    void Start()
    {
        if (_toTitleButton == null)
            _toTitleButton = GameObject.Find(_toTitleButtonName).GetComponent<Button>();
        if (_returnButton == null)
            _returnButton = GameObject.Find(_returnButtonName).GetComponent<Button>();
        gameObject.SetActive(false);
        _toTitleButton.OnClickAsObservable()
                      .ThrottleFirst(System.TimeSpan.FromMilliseconds(1000))
                      .Subscribe(_ =>
                           // タイトルに戻る
                           SceneChange.Instance.SceneChanges())
                      .AddTo(this);
        _returnButton.OnClickAsObservable()
                     .ThrottleFirst(System.TimeSpan.FromMilliseconds(1000))
                     .Subscribe(_ =>
                          // メニュー画面に戻る
                          gameObject.SetActive(false))
                     .AddTo(this);
    }

    public void InterruptionViewActivation()
    {
        gameObject.SetActive(true);
    }
}
