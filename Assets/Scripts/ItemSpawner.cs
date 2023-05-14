using System.Collections;
using System.Collections.Generic;
using SevenGame.Utility;
using UnityEngine;

public class ItemSpawner : Singleton<ItemSpawner>
{

    [SerializeField] private Camera camera;
    [SerializeField] private SerializableStack<GameObject> items;
    [SerializeField] private float range = 1f;



    public void StartSpawning(float delay, float throwRange, IEnumerable<GameObject> itemsToSpawn)
    {
        CancelInvoke();
        // items = new SerializableStack<GameObject>(itemsToSpawn);
        range = throwRange;
        InvokeRepeating(nameof(SpawnItem), delay, delay);
    }

    private void SpawnItem()
    {

        if (items.Count == 0) 
        {
            CancelInvoke();
            return;
        }

        Vector3 spawnPoint = camera.ViewportToWorldPoint(new Vector3(Random.value, -0.25f, 0));
        spawnPoint.z = -1f;

        Vector3 throwPosition = camera.ViewportToWorldPoint(new Vector3(0.5f, 1f, 0) + Random.insideUnitSphere * range);
        throwPosition.z = -1f;

        Debug.DrawLine(spawnPoint, throwPosition, Color.red, 1f);

        GameObject spawnedItem = Instantiate(items.Pop(), spawnPoint, Quaternion.identity);
        Destroy(spawnedItem, 10f);

        const float strengh = 1.1f;

        Rigidbody rb = spawnedItem.GetComponent<Rigidbody>();
        rb.AddForce((throwPosition - spawnPoint) * strengh, ForceMode.Impulse);
        rb.AddTorque(Random.insideUnitSphere * strengh, ForceMode.Impulse);
    }

    private void OnEnable()
    {
        SetCurrent();
        StartSpawning(1f, 0.1f, items);
    }
}
