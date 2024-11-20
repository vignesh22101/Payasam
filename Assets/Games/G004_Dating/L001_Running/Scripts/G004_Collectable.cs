using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Unity.VisualScripting;
public class G004_Collectable : MonoBehaviour
{
    public enum CollectableType
    {
        FLOWER,
        CHOCOLATE,
        HEART
    }

    //[SerializeField]
    public CollectableType collectableType;
    [SerializeField]
    float value;

    public float[] weights = { 10f, 5f, 2f };


    [SerializeField] GameObject flowerPrefab;
    [SerializeField] GameObject chocolatePrefab;
    [SerializeField] GameObject heartPrefab;

    [SerializeField] float zPosition = 0;

    public float[] flowerWeights = { 6f, 4f};
    public float[] chocolateWeights = { 6f, 4f };
    public float[] heartWeights = { 6f, 4f };
    // Add these arrays to define value weights for positive and negative values
    [SerializeField] float[] randomValues = { 50f, 100f}; 
    //[SerializeField] float[] negativeValueWeights = { -20f, -50f, -10f }; // FLOWER, CHOCOLATE, HEART

    void Start()
    {
        weights = G004_RunnerManager.instance.weights;
        collectableType = ChooseRandomCollectable();

        // Assign a weighted value based on the selected collectable type
        value = AssignWeightedValue(collectableType);

        SpawnCollectableItem();
    }
    float GetTotalWeight(float[] weights)
    {
        float totalWeight = 0f;
        foreach (var weight in weights)
        {
            totalWeight += weight;
        }
        return totalWeight;
    }
    float WeightBasedRandomValue(float totalWeight, float[] Weights)
    {
        float randomValue = Random.Range(0, totalWeight);

        foreach (var kvp in Weights)
        {
            if (randomValue < kvp)
            {
                int indexWeight = Weights.ToList().IndexOf(kvp);
                if (indexWeight == 0)
                {
                    return randomValues[Random.Range(0, 2)];
                }
                else
                {
                    return -randomValues[Random.Range(0, 2)];
                }
            }
            randomValue -= kvp;
        }
        return randomValues[Random.Range(0, 2)];
    }

    // Assign a value based on positive/negative weights
    float AssignWeightedValue(CollectableType type)
    {
        float totalWeight;
        // Assign value based on the collectable type
        switch (type)
        {
            case CollectableType.FLOWER:
                totalWeight = GetTotalWeight(flowerWeights);
                return WeightBasedRandomValue(totalWeight, flowerWeights);
            case CollectableType.CHOCOLATE:
                totalWeight = GetTotalWeight(chocolateWeights);
                return WeightBasedRandomValue(totalWeight, chocolateWeights);
            case CollectableType.HEART:
                totalWeight = GetTotalWeight(heartWeights);
                return WeightBasedRandomValue(totalWeight, heartWeights);
            default:
                return randomValues[Random.Range(0, 2)]; 
        }
    }
    
    void SpawnCollectableItem()
    {
        GameObject spawnItem;
        if (collectableType == CollectableType.FLOWER) 
        {
            SpawnItem(flowerPrefab);
        }
        else if (collectableType == CollectableType.CHOCOLATE)
        {
            SpawnItem(chocolatePrefab);
        }
        else if (collectableType == CollectableType.HEART)
        {
            SpawnItem(heartPrefab);
        }
    }
    void SpawnItem(GameObject spawnItem)
    {
        spawnItem = Instantiate(spawnItem,transform);
        spawnItem.transform.localPosition = Vector3.zero;
    }
    CollectableType ChooseRandomCollectable()
    {
        // Calculate total weight
        float totalWeight = GetTotalWeight(weights);

        // Generate a random value
        float randomValue = Random.Range(0, totalWeight);

        // Select based on weight
        foreach (var kvp in weights)
        {
            if (randomValue < kvp)
            {
                int indexWeight = weights.ToList().IndexOf(kvp);
                CollectableType collectable = (CollectableType)indexWeight;
                return collectable;
            }
            randomValue -= kvp;
        }

        // Fallback (should not happen if weights are valid)
        return CollectableType.HEART;
    }
}
