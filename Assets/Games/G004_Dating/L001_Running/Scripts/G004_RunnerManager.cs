using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class G004_RunnerManager : MonoBehaviour
{
    public float[] weights = { 10f, 5f, 2f };

    [SerializeField] List<GameObject> collectableHeartItemList = new List<GameObject>();
    [SerializeField] List<GameObject> collectableChocolateItemList = new List<GameObject>();
    [SerializeField] List<GameObject> collectableflowerItemList = new List<GameObject>();

    [SerializeField] float zPosition = 0;
    public static G004_RunnerManager instance;
    public GameObject collectablePrefab;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(instance);
        }
    }
    void Start()
    {
        //SpawnPoint();
        InvokeRepeating("CollectableSpawner", 1, 0.1f);
    }
    void CollectableSpawner()
    {
        Vector3 spawnPoint = new Vector3(0, 0.5f, zPosition);
        zPosition += 3f;
        SpawnPoint(spawnPoint);
    }

    void SpawnPoint(Vector3 spawnPoint)
    {
        Vector3 spawnPosition = new Vector3(GetRandomSpawnPositionX(), spawnPoint.y, spawnPoint.z);
        GameObject spawnedCollectable = Instantiate(collectablePrefab, spawnPosition, Quaternion.identity);
        G004_Collectable.CollectableType collectableType = spawnedCollectable.GetComponent<G004_Collectable>().collectableType;
        //spawnedCollectable.GetComponent<G004_Collectable>().

        if (collectableType == G004_Collectable.CollectableType.FLOWER)
        {
            collectableflowerItemList.Add(spawnedCollectable);
        }
        else if (collectableType == G004_Collectable.CollectableType.CHOCOLATE)
        {
            collectableChocolateItemList.Add(spawnedCollectable);
        }
        else if (collectableType == G004_Collectable.CollectableType.HEART)
        {
            collectableHeartItemList.Add(spawnedCollectable);
        }
    }
    float GetRandomSpawnPositionX()
    {
        int randomLane = Random.Range(-1, 2);
        if (randomLane == -1)
        {
            return -1.5f;
        }
        else if (randomLane == 0)
        {
            return 0f;
        }
        else if (randomLane == 1)
        {
            return 1.5f;
        }
        return 0;
    }

}
