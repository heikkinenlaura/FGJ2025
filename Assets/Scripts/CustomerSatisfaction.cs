using UnityEngine;

public class CustomerSatisfaction : MonoBehaviour
{
    public Animator customerAnimator; // Animator component for happy/sad animations
    public GameObject door; // Destination point for the customer
    public float moveSpeed = 2f; // Speed at which the customer moves to the door

    private bool isLeaving = false; // Flag to indicate if the customer is leaving

    public void HandleCustomerSatisfaction(int scoreChange)
    {
        if (scoreChange > 0)
        {
            PlayHappyAnimation(); // Customer is happy
        }
        else if (scoreChange < 0)
        {
            PlaySadAnimation(); // Customer is sad
        }

        StartCoroutine(LeaveToDoor());
    }

    private void PlayHappyAnimation()
    {
        if (customerAnimator != null)
        {
            customerAnimator.SetTrigger("Happy"); // Trigger the happy animation
        }
    }

    private void PlaySadAnimation()
    {
        if (customerAnimator != null)
        {
            customerAnimator.SetTrigger("Sad"); // Trigger the sad animation
        }
    }

    private System.Collections.IEnumerator LeaveToDoor()
    {
        isLeaving = true;

        // Move the customer to the door point
        while (Vector3.Distance(transform.position, door.transform.position) > 0.1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, door.transform.position, moveSpeed * Time.deltaTime);
            yield return null; // Wait for the next frame
        }

        // Remove the customer from the hierarchy after reaching the door
        Destroy(gameObject);
    }
}
