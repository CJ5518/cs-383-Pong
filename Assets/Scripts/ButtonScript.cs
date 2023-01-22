using UnityEngine;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour {
	public GameObject helpScreen;
	public PongGame pongGame;

	public void OnButtonPress() {
		pongGame.paused = !pongGame.paused;
		helpScreen.SetActive(!helpScreen.activeSelf);
	}
}
