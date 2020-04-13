using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class DeathMenu : MonoBehaviour {

	public Image background;
	public Text scoreText;
	public bool isshown;
	private float transition = 0.0f;

	void Start () {
		gameObject.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if (!isshown)
			return;

		transition += Time.deltaTime;
		background.color = Color.Lerp (new Color (0, 0, 0, 0), Color.black, transition);
	}

	public void TogleEndMenu(float score)
	{
		gameObject.SetActive (true);
		scoreText.text = ((int)score).ToString ();
		isshown = true;
	}

	public void Restart(){
		SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
	}
}
