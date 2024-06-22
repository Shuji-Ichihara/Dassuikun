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
    public Transform parentTransform; // 背景の親オブジェクト

    void Start()
    {
        TrySpawnEntities(enemies);
        TrySpawnEntities(items);
    }

    void TrySpawnEntities(List<Spawnable> spawnables)
    {
        foreach (var spawnable in spawnables)
        {
            if (Random.value <= spawnable.spawnChance)
            {
                Vector3 spawnPosition = GetRandomPositionWithinRadius(spawnable.spawnRadius);
                Instantiate(spawnable.prefab, spawnPosition, Quaternion.identity);
            }
        }
    }

    Vector3 GetRandomPositionWithinRadius(float radius)
    {
        Vector2 randomCircle = Random.insideUnitCircle * radius;
        return new Vector3(randomCircle.x, 0, randomCircle.y);
    }
}
