using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class TurretUpgradeAndDestroy : MonoBehaviour {
	public Canvas upgradedestroy; //canvas
	public Image movingImage, upgrade_background; //felugró ablak
	public Text destroy_text, upgrade_text, targeting_text;
    public GameObject gamemanager, basicTurretUpgrade; //Visszaraktam ide logikai okból
	public float multyplier = 0.5f;
    int turret_cost;
	public int upgrade_multyplier = 2;
	Button upgrade_button;
    building build_script;
	GameObject turret_v; //a turret amire kattintasz
    Transform turretvTransform;
	ColorBlock upgrade_color;
	Ray ray;
	RaycastHit hit;
	BasicShooting basicshooting_v;
	SniperTowerShooting snipertowershooting_v;

	// Use this for initialization
	void Start () {
		upgradedestroy.GetComponent<Canvas> ();
		movingImage.GetComponent<Image> ();
		upgradedestroy.enabled = false;
		build_script = gamemanager.GetComponent<building> ();
		upgrade_button = upgrade_text.GetComponent<Button> ();
		upgrade_background.GetComponent<Image> ();
		upgrade_color = upgrade_button.colors;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Mouse0)) {
			ray = Camera.main.ScreenPointToRay(Input.mousePosition);//megnézi hol van az egér
			Physics.Raycast(ray, out hit);
            if (hit.transform.position.y <= 2f)
            {
                if (hit.transform.tag == "basic_turret_u")
                {
					turretClick(turret_cost * upgrade_multyplier, true);  //megnézi milyen turretre kattintasz a tag alapján, megadja az árát és hogy upgradolt-e
					targeting_text.text = basicshooting_v.targetingtextget (); //beállítja a targetintextet
                }
                if (hit.transform.tag == "basic_turret")
                {
                    turretClick(build_script.turret_1_cost, false);
					basicshooting_v = turret_v.GetComponent<BasicShooting> (); //megnézi milyen turretre kattintasz a tag alapján, megadja az árát és hogy upgradolt-e
					targeting_text.text = basicshooting_v.targetingtextget (); //beállítja a targetintextet

                }
                if (hit.transform.tag == "sniper_turret")
                {
                    turretClick(build_script.sniper_tower_cost, false);
					snipertowershooting_v = turret_v.GetComponent<SniperTowerShooting> (); //megnézi milyen turretre kattintasz a tag alapján, megadja az árát és hogy upgradolt-e
					targeting_text.text = snipertowershooting_v.targetingtextget (); //beállítja a targetintextet

                }
            }
		}
	}


	void turretClick(int Cost, bool upgraded)
    {
        upgradedestroy.enabled = true;
        movingImage.transform.position = new Vector3(Input.mousePosition.x + 150, Input.mousePosition.y + 150, Input.mousePosition.z); //turrethez viszi a popupot

        turret_v = hit.transform.gameObject;
        turret_cost = Cost;
        destroy_text.text = "Destroy(" + Mathf.RoundToInt(Cost * multyplier) + " gold)";
		upgrade_text.text = "Upgrade(" + Mathf.RoundToInt(Cost * upgrade_multyplier) + " gold)"; //textek

		upgrade_background.enabled = !upgraded;
		upgrade_text.enabled = !upgraded; //kikapcsolja az upgrade opciót ha upgraded a torony

		if (build_script.gold <  Mathf.RoundToInt(turret_cost * upgrade_multyplier)) {
			upgrade_text.color = Color.gray;
			upgrade_color.highlightedColor = new Color(192, 192, 192);
			upgrade_button.colors = upgrade_color;
		} else {
			upgrade_text.color = Color.yellow;
			upgrade_color.highlightedColor = new Color (0, 255, 0);
			upgrade_button.colors = upgrade_color; //a gold alapján állitja az upgrade text színét
		}
    }

	public void close_window()
	{
		upgradedestroy.enabled = false; //bezárja az ablakot
	}

	public void upgrade_click() //mi történjen upgradénél 								
	{
        turretvTransform = turret_v.transform;
		if (build_script.gold >= turret_cost * upgrade_multyplier) {
			Destroy(turret_v);
			Instantiate(basicTurretUpgrade, turretvTransform.position, turretvTransform.rotation);
			close_window();
			build_script.gold -= turret_cost;
			close_window ();
		}

    }

	public void destroy_click() //destroy
	{
		Destroy (turret_v);
		build_script.gold += Mathf.RoundToInt(turret_cost * multyplier);
		close_window ();
	}

	public void targeting_click() //targeting cseréléshez van 
	{
		print ("valami");
		if (turret_v.transform.gameObject.tag == "basic_turret" || turret_v.transform.gameObject.tag == "basic_turret_u") {
			basicshooting_v.targeting_set (targeting_text);
		}
		if (turret_v.transform.gameObject.tag == "sniper_turret") {
			snipertowershooting_v.targeting_set (targeting_text);
		}
	}
}
