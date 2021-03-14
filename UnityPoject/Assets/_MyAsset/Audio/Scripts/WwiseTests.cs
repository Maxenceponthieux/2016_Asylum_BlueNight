using UnityEngine;
using System.Collections;

public class WwiseTests : MonoBehaviour {


	public GameObject salle01, salle02;
	// Test au clavier pour appeler les events
	void Update () {
		if (Input.GetKeyDown (KeyCode.Keypad1)) {
			Debug.Log ("1");
			salle01.SetActive(true);
			salle02.SetActive(false);
			WwiseManager.Instance.playWwiseEvent (WwiseManager.EventsEnum.stop_amb_all);
		}
		if (Input.GetKeyDown (KeyCode.Keypad2)) {
			Debug.Log ("2");
			salle02.SetActive(true);
			salle01.SetActive(false);
			WwiseManager.Instance.playWwiseEvent (WwiseManager.EventsEnum.stop_amb_all);
		}
		if (Input.GetKeyDown (KeyCode.Keypad3)) {
			Debug.Log ("3");
		}
		if (Input.GetKeyDown (KeyCode.Keypad4)) {
		}
		if (Input.GetKeyDown (KeyCode.Keypad5)) {
		}
		if (Input.GetKeyDown (KeyCode.Keypad6)) {
		}
		if (Input.GetKeyDown (KeyCode.Keypad7)) {
		}
		if (Input.GetKeyDown (KeyCode.Keypad8)) {
		}
		if (Input.GetKeyDown (KeyCode.Keypad9)) {
		}
	}
}
