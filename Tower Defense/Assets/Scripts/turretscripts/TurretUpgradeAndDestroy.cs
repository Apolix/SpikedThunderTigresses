using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class TurretUpgradeAndDestroy : MonoBehaviour {
	public Canvas upgradedestroy; //canvas
	public Image movingImage; //felugró ablak
	public Text destroy_text, upgrade_text;
    public GameObject gamemanager, turretUpgrade;
    public float multyplier = 0.5f;
    int turret_cost;

    building build_script;
	GameObject turret_v; //a turret amire kattintasz
    Transform turretvTransform;
	Ray ray;
	RaycastHit hit;

	// Use this for initialization
	void Start () {
		upgradedestroy.GetComponent<Canvas> ();
		movingImage.GetComponent<Image> ();
		upgradedestroy.enabled = false;
		build_script = gamemanager.GetComponent<building> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Mouse0)) {
			ray = Camera.main.ScreenPointToRay(Input.mousePosition);//megnézi hol van az egér
			Physics.Raycast(ray, out hit); 

			if (hit.transform.tag=="basic_turret") {
				turretClick(build_script.turret_1_cost);

			}
			if (hit.transform.tag=="sniper_turret") {
                turretClick(build_script.sniper_tower_cost);

			}
		}
	}


    void turretClick(int Cost)
    {
        upgradedestroy.enabled = true;
        movingImage.transform.position = new Vector3(Input.mousePosition.x + 150, Input.mousePosition.y + 150, Input.mousePosition.z);

        turret_v = hit.transform.gameObject;
        turret_cost = Cost;
        destroy_text.text = "Destroy(" + Mathf.RoundToInt(turret_cost * multyplier) + " gold)";
    }

	public void close_window()
	{
		upgradedestroy.enabled = false; //bezárja az ablakot
	}

	public void upgrade_click() //mi történjen upgradénél 								
	{
        turretvTransform = turret_v.transform;
        Destroy(turret_v);
        Instantiate(turretUpgrade, turretvTransform.position, Quaternion.identity);
        close_window();
    }

	public void destroy_click() //destroy
	{
		Destroy (turret_v);
		build_script.gold += Mathf.RoundToInt( turret_cost * 0.3f);
		close_window ();
	}
}
