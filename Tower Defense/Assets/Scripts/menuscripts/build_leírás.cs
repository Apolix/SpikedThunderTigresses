using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class build_leírás : MonoBehaviour {
	public Image turret1_bp;
	public Text turret1_txt;
	void Start()
	{
		components (turret1_bp, turret1_txt);
		falsing (turret1_bp, turret1_txt);

	}
	public void cursorhover_turret1()
	{
		truing (turret1_bp, turret1_txt);
	}
	public void cursorout_turret1()
	{
		falsing (turret1_bp, turret1_txt);
	}






	void components(Image im_v, Text txt_v)
	{
		im_v.GetComponent<Image> ();
		txt_v.GetComponent<Text> ();
	}
	void falsing(Image im_v, Text txt_v)
	{
		im_v.enabled = false;
		txt_v.enabled = false;
	}
	void truing(Image im_v, Text txt_v)
	{
		im_v.enabled = true;
		txt_v.enabled = true;
	}
}
