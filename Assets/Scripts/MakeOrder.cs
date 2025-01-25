using System.Collections;
using UnityEngine;

public class MakeOrder : MonoBehaviour
{
    public GameObject coffeePrefab;
    public GameObject teaPrefab;
    public GameObject wafflePrefab;

    public Transform orderPlacementPoint;

    public Ordering orderingScript;  // Reference to Ordering script
    public CheckingOrder checkingOrderScript; // Reference to CheckingOrder script

    // Add a reference to store the instantiated item
    private GameObject currentInstantiatedItem;

    public void CoffeeMachine()
    {
        StartCoroutine(SpawnItemAfterAnimation(coffeePrefab));
    }

    public void WaffleMachine()
    {
        StartCoroutine(SpawnItemAfterAnimation(wafflePrefab));
    }

    public void TeaMachine()
    {
        StartCoroutine(SpawnItemAfterAnimation(teaPrefab));
    }

    public void Serve()
    {
        // Check if an item has been instantiated
        if (currentInstantiatedItem != null)
        {
            // Notify CheckingOrder that the item is being placed in the order
            checkingOrderScript.PlaceOrder(currentInstantiatedItem);

            // Optional: Add any logic for completing the order (e.g., visual effects)
            Debug.Log("Item placed in the order.");

            // Destroy the item after placing it in the order
            Destroy(currentInstantiatedItem);

            // Clear the reference to the instantiated item
            currentInstantiatedItem = null;
        }
        else
        {
            Debug.LogWarning("No item to serve.");
        }
    }

    private IEnumerator SpawnItemAfterAnimation(GameObject itemPrefab)
    {
        // Wait for the animation to finish (you can use a fixed time or animation length)
        yield return new WaitForSeconds(3f);

        // Instantiate the item at the order placement point
        if (itemPrefab != null && orderPlacementPoint != null)
        {
            currentInstantiatedItem = Instantiate(itemPrefab, orderPlacementPoint.position, Quaternion.identity);

            // Optionally, you can add any logic you want here, like notifying the UI or doing something visual.
            Debug.Log("Item instantiated but not yet placed in order.");
        }
    }
}
