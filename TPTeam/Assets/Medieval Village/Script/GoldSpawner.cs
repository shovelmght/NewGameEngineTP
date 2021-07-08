using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldSpawner : MonoBehaviour
{
    public Transform GoldPile;

    void Start()
    {
        foreach (Transform child in transform)
        {
            Instantiate(GoldPile, child.position, Quaternion.identity);
        }
    }
}
