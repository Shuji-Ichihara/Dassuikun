using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapScroll : MonoBehaviour
{
    public GameObject[] backgroundPrefabs; // 背景マップのPrefab配列
    [SerializeField]
    private int initialBackgroundCount; // 最初に配置する背景マップの数
    [SerializeField]
    private float scrollSpeed; // スクロール速度
    private List<GameObject> activeBackgrounds = new List<GameObject>(); // 現在アクティブな背景マップ
    private float backgroundWidth;

    void Start()
    {
        backgroundWidth = backgroundPrefabs[0].GetComponent<SpriteRenderer>().bounds.size.x;

        // 最初に背景マップを配置
        for (int i = 0; i < initialBackgroundCount; i++)
        {
            Vector3 spawnPosition = new Vector3(i * backgroundWidth, 0, 0);
            GameObject background = Instantiate(RandomBackground(), spawnPosition, Quaternion.identity);
            background.transform.parent = transform; // 背景マップを親オブジェクトの子にする
            activeBackgrounds.Add(background);
        }
    }

    void Update()
    {
        // 背景マップをスクロール
        foreach (GameObject background in activeBackgrounds)
        {
            background.transform.Translate(Vector3.left * scrollSpeed * Time.deltaTime);
        }

        // 背景マップの再配置
        if (activeBackgrounds[0].transform.position.x < -backgroundWidth)
        {
            GameObject firstBackground = activeBackgrounds[0];
            activeBackgrounds.RemoveAt(0);
            Destroy(firstBackground);

            Vector3 spawnPosition = new Vector3(activeBackgrounds[activeBackgrounds.Count - 1].transform.position.x + backgroundWidth, 0, 0);
            GameObject newBackground = Instantiate(RandomBackground(), spawnPosition, Quaternion.identity);
            newBackground.transform.parent = transform; // 背景マップを親オブジェクトの子にする
            activeBackgrounds.Add(newBackground);
        }
    }

    // ランダムな背景マップを取得するメソッド
    private GameObject RandomBackground()
    {
        int randomIndex = Random.Range(0, backgroundPrefabs.Length);
        return backgroundPrefabs[randomIndex];
    }
}
