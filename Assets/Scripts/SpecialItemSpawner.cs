using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialItemSpawner : MonoBehaviour
{

    [SerializeField] private GameObject specialItemPrefab;
    [SerializeField] private float spawnDelay = 2f;

    private void Start()
    {
        Invoke(nameof(SpawnItem), spawnDelay);
    }

    private void SpawnItem()
    {
        Instantiate(specialItemPrefab, transform.position, Quaternion.identity, transform);
    }
}
