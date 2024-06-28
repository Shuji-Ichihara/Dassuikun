using R3;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public struct TutorialPage
{
    public string TutorialTitle;
    public Sprite TutorialPageImage;
}

public class GuideView : MonoBehaviour
{
    #region ButtonName
    private readonly string _returnButtonName = "ReturnButton";
    private readonly string _nextTutotialButtonName = "NextButton";
    private readonly string _prevTutorialButtonName = "BackButton";
    #endregion
    #region ComponentName
    private readonly string _guideImageName = "GuideImage";
    private readonly string _titleTextName = "Title";
    #endregion

    // 各チュートリアル画面のタイトルと画像
    [SerializeField]
    private List<TutorialPage> _tutorialPages = new List<TutorialPage>();
    // チュートリアル画面の表示先
    [SerializeField]
    private Image _guideImage = null;

    // メニュー画面に戻るボタン
    [SerializeField]
    private Button _returnButton = null;
    // 次のチュートリアル画面に進むボタン
    [SerializeField]
    private Button _nextTutorialButton = null;
    // 前のチュートリアル画面に戻るボタン
    [SerializeField]
    private Button _prevTutorialButton = null;

    // チュートリアル画面のタイトルテキスト
    [SerializeField]
    private TextMeshProUGUI _titleText = null;
    // 現在表示されているチュートリアル画面
    private int _tutorialCount = 0;


    // Start is called before the first frame update
    void Start()
    {
        #region 初期化
        if (_returnButton == null)
            _returnButton = GameObject.Find(_returnButtonName).GetComponent<Button>();
        if (_nextTutorialButton == null)
            _nextTutorialButton = GameObject.Find(_nextTutotialButtonName).GetComponent<Button>();
        if (_prevTutorialButton == null)
            _prevTutorialButton = GameObject.Find(_prevTutorialButtonName).GetComponent<Button>();
        #endregion
        gameObject.SetActive(false);
        // メニュー画面に戻る
        _returnButton.OnClickAsObservable()
                     .ThrottleFirst(System.TimeSpan.FromMilliseconds(1000))
                     .Subscribe(_ => gameObject.SetActive(false))
                     .AddTo(this);
        // Nextボタンを押したら、次のチュートリアル画面を表示する
        _nextTutorialButton.OnClickAsObservable()
                           .Where(_ => _tutorialCount < _tutorialPages.Count - 1)
                           .ThrottleFirst(System.TimeSpan.FromMilliseconds(1000))
                           .Subscribe(
                            delegate
                            {
                                _tutorialCount++;
                                _guideImage.sprite = _tutorialPages[_tutorialCount].TutorialPageImage;
                            })
                           .AddTo(this);
        // Backボタンを押したら、次のチュートリアル画面を表示する
        _prevTutorialButton.OnClickAsObservable()
                           .Where(_ => _tutorialCount > 0)
                           .ThrottleFirst(System.TimeSpan.FromMilliseconds(1000))
                           .Subscribe(
                            delegate
                            {
                                _tutorialCount--;
                                _guideImage.sprite = _tutorialPages[_tutorialCount].TutorialPageImage;

                            })
                           .AddTo(this);
    }

    private void Update()
    {
        if (_tutorialCount == 0 && _nextTutorialButton.gameObject.activeSelf == false)
        {
            _prevTutorialButton.gameObject.SetActive(false);
            _nextTutorialButton.gameObject.SetActive(true);
        }
        if (_tutorialCount >= _tutorialPages.Count - 1 && _prevTutorialButton.gameObject.activeSelf == false)
        {
            _nextTutorialButton.gameObject.SetActive(false);
            _prevTutorialButton.gameObject.SetActive(false);
        }
        _titleText.text = GetPreviewTutorialTitle(_tutorialCount);
    }

    private string GetPreviewTutorialTitle(int index)
    {
        return _tutorialPages[index].TutorialTitle;
    }

    public void GuideViewActivation()
    {
        gameObject.SetActive(true);
    }
}
