using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

	private float score = 0.0f;
	private int diclt = 1, maxdiclt = 10, scrtonxt = 10;
	private bool isdead = false;
	public Text scoreText ;
	public DeathMenu deathmenu;

	void Update () {

		if (isdead)
			return;

		if (score >= scrtonxt)
			LevelUp ();

		score += Time.deltaTime * diclt;
		scoreText.text = ((int)score).ToString ();
	}

	void LevelUp()
	{
		if (diclt == maxdiclt)
			return;
		scrtonxt *= 2;
		diclt++;
		GetComponent<PlayerMotor>().SetSpeed(diclt);
	}

	public void Ondeath()
	{
		isdead = true;
		PlayerPrefs.SetFloat ("Highscore", score);
		deathmenu.TogleEndMenu (score);
	}
}
