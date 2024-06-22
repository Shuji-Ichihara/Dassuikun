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
    [SerializeField]
    private Transform parentTransform; // �w�i�̐e�I�u�W�F�N�g
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
                spawanedObject.transform.parent = parentTransform; //�e�I�u�W�F�N�g��ݒ�
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
