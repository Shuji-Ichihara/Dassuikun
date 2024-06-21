using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpown : MonoBehaviour
{
    // �G�l�~�[�̃X�|�[��
    [SerializeField]
    private List<GameObject> spownEnemys;
    // �A�C�e���̃X�|�[��
    [SerializeField]
    private List<GameObject> spownItems;
    // �T�{�e���̃X�|�[��
    [SerializeField]
    private GameObject spownCactus;
    // �G�l�~�[�X�|�[���̔��a
    [SerializeField]
    private float enemySpawnRadius = 10f;
    // �A�C�e���X�|�[���̔��a
    [SerializeField]
    private float itemSpawnRadius = 10f;
    // �G�l�~�[���o������m��(0�`1)
    [SerializeField]
    private float enemySpawnChance = 0.5f;
    // �A�C�e�����o������m��(0�`1)
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
        // �����_���Ȓl��spawmChance�ȉ��ł���΃G�l�~�[���o��������
        if (Random.value <= spawnChance)
        {
            // �����_���Ȓl��spawmChance�ȉ��ł���΃G�l�~�[���o��������
            Vector3 spawnPosition = GetRandomPositionWithinRadious(radius);

            // �o��������G�l�~�[�̃^�C�v������
            GameObject itemToSpawn = ChooseRandomPrefabs(prefabs);

            // �G�l�~�[���w�肵���ʒu�ɏo��������
            Instantiate(itemToSpawn, spawnPosition, Quaternion.identity);
        }
    }

    // �w�肵�����a���̃����_���Ȉʒu���擾���A���a�������Ĕ͈͂𒲐�
    Vector3 GetRandomPositionWithinRadious(float radius)
    {
        // �P�ʉ~���̃����_���Ȉʒu���擾���A���a�������Ē���
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
