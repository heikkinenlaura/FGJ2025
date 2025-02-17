using UnityEngine;
using TMPro;

public class CheckingOrder : MonoBehaviour
{
    public Ordering orderingScript;  // Reference to the Ordering script
    public int score = 0;           // Track the score
    private bool isOrderMade = false; // Track if an order is made
    private GameObject lastInstantiatedItem; // Track the last instantiated item
    //public CustomerSatisfaction customerSatisfactionScript; // Reference to CustomerSatisfaction script

    public TextMeshProUGUI scoreText;
    public Animator customerAnimator;
    // Method to check if the order matches

    public Audio checkingAudioScript;

    private void Update()
    {
        if(score > 7)
        {
            EndGame endGameScript = FindObjectOfType<EndGame>();
            endGameScript.EndGamePanel();
        }
    }
    public void CheckOrder(GameObject instantiatedItem)
    {

        // Ensure an order is made and the instantiated item is valid
        if (!isOrderMade || instantiatedItem == null)
        {
            return;
        }

        // Retrieve the selected order icon from the Ordering script
        GameObject selectedIcon = orderingScript.GetSelectedIcon();

        // Check if the selected icon exists
        if (selectedIcon == null)
        {
            return;
        }
        

        // Normalize names (remove "(Clone)", trim whitespace, and convert to lowercase for consistent comparison)
        string selectedIconName = CleanName(selectedIcon.name);
        string instantiatedItemName = CleanName(instantiatedItem.name);

        if (selectedIconName == instantiatedItemName)
        {
            score += 1; // Add 1 point for a correct match
            PlayHappyAnimation();
            checkingAudioScript.PlayHappySound();
            scoreText.text = $"$: {score}"; // Update the UI text
        }
        else
        {
            score -= 1; // Subtract 1 point for an incorrect match
            PlaySadAnimation();
            checkingAudioScript.PlayAngrySound();
            scoreText.text = $"$: {score}"; // Update the UI text
        }

        
         //  customerSatisfactionScript.HandleCustomerSatisfaction(score); // Pass the score to handle customer satisfaction
        

        // Reset the flag after checking the order
        isOrderMade = false;
    }
    private void PlayHappyAnimation()
    {
        GameObject character = GameObject.FindGameObjectWithTag("Customer");
        Animator customerAnimator = character.GetComponent<Animator>();
        customerAnimator.SetTrigger("Happy");
    }

    // Play sad animation
    private void PlaySadAnimation()
    {
        GameObject character = GameObject.FindGameObjectWithTag("Customer");
        Animator customerAnimator = character.GetComponent<Animator>();
        customerAnimator.SetTrigger("Angry");
    }

    // Method to be called when the order is placed
    public void PlaceOrder(GameObject instantiatedItem)
    {
        // Set the flag to true indicating an order has been made
        isOrderMade = true;
        lastInstantiatedItem = instantiatedItem;

        // Call the CheckOrder function after placing the order
        CheckOrder(lastInstantiatedItem);
    }

    // New ServeOrder method to handle the process when an item is served
    public void ServeOrder(GameObject item)
    {
        // Check if item is valid
        if (item != null)
        {
            // Destroy the item after it's served
            Destroy(item);

            
            //   customerSatisfactionScript.HandleCustomerSatisfaction(score); // Update customer satisfaction
            
        }
        else
        {
            Debug.LogWarning("Item is invalid and cannot be served.");
        }
    }

    // Utility method to clean names (removes "(Clone)", trims, and converts to lowercase)
    private string CleanName(string name)
    {
        return name.Replace("(Clone)", "").Trim().ToLower();
    }

    // Method to get the current order item (needed for Serve method)
    public GameObject GetCurrentOrderItem()
    {
        return lastInstantiatedItem;  // Return the most recent placed item
    }
}
