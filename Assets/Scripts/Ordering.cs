using System.Collections.Generic;
using UnityEngine;

public class Ordering : MonoBehaviour
{
    public List<GameObject> orderIcons;  // List of order icon prefabs
    public GameObject placementForOrderIcon; // Where the order icon should be placed

    private CustomerArriving customerArrivingScript; // Reference to the CustomerArriving script

    [System.Obsolete]
    void Start()
    {
        // Find the CustomerArriving script
        customerArrivingScript = FindObjectOfType<CustomerArriving>();
    }

    void Update()
    {
        // Check if a customer is at the ordering point and ready to order
        if (customerArrivingScript != null && customerArrivingScript.isCustomerAtOrderingPoint)
        {
            // Choose a random item from the orderIcons list
            if (orderIcons.Count > 0)
            {
                int randomIndex = Random.Range(0, orderIcons.Count);
                GameObject selectedIcon = orderIcons[randomIndex];

                // Instantiate the selected icon at the placement location
                if (selectedIcon != null && placementForOrderIcon != null)
                {
                    Instantiate(selectedIcon, placementForOrderIcon.transform.position, Quaternion.identity);
                }

                // After placing the icon, you might want to stop checking until the next customer arrives
                // (For example, reset isCustomerAtOrderingPoint or wait for the next condition).
                customerArrivingScript.isCustomerAtOrderingPoint = false; // Customer has ordered
            }
        }
    }
}
