using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Spawnable
{
    public GameObject prefab;  // �o��������v���n�u
    public float spawnRadius;  // �X�|�[���͈͂̔��a
    public float spawnChance;  // �X�|�[������m��
}
public class RandomSpown : MonoBehaviour
{
    public List<Spawnable> enemies;  // �G�l�~�[�̐ݒ胊�X�g
    public List<Spawnable> items;    // �A�C�e���̐ݒ胊�X�g
    public Transform parentTransform; // �w�i�̐e�I�u�W�F�N�g

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
