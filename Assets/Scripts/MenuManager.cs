
using UnityEngine;
using UnityEngine.SceneManagement;

//Contains all the functions for the menu buttons
public class MenuManager : MonoBehaviour
{

    public GameObject mainMenuObject;
    public GameObject tutorialMenuObject;
    public GameObject settingsMenuObject;

    public string startingSceneName = "SampleScene";

    public void StartGame()
    {

        SceneManager.LoadScene(startingSceneName);

    }

    public void QuitGame()
    {

        if (Application.isPlaying)
        {

            Application.Quit();

        }

    }

    void DisableAllMenus()
    {

        mainMenuObject.SetActive(false);
        tutorialMenuObject.SetActive(false);
        settingsMenuObject.SetActive(false);

    }

    public void MainMenu()
    {

        DisableAllMenus();
        mainMenuObject.SetActive(true);

    }

    public void TutorialMenu()
    {

        DisableAllMenus();
        tutorialMenuObject.SetActive(true);

    }

    public void SettingsMenu()
    {

        DisableAllMenus();
        settingsMenuObject.SetActive(true);

    }



}
