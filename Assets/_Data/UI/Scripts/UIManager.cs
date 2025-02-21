using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : DanSingleton<UIManager>
{
    public virtual void StartGame()
    {
        GameManager.Instance.StartGame();
    }

    public virtual void QuitGame()
    {
        Application.Quit();
    }

    public virtual void ContinueGame()
    {
        GameManager.Instance.ResumeGame();
    }

    public virtual void MainMenu()
    {
        foreach (GameObject obj in FindObjectsByType<GameObject>(FindObjectsSortMode.None))
        {
            if (obj.scene.name == "DontDestroyOnLoad")
            {
                Destroy(obj);
            }
        }

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}