﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class BuildDescription : MonoBehaviour {

	public Image turret1_bp,sniper_tower_bp;
	public Text turret1_txt, sniper_tower_txt;

	void Start()
	{
		components (turret1_bp, turret1_txt);
		falsing (turret1_bp, turret1_txt);
		components (sniper_tower_bp, sniper_tower_txt);
		falsing (sniper_tower_bp, sniper_tower_txt);

	}

	public void cursorhover_turret1()
	{
		truing (turret1_bp, turret1_txt);
	}
	public void cursorout_turret1()
	{
		falsing (turret1_bp, turret1_txt);//basic turret build popupja
	}

	public void cursorhover_sniper()
	{
		truing (sniper_tower_bp, sniper_tower_txt);
	}
	public void cursorout_sniper()
	{
		falsing (sniper_tower_bp, sniper_tower_txt); //sniper turret build popupja
	}


	void components(Image im_v, Text txt_v)
	{
		im_v.GetComponent<Image> ();
		txt_v.GetComponent<Text> ();//lusta vagyok
	}
	void falsing(Image im_v, Text txt_v)
	{
		im_v.enabled = false;
		txt_v.enabled = false; //lusta vagyok
	}
	void truing(Image im_v, Text txt_v)
	{
		im_v.enabled = true;
		txt_v.enabled = true;//lusta vagyok
	}
}
