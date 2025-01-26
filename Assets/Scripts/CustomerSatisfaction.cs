//using UnityEngine;

//public class CustomerSatisfaction : MonoBehaviour
//{
//    public GameObject customerPrefab; // Prefab of the customer
//    public Animator customerAnimator; // Animator for happy/sad animations

//    private GameObject currentCustomer; // Current instantiated customer object

//    private CheckingOrder scoreCounterScript;

//    void Start()
//    {
//        GameObject gameManager = GameObject.Find("GameManager");

//        if (gameManager != null)
//        {
//            scoreCounterScript = gameManager.GetComponent<CheckingOrder>();
//        }
//    }

//    // Function to be called when a score change happens
//    public void HandleCustomerSatisfaction(int scoreChange)
//    {
//        // Check if customerPrefab is assigned
//        if (customerPrefab == null)
//        {
//            Debug.LogError("Customer Prefab is not assigned!");
//            return;
//        }

//        currentCustomer = customerPrefab;

//        // Make sure it's active
//        if (!currentCustomer.activeSelf)
//        {
//            currentCustomer.SetActive(true);
//        }

//        GameObject character = GameObject.FindGameObjectWithTag("Customer");
//        Animator customerAnimator = character.GetComponent<Animator>();

//        // Trigger animations based on score change
//        if (scoreChange >= 1)
//		{
//			PlayHappyAnimation();

//		}
//        else if (scoreChange <= 0)
//        {
//            PlaySadAnimation();
//        }
//    }

//    // Play happy animation
//    private void PlayHappyAnimation()
//    {

//        customerAnimator.SetTrigger("Happy");
		
//        if (customerAnimator != null)
//        {

//            customerAnimator.SetTrigger("Happy");

//			Debug.Log("customer animator should be used now");
//		}
//        else
//        {
//            Debug.LogError("Customer Animator is missing.");
//        }
//    }

//    // Play sad animation
//    private void PlaySadAnimation()
//    {


//        customerAnimator.SetTrigger("Angry");

//		if (customerAnimator != null)
//        {
//            customerAnimator.SetTrigger("Angry");
//        }
//        else
//        {
//            Debug.LogError("Customer Animator is missing.");
//        }
//    }
//}
