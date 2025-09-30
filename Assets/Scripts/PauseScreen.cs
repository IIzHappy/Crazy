using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScreen : MonoBehaviour
{
    [SerializeField] GameObject _pauseMenu;
    [SerializeField] PlayerController _player;

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
        Cursor.lockState = CursorLockMode.None;
        _player.canPlay = false;
    }

    public void UnpauseGame()
    {
        Time.timeScale = 1;
        _pauseMenu.SetActive(false);
        _paused = false;
        Cursor.lockState = CursorLockMode.Locked;
        _player.canPlay = true;
    }

    public void ToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
