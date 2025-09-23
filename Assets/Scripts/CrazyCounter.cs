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

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
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
    }
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
        Color colorText = Color.HSVToRGB(0, _crazyPercent * 1.2f, 1);
        _crazyTextDefault.color = colorText;
    }

    void MaxCrazy()
    {
        _crazyTextDefault.gameObject.SetActive(false);
        _crazyTextEnd.gameObject.SetActive(true);

        Color color = _redOverlay.color;
        color.a = 1;
        _redOverlay.color = color;
    }
}
