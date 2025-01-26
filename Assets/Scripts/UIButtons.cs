using UnityEngine;

public class UIButtons : MonoBehaviour
{
    public Audio audioScript;
    private void Update()
    {
        Time.timeScale = 0;
    }

    public void StartCafeGame()
    {
        Time.timeScale = 1;
        audioScript.PlayBackgroundMusic();
    }
}
