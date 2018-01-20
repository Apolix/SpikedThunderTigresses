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
	public int waveszámláló_NE_ÍRD_ÁT = 0; //azért public hogy más scriptben lehessen látni
    public float TimeBetweenWaves = 40f;
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
        TimeBetweenWavesText.text = Mathf.Round(countdown).ToString();
    }

	IEnumerator SpawnWave()
    {
        //Ellenségek spawnoltatása
        EnemyCount = Random.Range(start_min_enemy, start_max_enemy);
		print (waveszámláló_NE_ÍRD_ÁT);
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
				start_txt.enabled = true;
				start_bp.enabled = true;
				TimeBetweenWavesText.enabled = true;
				waveszámláló_NE_ÍRD_ÁT += 1;
				countdown = TimeBetweenWaves;
			}
			
        }

    }
	public void wavestart_click()
	{
		wavestart = true;
	}

    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
