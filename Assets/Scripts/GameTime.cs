using TMPro;
using UnityEngine;

public class GameTime : MonoBehaviour
{
    //add timer
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float timer = 0;
    private float minutes = 0;
    private float seconds = 0;

    [SerializeField] public TMP_Text time;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        minutes = Mathf.Floor(timer / 60);
        seconds = timer % 60;
        time.text = string.Format("{0:0}:{1:00.00}", minutes, seconds);
    }
}
