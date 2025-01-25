using UnityEngine;

public class CustomerSatisfaction : MonoBehaviour
{
    public GameObject customerPrefab; // Prefab of the customer
    public Animator customerAnimator; // Animator for happy/sad animations

    private GameObject currentCustomer; // Current instantiated customer object

    // Function to be called when a score change happens
    public void HandleCustomerSatisfaction(int scoreChange)
    {
        // Check if customerPrefab is assigned
        if (customerPrefab == null)
        {
            Debug.LogError("Customer Prefab is not assigned!");
            return;
        }

        currentCustomer = customerPrefab;

        // Make sure it's active
        if (!currentCustomer.activeSelf)
        {
            currentCustomer.SetActive(true);
        }

        // Get the Animator component of the instantiated customer
        customerAnimator = currentCustomer.GetComponent<Animator>();

        // Trigger animations based on score change
        if (scoreChange > 0)
        {
            PlayHappyAnimation();
        }
        else if (scoreChange < 0)
        {
            PlaySadAnimation();
        }
    }

    // Play happy animation
    private void PlayHappyAnimation()
    {
        if (customerAnimator != null)
        {
            customerAnimator.SetTrigger("Happy");
        }
        else
        {
            Debug.LogError("Customer Animator is missing.");
        }
    }

    // Play sad animation
    private void PlaySadAnimation()
    {
        if (customerAnimator != null)
        {
            customerAnimator.SetTrigger("Sad");
        }
        else
        {
            Debug.LogError("Customer Animator is missing.");
        }
    }
}
