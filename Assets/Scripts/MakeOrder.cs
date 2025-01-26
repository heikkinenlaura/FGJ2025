using System.Collections;
using UnityEngine;
using TMPro;

public class MakeOrder : MonoBehaviour
{
    public GameObject coffeePrefab;
    public GameObject teaPrefab;
	public GameObject wafflePrefab;
	public GameObject wrapPrefab;
	public GameObject skumpPrefab;

	public GameObject coffeeMaker;
	public GameObject teaMaker;
	public GameObject waffleMaker;
	public GameObject wrapMaker;
	public GameObject skumpMaker;

	public Transform orderPlacementPoint;

    public Ordering orderingScript;  // Reference to Ordering script
    public CheckingOrder checkingOrderScript; // Reference to CheckingOrder script

    // Add a reference to store the instantiated item
    private GameObject currentInstantiatedItem;

    public GameObject currentCustomer;
    public CustomerArriving customerArriving;

    private GameObject orderIcon;
    public GameObject customersParent;
    public Transform startingPoint;

    public GameObject serveButton;

    public void CoffeeMachine()
    {
        coffeeMaker.GetComponent<Animator>().SetTrigger("MakeCoffee");
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

	public void WrapMachine()
	{
		StartCoroutine(SpawnItemAfterAnimation(wrapPrefab));
	}

	public void SkumpMachine()
	{
		skumpMaker.GetComponent<Animator>().SetTrigger("PourSkumppa");
		StartCoroutine(SpawnItemAfterAnimation(skumpPrefab));
	}

	public void Serve()
    {
        // Check if an item has been instantiated
        if (currentInstantiatedItem != null)
        {
            // Notify CheckingOrder that the item is being placed in the order
            checkingOrderScript.PlaceOrder(currentInstantiatedItem);

            // Destroy the item after placing it in the order
            orderIcon = orderingScript.orderParent.transform.GetChild(0).gameObject;
            Destroy(currentInstantiatedItem);
            Destroy(orderIcon);
            Destroy(orderingScript.selectedIcon);

            StartLeavingCustomer(currentCustomer);

            // Clear the reference to the instantiated item
            currentInstantiatedItem = null;
        }
        else
        {
            Debug.LogWarning("No item to serve.");
        }
    }
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
            customer.transform.position = Vector3.MoveTowards(customer.transform.position, startingPosition, customerArriving.customerSpeed * Time.deltaTime);
            customer.transform.rotation = Quaternion.Euler(0, 0, 0);
            yield return null; // Wait for the next frame
        }
        serveButton.SetActive(false);
        // Once the customer reaches the starting point, destroy the customer object
        Destroy(currentCustomer);
        Debug.Log("Customer has left and was destroyed.");

        StartCoroutine(customerArriving.SpawnAndMoveCustomer());
    }
    private IEnumerator SpawnItemAfterAnimation(GameObject itemPrefab)
    {
        // Wait for the animation to finish (you can use a fixed time or animation length)
        yield return new WaitForSeconds(3f);

        serveButton.SetActive(true);
        // Instantiate the item at the order placement point
        if (itemPrefab != null && orderPlacementPoint != null)
        {
            currentInstantiatedItem = Instantiate(itemPrefab, orderPlacementPoint.position, Quaternion.identity);

            // Optionally, you can add any logic you want here, like notifying the UI or doing something visual.
            Debug.Log("Item instantiated but not yet placed in order.");
        }
    }
}
