using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour {

    public Transform enemyPrefab;
    public Transform spawnPoint;
    public Text TimeBetweenWavesText, start_txt;
	public Image start_bp;
	public int start_min_enemy = 2, start_max_enemy = 5, enemyk_körönkénti_növelése = 2;
	public bool wavestart = false;
	int waveszámláló_v = 0;
    public float TimeBetweenWaves = 40f;
	float enemys_alive;
	bool gomb_megjelenít = false;
    private int EnemyCount;

    private float countdown;

	void Start()
	{
		countdown = TimeBetweenWaves;
	}
    void Update()
    {
        //Wave-ek ellindítása és időzítése
		if (wavestart == true)
        {
            //SpawnWave();
			StartCoroutine(SpawnWave());
		}
		if (countdown == 0 || countdown < 0) {
			wavestart = true;
			countdown = 0;
		}
		if (countdown != 200) {
			countdown -= Time.deltaTime;
		}
		if (gomb_megjelenít == true) {
			start_txt.enabled = true;
			start_bp.enabled = true;
			TimeBetweenWavesText.enabled = true;
			countdown = TimeBetweenWaves;
			gomb_megjelenít = false;
		}
        TimeBetweenWavesText.text = Mathf.Round(countdown).ToString();
    }
	public int waveszámláló()
	{
		return waveszámláló_v;
	}

	IEnumerator SpawnWave()
    {
        //Ellenségek spawnoltatása
        EnemyCount = Random.Range(start_min_enemy, start_max_enemy);
		enemys_alive = EnemyCount;
		countdown = 200;
		wavestart = false;
		start_txt.enabled = false;
		start_bp.enabled = false;
		TimeBetweenWavesText.enabled = false;

        for (int i = 0; i < EnemyCount; i++)
        {
            SpawnEnemy();
			yield return new WaitForSeconds (0.4f);
			if (i == EnemyCount - 1) {
				start_min_enemy += enemyk_körönkénti_növelése;
				start_max_enemy += enemyk_körönkénti_növelése;
				waveszámláló_v += 1;

			}
			
        }

    }
	public void wavestart_click()
	{
		wavestart = true;
	}
	public void enemykill()
	{
		enemys_alive -= 1;
		if (enemys_alive == 0) {
			gomb_megjelenít = true;
			
		}
	}
    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
