using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class menuscript : MonoBehaviour {

	public Canvas QuitMenu;
	public Button startgame;
	public Button exit;
	// Use this for initialization
	void Start () {
		QuitMenu = QuitMenu.GetComponent<Canvas> ();
		startgame = startgame.GetComponent<Button> ();
		exit = exit.GetComponent<Button> ();
		QuitMenu.enabled = false;
	}
	public void ExitPress()
	{
		QuitMenu.enabled = true;
		startgame.enabled = false;
		exit.enabled = false;
	}
	public void nopress ()
	{
		QuitMenu.enabled = false;
		startgame.enabled = true;
		exit.enabled = true;
	}
	public void startpress()
	{
		SceneManager.LoadScene ("Level01");
	}
	public void ExitGame()
	{
		Application.Quit ();
	}
}
