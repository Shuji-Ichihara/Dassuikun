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
    private Transform spawnOrigin;

    void Start()
    {
        TrySpawnEntities();
    }

    void TrySpawnEntities()
    {
        List<Spawnable> allSpawnables = new List<Spawnable>();
        allSpawnables.AddRange(enemies);
        allSpawnables.AddRange (items);
        foreach (var spawnable in allSpawnables)
        {
            if (Random.value <= spawnable.spawnChance)
            {
                Vector3 spawnPosition = GetRandomPositionWithinRadius(spawnable.spawnRadius);
                GameObject spawanedObject = Instantiate (spawnable.prefab, spawnPosition, Quaternion.identity);
                spawanedObject.transform.parent = parentTransform; //親オブジェクトを設定
                break;
            }
        }
    }

    Vector3 GetRandomPositionWithinRadius(float radius)
    {
        Vector2 randomCircle = Random.insideUnitCircle * radius;
        return spawnOrigin.position + new Vector3(randomCircle.x, 0, randomCircle.y);
    }
}
