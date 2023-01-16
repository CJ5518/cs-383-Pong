using UnityEngine;

//Basic pong game implementation
public class PongGame : MonoBehaviour {
	public Paddle leftPaddle;
	public Paddle rightPaddle;
	public Ball ball;


	//The left and right x coord edges of the map, left is negative, right is positive
	//Set automatically
	float extremeLeftXCoord = 0.0f;
	float extremeRightXCoord = 0.0f;

	void Start() {
		//Make sure the paddles start at the edge of the screen
		float aspect = (float)Screen.width / (float)Screen.height;
		extremeRightXCoord = Camera.main.orthographicSize * aspect;
		extremeLeftXCoord = -extremeRightXCoord;
	}

	// Update is called once per frame
	void Update() {

	}
}
