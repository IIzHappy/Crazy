using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CrazyCounter : MonoBehaviour
{
    [SerializeField] TMP_Text _crazyTextDefault;
    [SerializeField] float _crazySizeStart;
    [SerializeField] float _crazySizeFinal;
    [SerializeField] TMP_Text _crazyTextEnd;
    [SerializeField] Image _redOverlay;

    float _crazyCounter = 0;
    float _crazyPercent = 0;
    [SerializeField] float _maxCrazy;

    [SerializeField] GameObject _pauseMenu;


    void Awake()
    {
        ResetGame();
    }

    public void ResetGame()
    {
        _crazyCounter = 0;
        _crazyPercent = 0;

        _crazyTextDefault.gameObject.SetActive(true);
        _crazyTextDefault.fontSize = _crazySizeStart;
        _crazyTextDefault.color = Color.HSVToRGB(0, 0, 100); ;

        _crazyTextEnd.gameObject.SetActive(false);

        Color color = _redOverlay.color;
        color.a = 0;
        _redOverlay.color = color;

        _pauseMenu.SetActive(true);
    }

    //REMOVE THIS UPDATE WHEN U REFERENCE METHOD IN RAT SCRIPT
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            AddCrazy();
            Debug.Log(_crazyCounter + " - " + _crazyPercent);
        }
    }

    public void AddCrazy()
    {
        _crazyCounter++;

        if (_crazyCounter >= _maxCrazy)
        {
            MaxCrazy();
            return;
        }
        _crazyPercent = Mathf.Clamp01(_crazyCounter / _maxCrazy);

        Color color = _redOverlay.color;
        color.a = _crazyPercent * 0.8f;
        _redOverlay.color = color;

        _crazyTextDefault.fontSize = Mathf.Lerp(_crazySizeStart, _crazySizeFinal, _crazyPercent);
        Color colorText = Color.HSVToRGB(0, _crazyPercent * 1.15f, 1);
        _crazyTextDefault.color = colorText;
    }

    //Game over
    void MaxCrazy()
    {
        _crazyTextDefault.gameObject.SetActive(false);
        _crazyTextEnd.gameObject.SetActive(true);

        Color color = _redOverlay.color;
        color.a = 0.85f;
        _redOverlay.color = color;

        _pauseMenu.SetActive(false);
    }
}
