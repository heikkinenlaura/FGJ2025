using UnityEngine;

public class UIButtons : MonoBehaviour
{
    private void Update()
    {
        Time.timeScale = 0;
    }

    public void StartCafeGame()
    {
        Time.timeScale = 1;
    }
}
