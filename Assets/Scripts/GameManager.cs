using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool flipped = false;

    public void PlayerDeath()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }

    public void NextLevel()
    {

        int nextScene = SceneManager.GetActiveScene().buildIndex + 1;

        if (nextScene > SceneManager.sceneCount)
        {

            SceneManager.LoadScene(nextScene);
        }
        else
        {

            SceneManager.LoadScene("LevelComplete");

        }

    }


}
