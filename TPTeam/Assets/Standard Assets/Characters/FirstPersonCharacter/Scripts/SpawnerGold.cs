using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerGold : MonoBehaviour
{
    public Transform GoldPile;
    [SerializeField] int MaxGoldPileSpawn = 5;

    Transform[] ChildTransform;
    List<int> RandomIntMemory = new List<int>();

    void Start()
    {
        ChildTransform = GetComponentsInChildren<Transform>();

        for (int i = 0; i < MaxGoldPileSpawn; i++)
        {
            Instantiate(GoldPile, ChildTransform[RandomWithoutDuplicate()].position, Quaternion.identity);
        }
    }

    int RandomWithoutDuplicate()
    {
        int RandomToReturn = Random.Range(0, ChildTransform.Length);

        if (RandomIntMemory.Contains(RandomToReturn))
        {
            RandomWithoutDuplicate();
        }

        RandomIntMemory.Add(RandomToReturn);
        return RandomToReturn;
    }
}
