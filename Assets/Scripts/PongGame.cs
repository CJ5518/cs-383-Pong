using UnityEngine;
using UnityEngine.Events;

//Basic pong game implementation
public class PongGame : MonoBehaviour {
	//Objects we keep track of
	public Paddle leftPaddle;
	public Paddle rightPaddle;
	public Ball ball;

	//Events we emit
	public UnityEvent pongUpdate = new UnityEvent();
	//Set in the editor
	public UnityEvent pongInit;

	//Settings
	public PongConfig config;
	public bool paused = false;

	void Start() {
		Application.targetFrameRate = 60;
		config = new PongConfig();
	}

	// Update is called once per frame
	void FixedUpdate() {
		if (!paused)
			pongUpdate.Invoke();
	}

	void Update() {
		if (Input.GetKey(KeyCode.Escape))
             Application.Quit();
		if (Input.GetKey(KeyCode.R)) {
			pongInit.Invoke();
		}
	}
}
