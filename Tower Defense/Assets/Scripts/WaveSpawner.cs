using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour {

    public Transform enemyPrefab;
    public Transform spawnPoint;
    public Text TimeBetweenWavesText;

    public float TimeBetweenWaves = 10f;
    public int EnemyCount = 8;

    private float countdown;

    void Update()
    {
        if (countdown <= 0)
        {
            StartCoroutine(SpawnWave());
            countdown = TimeBetweenWaves;
        }

        countdown -= Time.deltaTime;
        TimeBetweenWavesText.text = Mathf.Round(countdown).ToString();
    }

    IEnumerator SpawnWave()
    {
        EnemyCount = Random.Range(1, 11);

        for (int i = 0; i < EnemyCount; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.4F);
        }
    }

    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
