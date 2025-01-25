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

    private IEnumerator SpawnItemAfterAnimation(GameObject itemPrefab)
    {
        // Wait for the animation to finish (you can use a fixed time or animation length)
        yield return new WaitForSeconds(3f);

        // Instantiate the item at the order placement point
        if (itemPrefab != null && orderPlacementPoint != null)
        {
            GameObject instantiatedItem = Instantiate(itemPrefab, orderPlacementPoint.position, Quaternion.identity);

            // Notify CheckingOrder that an order has been placed
            if (checkingOrderScript != null)
            {
                checkingOrderScript.PlaceOrder(instantiatedItem);  // Pass the instantiated item
            }
        }
    }
}
