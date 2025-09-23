using UnityEngine;

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
            _paused = !_paused;
        }
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        _pauseMenu.SetActive(true);
    }

    public void UnpauseGame()
    {
        Time.timeScale = 1;
        _pauseMenu.SetActive(false);
    }
}
