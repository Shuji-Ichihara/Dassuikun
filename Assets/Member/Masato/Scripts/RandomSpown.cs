using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpown : MonoBehaviour
{
    // エネミーのスポーン
    [SerializeField]
    private List<GameObject> spownEnemys;
    // アイテムのスポーン
    [SerializeField]
    private List<GameObject> spownItems;
    // サボテンのスポーン
    [SerializeField]
    private GameObject spownCactus;
    // エネミースポーンの半径
    [SerializeField]
    private float enemySpawnRadius = 10f;
    // アイテムスポーンの半径
    [SerializeField]
    private float itemSpawnRadius = 10f;
    // エネミーが出現する確率(0～1)
    [SerializeField]
    private float enemySpawnChance = 0.5f;
    // アイテムが出現する確率(0～1)
    [SerializeField]
    private float itemSpawnChance = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        TrySpown(spownEnemys, enemySpawnRadius, enemySpawnChance);
        TrySpown(spownItems, itemSpawnRadius, itemSpawnChance);
    }

    void TrySpown(List<GameObject> prefabs, float radius, float spawnChance)
    {
        // ランダムな値がspawmChance以下であればエネミーを出現させる
        if (Random.value <= spawnChance)
        {
            // ランダムな値がspawmChance以下であればエネミーを出現させる
            Vector3 spawnPosition = GetRandomPositionWithinRadious(radius);

            // 出現させるエネミーのタイプを決定
            GameObject itemToSpawn = ChooseRandomPrefabs(prefabs);

            // エネミーを指定した位置に出現させる
            Instantiate(itemToSpawn, spawnPosition, Quaternion.identity);
        }
    }

    // 指定した半径内のランダムな位置を取得し、半径をかけて範囲を調整
    Vector3 GetRandomPositionWithinRadious(float radius)
    {
        // 単位円内のランダムな位置を取得し、半径をかけて調整
        Vector2 randomCircle = Random.insideUnitCircle * radius;

        return new Vector3(randomCircle.x, 0, randomCircle.y);
    }

    GameObject ChooseRandomPrefabs(List<GameObject> prefabs)
    {
        int index = Random.Range(0, prefabs.Count);

        return prefabs[index];
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
