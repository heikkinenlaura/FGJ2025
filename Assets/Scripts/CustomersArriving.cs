using System.Collections;
using UnityEngine;

public class CustomerArriving : MonoBehaviour
{
    public GameObject customerPrefab;  // The customer prefab
    public Transform startingPoint;    // The starting point where the customer spawns
    public Transform orderingPoint;    // The ordering point where the customer goes
    public float customerSpeed = 2f;   // Speed at which the customer moves toward the ordering point
    public float waitBehindDistance = 2f;  // Distance behind the ordering point to wait if occupied
    public Transform customersParent;
    public bool isCustomerAtOrderingPoint = false; // To check if the ordering point is currently occupied

    void Start()
    {
        // Spawn the customer when the game starts
        StartCoroutine(SpawnAndMoveCustomer());
    }

    IEnumerator SpawnAndMoveCustomer()
    {
        // Spawn the customer at the starting point
        GameObject newCustomer = Instantiate(customerPrefab, startingPoint.position, Quaternion.Euler(0, -180, 0));
        newCustomer.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
        newCustomer.transform.SetParent(customersParent);
        newCustomer.tag = "Customer"; // Ensure the customer has the "Customer" tag for any future use
        

        // Start the customer's movement towards the ordering point
        yield return StartCoroutine(MoveCustomerToOrderingPoint(newCustomer));
    }

    IEnumerator MoveCustomerToOrderingPoint(GameObject customer)
    {
        // Move the customer from the starting point to the ordering point
        float journeyTime = Vector3.Distance(startingPoint.position, orderingPoint.position) / customerSpeed;
        float timeElapsed = 0f;

        // Move towards the ordering point
        while (timeElapsed < journeyTime)
        {
            customer.transform.position = Vector3.Lerp(startingPoint.position, orderingPoint.position, timeElapsed / journeyTime);
            timeElapsed += Time.deltaTime;
            yield return null;
        }

        // Check if the ordering point is occupied
        if (isCustomerAtOrderingPoint)
        {
            // If occupied, move the customer behind the ordering point and wait for 2 seconds
            Vector3 behindOrderingPoint = orderingPoint.position - orderingPoint.forward * waitBehindDistance;
            customer.transform.position = behindOrderingPoint;

            // Wait for 2 seconds before trying again
            yield return new WaitForSeconds(2f);

            // Now, recheck the condition and move towards the ordering point again
            yield return StartCoroutine(MoveCustomerToOrderingPoint(customer));
        }
        else
        {
            // The ordering point is free, so the customer can proceed to the ordering point
            isCustomerAtOrderingPoint = true;
            customer.transform.position = orderingPoint.position; // Ensure the customer ends up at the ordering point

            // Simulate the time for ordering (adjust this as needed)
            yield return new WaitForSeconds(3f); // Time customer spends ordering

            // The ordering point is now free
            isCustomerAtOrderingPoint = false;
        }
    }
}
