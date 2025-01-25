using System.Collections;
using UnityEngine;

public class CustomerLeaving : MonoBehaviour
{
    private GameObject currentCustomer; // Store the customer object
    public Transform startingPoint;     // Reference to the starting point where the customer will leave
    public float moveSpeed = 2f;        // Speed at which the customer moves
    public GameObject customersParent;

    public void StartLeavingCustomer(GameObject customer)
    {
        currentCustomer = customersParent.transform.GetChild(0).gameObject;

        if (currentCustomer != null)
        {
            // Start the customer's movement back to the starting point
            StartCoroutine(MoveCustomerBackToStartingPoint(currentCustomer));
        }
    }

    private IEnumerator MoveCustomerBackToStartingPoint(GameObject customer)
    {
        // Get the position of the starting point
        Vector3 startingPosition = startingPoint.position;

        // Move the customer back towards the starting point
        while (Vector3.Distance(customer.transform.position, startingPosition) > 0.1f)
        {
            customer.transform.position = Vector3.MoveTowards(customer.transform.position, startingPosition, moveSpeed * Time.deltaTime);
            yield return null; // Wait for the next frame
        }

        // Once the customer reaches the starting point, destroy the customer object
        Destroy(currentCustomer);
        Debug.Log("Customer has left and was destroyed.");
    }
}
