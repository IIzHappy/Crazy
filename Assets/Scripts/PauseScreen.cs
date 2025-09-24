using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScreen : MonoBehaviour
{
    [SerializeField] GameObject _pauseMenu;

    bool _paused = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (_paused)
            {
                UnpauseGame();
            } else
            {
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        _pauseMenu.SetActive(true);
        _paused = true;
    }

    public void UnpauseGame()
    {
        Time.timeScale = 1;
        _pauseMenu.SetActive(false);
        _paused = false;
    }

    public void ToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
