using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] Transform _camera;
    [SerializeField] float _cameraTurnSpeed;
    
    void Update()
    {
        _camera.Rotate(0, _cameraTurnSpeed, 0);
    }

    public void StartGame()
    {
        SceneManager.LoadScene("GameScene");
    }
}
