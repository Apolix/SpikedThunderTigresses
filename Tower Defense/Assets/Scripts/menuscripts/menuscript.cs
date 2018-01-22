using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class menuscript : MonoBehaviour {

	public Canvas QuitMenu;
	public Button startgame;
	public Image start_br;
	public Image exit_br;
	public Button exit;
	// Use this for initialization
	void Start () {
		//getcomponentek
		QuitMenu = QuitMenu.GetComponent<Canvas> ();
		startgame = startgame.GetComponent<Button> ();
		exit = exit.GetComponent<Button> ();
		start_br = start_br.GetComponent<Image> ();
		exit_br = start_br.GetComponent<Image> ();
		QuitMenu.enabled = false;
	}
	public void ExitPress()
	{
		//Quitmenu bekapcsolása
		QuitMenu.enabled = true;
		startgame.enabled = false;
		exit.enabled = false;
		start_br.enabled = false;
		exit_br.enabled = false;
	}
	public void nopress ()
	{
		//quitmenu kikapcsolása
		QuitMenu.enabled = false; 
		startgame.enabled = true;
		exit.enabled = true; 
		start_br.enabled = true;
		exit_br.enabled = true; 
	}
	public void startpress()
	{
		SceneManager.LoadScene ("Level01"); //betölti a pályát
	}
	public void ExitGame()
	{
		Application.Quit (); //kilép
	}
}
