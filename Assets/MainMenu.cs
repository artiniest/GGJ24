using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenuCanvas;
    public GameObject creditsCanvas;
    public AudioClip selectSound; // Assign this in the Inspector
    private AudioSource audioSource;


    public float delayInSeconds = 1f;
    

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void ShowCredits()
    {
        audioSource.PlayOneShot(selectSound);
        mainMenuCanvas.SetActive(false);
        creditsCanvas.SetActive(true);
    }

    public void BackToMainMenu()
    {
        audioSource.PlayOneShot(selectSound);
        creditsCanvas.SetActive(false);
        mainMenuCanvas.SetActive(true);
    }

    public void StartGame()
    {
        audioSource.PlayOneShot(selectSound);

        Invoke(nameof(LoadGameScene), delayInSeconds);
        // SceneManager.LoadScene("Game"); // Replace with your game scene name
    }

    private void LoadGameScene()
    {
        // Load your game scene
        SceneManager.LoadScene("Game"); // Replace with your game scene name
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    // Add other functions for other buttons here
}
