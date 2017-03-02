using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public float timeConst = 5;
	private float timer;

	public LookableObject[] q1Objects;
	public LookableObject[] q2Objects;
	public LookableObject[] q3Objects;

	public TextMesh finalText;

	private LookableObject[] objects;
	private string[] winners;

	private int question = 0;
	private bool isFinished = false;

	// Use this for initialization
	void Start () {
		timer = timeConst;
		winners = new string[3];
		objects = q1Objects;
	}
	
	// Update is called once per frame
	void Update () {

		if (FoveInterface.IsEyeTrackingCalibrating() || isFinished) {
			return;
		}
			
		timer -= Time.deltaTime;
		if (timer < 0) {
			countViews ();
		}
		
	}

	private void countViews() {
		int winner = 0;
		string winnerName = "";
		foreach (LookableObject lookable in objects) {
			Debug.Log ("Object: " + lookable.name + " Count: " + lookable.getViewCount ());
			if (lookable.getViewCount() > winner) {
				winner = lookable.getViewCount();
				winnerName = lookable.name;
			}
			lookable.resetViews ();
		}

		Debug.Log ("Winner: " + winnerName);
		winners [question] = winnerName;
		updateObjects ();
	}

	private void updateObjects() {

		foreach (LookableObject obj in objects) {
			obj.gameObject.SetActive (false);
		}

		switch (++question) {
		case 1:
			objects = q2Objects;

			break;
		case 2:
			objects = q3Objects;
			break;
		default:
			endGame ();
			return;
		}

		foreach (LookableObject obj in objects) {
			obj.gameObject.SetActive (true);
		}

		timer = timeConst;
	}

	private void endGame() {
		Debug.Log ("The " + winners [0] + " went to the " + winners [1] + " to eat the " + winners [2] + ".");
		finalText.gameObject.SetActive (true);
		finalText.text = "The " + winners [0] + " went to the " + winners [1] + " to eat the " + winners [2] + ".";
		isFinished = true;
	}
}
