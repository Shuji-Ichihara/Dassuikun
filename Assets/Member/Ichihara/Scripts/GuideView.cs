using R3;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GuideView : MonoBehaviour
{
    #region ButtonName
    private readonly string _returnButtonName = "ReturnButton";
    #endregion

    [SerializeField]
    private Button _returnButton = null;

    // Start is called before the first frame update
    void Start()
    {
        if (_returnButton == null)
            _returnButton = GameObject.Find(_returnButtonName).GetComponent<Button>();
        _returnButton.OnClickAsObservable()
                     .ThrottleFirst(System.TimeSpan.FromMilliseconds(1000))
                     .Subscribe(_ => gameObject.SetActive(false))
                     .AddTo(this);
    }

    public void GuideViewActivation()
    {
        gameObject.SetActive(true);
    }
}
