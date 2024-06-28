using R3;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUIManager : SingletonMonoBehaviour<GameUIManager>
{
    #region ButtonName
    private readonly string _menuButtonName = "MenuButton";
    #endregion

    // メニュー機能スクリプト
    [SerializeField]
    private GameMenuView _gameMenu = null;
    // メニュー画面を表示するボタン
    [SerializeField]
    private Button _menuButton = null;
    // 現在適用しているアイテムを表示
    [SerializeField]
    private Image _holdItemView = null;

    [SerializeField]
    private List<Sprite> _itemSprites = new List<Sprite>();

    // スライムのスクリプト
    private PlayerControler _playerControler = null;
    // メニュー画面を表示しているかを判定する
    private bool _isPauseMenu = false;
    public bool IsPauseMenu
    {
        get
        {
            return _isPauseMenu;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        if (_gameMenu == null)
            _gameMenu = GameObject.Find("MenuUICanvas").GetComponent<GameMenuView>();
        if (_menuButton == null)
            _menuButton = GameObject.Find(_menuButtonName).GetComponent<Button>();
        if (_holdItemView == null)
            _holdItemView = GameObject.Find("HoldItemView").GetComponent<Image>();
        _playerControler = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControler>();
        // メニュー画面表示
        _menuButton.OnClickAsObservable()
                   .Where(_ => IsPauseMenu == false)
                   .ThrottleFirst(System.TimeSpan.FromMilliseconds(1000))
                   .Subscribe(
                   delegate
                   {
                       _gameMenu.MenuActivation();
                       SetIsActivateMenu(true);
                   })
                   .AddTo(this);
    }

    private void Update()
    {
        //_holdItemView.sprite = PreviewHoldItem();
    }

    private Sprite PreviewHoldItem()
    {
        Sprite sprite = null;
        switch (_playerControler.type)
        {
            case PlayerControler.SLIME_TYPE.NOMAL:
                _holdItemView.enabled = false;
                break;
            case PlayerControler.SLIME_TYPE.COLA:
                _holdItemView.enabled = true;
                sprite = _itemSprites[0];
                break;
            case PlayerControler.SLIME_TYPE.ENEGRY:
                _holdItemView.enabled = true;
                sprite = _itemSprites[1];
                break;
            default:
                break;
        }
        return sprite;
    }

    public void SetIsActivateMenu(bool value)
    {
        _isPauseMenu = value;
    }
}
