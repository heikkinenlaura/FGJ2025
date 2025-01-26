using UnityEngine;

public class EndGame : MonoBehaviour
{
    public GameObject endPanel;

    public void EndGamePanel()
    {
        endPanel.SetActive(true);
        Time.timeScale = 0;
    }
}
