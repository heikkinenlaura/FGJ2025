using System.Collections.Generic;
using UnityEngine;

public class Ordering : MonoBehaviour
{
    public List<GameObject> orderIcons; // List of order icon prefabs
    public GameObject placementForOrderIcon; // Where the order icon should be placed
    private GameObject lastInstantiatedOrderIcon; // To track the last instantiated order icon
    private GameObject selectedIcon; // Track the selected order icon

    private CustomerArriving customerArrivingScript; // Reference to the CustomerArriving script
    public CheckingOrder checkingOrderScript; // Reference to the CheckingOrder script

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
                selectedIcon = orderIcons[randomIndex]; // Track the selected icon

                // Instantiate the selected icon at the placement location
                if (selectedIcon != null && placementForOrderIcon != null)
                {
                    lastInstantiatedOrderIcon = Instantiate(selectedIcon, placementForOrderIcon.transform.position, Quaternion.identity);
                }

                // After placing the icon, mark that the customer has ordered
                customerArrivingScript.isCustomerAtOrderingPoint = false; // Customer has ordered
            }
        }
    }

    // Return the selected icon's GameObject
    public GameObject GetSelectedIcon()
    {
        return selectedIcon;
    }

    // Method to return the last instantiated order icon (for checking purposes)
    public GameObject GetLastInstantiatedOrderIcon()
    {
        return lastInstantiatedOrderIcon;
    }
}
