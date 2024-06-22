using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapScroll : MonoBehaviour
{
    public GameObject[] backgroundPrefabs; // �w�i�}�b�v��Prefab�z��
    [SerializeField]
    private int initialBackgroundCount; // �ŏ��ɔz�u����w�i�}�b�v�̐�
    [SerializeField]
    private float scrollSpeed; // �X�N���[�����x
    private List<GameObject> activeBackgrounds = new List<GameObject>(); // ���݃A�N�e�B�u�Ȕw�i�}�b�v
    private float backgroundWidth;

    void Start()
    {
        backgroundWidth = backgroundPrefabs[0].GetComponent<SpriteRenderer>().bounds.size.x;

        // �ŏ��ɔw�i�}�b�v��z�u
        for (int i = 0; i < initialBackgroundCount; i++)
        {
            Vector3 spawnPosition = new Vector3(i * backgroundWidth, 0, 0);
            GameObject background = Instantiate(RandomBackground(), spawnPosition, Quaternion.identity);
            background.transform.parent = transform; // �w�i�}�b�v��e�I�u�W�F�N�g�̎q�ɂ���
            activeBackgrounds.Add(background);
        }
    }

    void Update()
    {
        // �w�i�}�b�v���X�N���[��
        foreach (GameObject background in activeBackgrounds)
        {
            background.transform.Translate(Vector3.left * scrollSpeed * Time.deltaTime);
        }

        // �w�i�}�b�v�̍Ĕz�u
        if (activeBackgrounds[0].transform.position.x < -backgroundWidth)
        {
            GameObject firstBackground = activeBackgrounds[0];
            activeBackgrounds.RemoveAt(0);
            Destroy(firstBackground);

            Vector3 spawnPosition = new Vector3(activeBackgrounds[activeBackgrounds.Count - 1].transform.position.x + backgroundWidth, 0, 0);
            GameObject newBackground = Instantiate(RandomBackground(), spawnPosition, Quaternion.identity);
            newBackground.transform.parent = transform; // �w�i�}�b�v��e�I�u�W�F�N�g�̎q�ɂ���
            activeBackgrounds.Add(newBackground);
        }
    }

    // �����_���Ȕw�i�}�b�v���擾���郁�\�b�h
    private GameObject RandomBackground()
    {
        int randomIndex = Random.Range(0, backgroundPrefabs.Length);
        return backgroundPrefabs[randomIndex];
    }
}
