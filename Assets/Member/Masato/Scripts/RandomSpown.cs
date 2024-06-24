using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Spawnable
{
    public GameObject prefab;  // 出現させるプレハブ
    public float spawnRadius;  // スポーン範囲の半径
    public float spawnChance;  // スポーンする確率
}
public class RandomSpown : MonoBehaviour
{

    public List<Spawnable> enemies;  // エネミーの設定リスト
    public List<Spawnable> items;    // アイテムの設定リスト
    [SerializeField]
    private Transform parentTransform; // 背景の親オブジェクト
    [SerializeField]
    private Transform spawnOrigin;  // スポーンの基準となるオブジェクト

    private Spawnable previousSpawned = null; // 前回スポーンされたオブジェクト

    void Start()
    {
        TrySpawnEntities();
    }

    void TrySpawnEntities()
    {
        // エネミーとアイテムのリストを統合
        List<Spawnable> allSpawnables = new List<Spawnable>();
        allSpawnables.AddRange(enemies);
        allSpawnables.AddRange (items);

        // 前回スポーンされたオブジェクトをリストから一時的に除外
        if (previousSpawned != null)
        {
            allSpawnables.Remove(previousSpawned);
        }

        // 確率に基づいてスポーンするオブジェクトを選択
        float totalChance = 0;
        foreach (var spawnable in allSpawnables)
        {
            totalChance += spawnable.spawnChance;
        }

        float randomPoint = Random.value * totalChance;
        float cumulativeChance = 0;
        foreach (var spawnable in allSpawnables)
        {
            cumulativeChance += spawnable.spawnChance;
            if (randomPoint < cumulativeChance)
            {
                Vector3 spawnPosition = GetRandomPositionAroundOrigin(spawnable.spawnRadius);
                GameObject spawnedObject = Instantiate(spawnable.prefab, spawnPosition, Quaternion.identity);
                spawnedObject.transform.parent = parentTransform; // 親オブジェクトを設定
                previousSpawned = spawnable; // 現在のスポーンされたオブジェクトを記録
                break;
            }
        }
    }

    Vector3 GetRandomPositionAroundOrigin(float radius)
    {
        Vector2 randomCircle = Random.insideUnitCircle * radius;
        return spawnOrigin.position + new Vector3(randomCircle.x, 0, randomCircle.y);
    }
}
