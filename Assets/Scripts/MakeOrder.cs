using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class MakeOrder : MonoBehaviour
{
    // Reference to the Coffee machine animation (or Animator)
    //public Animator coffeeMachineAnimator;

    public GameObject coffeePrefab;
    public GameObject teaPrefab;
    public GameObject wafflePrefab;

    public Transform orderPlacementPoint;

    // This function will be triggered when the button is clicked
    public void CoffeeMachine()
    {
        // Play the animation for the coffee machine (you need an animation or animator setup)
        //if (coffeeMachineAnimator != null)
        //{
        //   coffeeMachineAnimator.SetTrigger("MakeCoffee"); // TBA from Vilma
        //}

        // Start the process of making coffee (spawn the coffee after a delay or animation duration)
        StartCoroutine(SpawnCoffeeAfterAnimation());
    }

    // Coroutine to wait for the animation to finish and then place the coffee
    private IEnumerator SpawnCoffeeAfterAnimation()
    {
        // Wait for the animation to finish (use animation's length or a fixed time)
        //float animationDuration = coffeeMachineAnimator.GetCurrentAnimatorStateInfo(0).length;
        yield return new WaitForSeconds(3f);

        // Instantiate the coffee at the coffee placement point
        if (coffeePrefab != null && orderPlacementPoint != null)
        {
            Instantiate(coffeePrefab, orderPlacementPoint.position, Quaternion.identity);
        }
    }
    public void WaffleMachine()
    {
        // Play the animation for the coffee machine (you need an animation or animator setup)
        //if (coffeeMachineAnimator != null)
        //{
        //   coffeeMachineAnimator.SetTrigger("MakeCoffee"); // TBA from Vilma
        //}

        // Start the process of making coffee (spawn the coffee after a delay or animation duration)
        StartCoroutine(SpawnWaffleAfterAnimation());
    }

    // Coroutine to wait for the animation to finish and then place the coffee
    private IEnumerator SpawnWaffleAfterAnimation()
    {
        // Wait for the animation to finish (use animation's length or a fixed time)
        //float animationDuration = coffeeMachineAnimator.GetCurrentAnimatorStateInfo(0).length;
        yield return new WaitForSeconds(3f);

        // Instantiate the coffee at the coffee placement point
        if (coffeePrefab != null && orderPlacementPoint != null)
        {
            Instantiate(wafflePrefab, orderPlacementPoint.position, Quaternion.identity);
        }
    }
    public void TeaMachine()
    {
        // Play the animation for the coffee machine (you need an animation or animator setup)
        //if (coffeeMachineAnimator != null)
        //{
        //   coffeeMachineAnimator.SetTrigger("MakeCoffee"); // TBA from Vilma
        //}

        // Start the process of making coffee (spawn the coffee after a delay or animation duration)
        StartCoroutine(SpawnTeaAfterAnimation());
    }

    // Coroutine to wait for the animation to finish and then place the coffee
    private IEnumerator SpawnTeaAfterAnimation()
    {
        // Wait for the animation to finish (use animation's length or a fixed time)
        //float animationDuration = coffeeMachineAnimator.GetCurrentAnimatorStateInfo(0).length;
        yield return new WaitForSeconds(3f);

        // Instantiate the coffee at the coffee placement point
        if (coffeePrefab != null && orderPlacementPoint != null)
        {
            Instantiate(teaPrefab, orderPlacementPoint.position, Quaternion.identity);
        }
    }
}
