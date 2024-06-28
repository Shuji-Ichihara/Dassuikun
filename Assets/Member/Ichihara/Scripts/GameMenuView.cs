using R3;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMenuView : MonoBehaviour
{
    #region ButtonName
    private readonly string _guideButtonName = "GuideButton";
    private readonly string _interruptionButtonName = "InterruptionButton";
    private readonly string _exitButtonName = "ExitButton";
    #endregion

    // 操作説明画面を表示するボタン
    [SerializeField]
    private Button _guideButton = null;
    // タイトルに戻る画面を表示するボタン
    [SerializeField]
    private Button _interruptionButton = null;
    // 何もせずにゲーム画面に戻るボタン
    [SerializeField]
    private Button _exitButton = null;

    // 操作説明画面のスクリプト
    [SerializeField]
    private GuideView _guideView = null;
    // タイトルに戻る画面のスクリプト
    [SerializeField]
    private InterruptionView _interruptionView = null;

    // Start is called before the first frame update
    void Start()
    {
        if (_guideButton == null)
            _guideButton = GameObject.Find(_guideButtonName).GetComponent<Button>();
        if (_interruptionButton == null)
            _interruptionButton = GameObject.Find(_interruptionButtonName).GetComponent<Button>();
        if (_exitButton == null)
            _exitButton = GameObject.Find(_exitButtonName).GetComponent<Button>();
        if (_interruptionView == null)
            _interruptionView = GameObject.Find("InterruptionCanvas").GetComponent<InterruptionView>();

        gameObject.SetActive(false);

        // 操作説明画面を表示
        _guideButton.OnClickAsObservable()
                    .ThrottleFirst(System.TimeSpan.FromMilliseconds(1000))
                    .Subscribe(_ => _guideView.GuideViewActivation())
                    .AddTo(this);
        // 中断画面を表示
        _interruptionButton.OnClickAsObservable()
                           .ThrottleFirst(System.TimeSpan.FromMilliseconds(1000))
                           .Subscribe(_ => _interruptionView.InterruptionViewActivation())
                           .AddTo(this);

        // ゲーム画面に戻る
        _exitButton.OnClickAsObservable()
                   .ThrottleFirst(System.TimeSpan.FromMilliseconds(1000))
                   .Subscribe(
                    delegate
                    {
                        MenuDiactivation();
                        GameUIManager.Instance.SetIsActivateMenu(false);
                    })
                   .AddTo(this);
    }

    public void MenuDiactivation()
    {
        gameObject.SetActive(false);
    }

    public void MenuActivation()
    {
        gameObject.SetActive(true);
    }
}
