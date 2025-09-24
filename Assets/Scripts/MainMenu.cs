using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] Transform _camera;
    [SerializeField] float _cameraTurnSpeed;
    
    void Update()
    {
        _camera.localEulerAngles = new Vector3(_camera.rotation.eulerAngles.x, (_camera.rotation.eulerAngles.y + _cameraTurnSpeed * Time.deltaTime) % 360, 0);
    }

    public void StartGame()
    {
        SceneManager.LoadScene("GameScene");
    }
}
