using UnityEngine;

public class RatSpawner : MonoBehaviour
{
    [SerializeField] GameObject Rat;
    [SerializeField] GameObject SpawnerGO;
    [SerializeField] float spawnTimer;
    [SerializeField] float SpawnDistance = 10f;
    public GameObject player;
    public GameObject CamDirection;
    public float timer;
    public Vector3 spawnPos;


    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnTimer)
        {
            spawnRat();
            timer = 0;
        }
    }
    private void spawnRat()
    {
        generateSpawnPosition();
        GameObject spawnedEnemy = Instantiate(Rat, spawnPos, Quaternion.identity);
        spawnedEnemy.GetComponent<Rat>().player = player.transform;
    }

    private void generateSpawnPosition()
    {
         Vector3 spawnPosition = CamDirection.transform.position + (-CamDirection.transform.forward * SpawnDistance);
        spawnPos = spawnPosition;
        Debug.Log(spawnPosition);
    }
}
