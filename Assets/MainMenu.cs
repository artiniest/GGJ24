using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenuCanvas;
    public GameObject creditsCanvas;

    public void ShowCredits()
    {
        mainMenuCanvas.SetActive(false);
        creditsCanvas.SetActive(true);
    }

    public void BackToMainMenu()
    {
        creditsCanvas.SetActive(false);
        mainMenuCanvas.SetActive(true);
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Game"); // Replace with your game scene name
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    // Add other functions for other buttons here
}
