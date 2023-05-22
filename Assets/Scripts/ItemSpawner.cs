using System.Collections;
using System.Collections.Generic;
using System.Linq;
using SevenGame.Utility;
using UnityEngine;

public class ItemSpawner : Singleton<ItemSpawner>
{

    [SerializeField] private Camera camera;
    [SerializeField] private float throwRange = 1f;

    private List<GameObject> items;
    private List<GameObject> bonusItems;
    private List<GameObject> penaltyItems;
    private float delay = 1f;
    private float bonusOdds = 0f;
    private float penaltyOdds = 0f;



    public void StartSpawning(float delay, float throwRange, IEnumerable<GameObject> items, IEnumerable<GameObject> bonusItems, IEnumerable<GameObject> penaltyItems, float bonusOdds = 0f, float penaltyOdds = 0f)
    {
        CancelInvoke();
        this.items = items.ToList();
        this.bonusItems = bonusItems.ToList();
        this.penaltyItems = penaltyItems.ToList();

        this.throwRange = throwRange;
        this.bonusOdds = bonusOdds;
        this.penaltyOdds = penaltyOdds;
        this.delay = delay;
        Invoke(nameof(SpawnItem), 1.5f);
    }

    public void StopSpawning()
    {
        CancelInvoke();
    }

    private void SpawnItem()
    {

        // if ( items.Count == 0 ) 
        // {
        //     StopSpawning();
        //     return;
        // }

        if (Random.value < bonusOdds)
        {
            GameObject bonusItem = bonusItems[Random.Range(0, bonusItems.Count)];
            CreateSpecialItem(bonusItem);
        }
        else if (Random.value < penaltyOdds)
        {
            GameObject penaltyItem = penaltyItems[Random.Range(0, penaltyItems.Count)];
            CreateSpecialItem(penaltyItem);
        }
        else
        {

            GameObject item = items[Random.Range(0, items.Count)];

            Vector3 spawnPoint = camera.ViewportToWorldPoint(new Vector3(Random.value, -0.25f, 0));
            spawnPoint.z = -1f;

            Vector3 throwPosition = camera.ViewportToWorldPoint(new Vector3(0.5f, 1f, 0) + Random.insideUnitSphere * throwRange);
            throwPosition.z = -1f;

            GameObject spawnedItem = Instantiate(item, spawnPoint, Quaternion.identity);

            Debug.DrawLine(spawnPoint, throwPosition, Color.red, 5f);

            if ( spawnedItem.TryGetComponent<Rigidbody>(out Rigidbody rb) )
                rb.AddForce((throwPosition - spawnPoint), ForceMode.Impulse);

            items.Remove(item);

        }



        if ( items.Count == 0 )
        {
            StopSpawning();
            Invoke(nameof(EndGame), 3.5f);
        } 
        else 
        {
            Invoke(nameof(SpawnItem), Random.Range(delay, delay * 2f));
        }


        void CreateSpecialItem(GameObject specialItem)
        {
            Vector3 viewportPosition = new Vector3(Random.value, Random.value, 0);
            viewportPosition = (viewportPosition - new Vector3(0.5f, 0.5f, 0)) * 0.8f + new Vector3(0.5f, 0.5f, 0);
            Vector3 worldPosition = camera.ViewportToWorldPoint(viewportPosition);
            worldPosition.z = -1f;
            GameObject itemInstance = Instantiate(specialItem, worldPosition, Quaternion.identity);
            Destroy(itemInstance, 5f);
        }
    }

    private void EndGame()
    {
        GameManager.current.EndGame();
    }

    private void OnEnable()
    {
        SetCurrent();
        // StartSpawning(1f, 0.1f, items);
    }
}
