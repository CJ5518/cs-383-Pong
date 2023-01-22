using UnityEngine;


//Ball class for the pong game
//Requires a rect transform, which is what will be updated and moved across the screen
//The pivot of this rect transform should be at 0.5,0.5
public class Ball : MonoBehaviour {
	public PongGame pongGame;
	public RectTransform rectTransform;

	private Vector2 m_direction;
	private float angle;
	private float speed;

	//Hey BC, I can do stuff like this
	//I just don't very often, because it takes more effort, and take a look at one of my favorite quotes
	//From the book Programming in Lua https://www.lua.org/pil/16.4.html
	//"If you do not want to access something inside an object, just do not do it."
	//I probably will for the group project I guess, because of the group members
	public Vector2 direction {
		get {
			return m_direction;
		}
	}

	void Start() {
		init();
		pongGame.pongInit.AddListener(init);
		pongGame.pongUpdate.AddListener(tick);
	}

	void init() {
		//Size and position
		rectTransform.sizeDelta = new Vector2(pongGame.config.ballSize, pongGame.config.ballSize);
		rectTransform.position = new Vector3(Screen.width / 2.0f, Screen.height / 2.0f, 0.0f);

		//Speed and direction
		//Fire off the ball at the start of the game
		speed = (pongGame.config.ballSpeedPercent * Screen.width) / pongGame.config.tps;
		angle = Random.Range(-45.0f, 45.0f) * Mathf.Deg2Rad;
		m_direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
	}


	int bounceXCooldown = 0;
	int bounceYCooldown = 0;
	void tick() {
		//Move the ball and check for collision
		Vector3 movement = m_direction * speed;
		rectTransform.position = rectTransform.position + movement;
		
		float[] ballEdges = getRectEdges(rectTransform);
		if (bounceXCooldown > 0) {
			bounceXCooldown--;
		}
		if (bounceYCooldown > 0) {
			bounceYCooldown--;
		}
		float[] padEdge = getRectEdges(pongGame.leftPaddle.rectTransform);
		Debug.Log(ballEdges[0] + " " + padEdge[0] + " " + padEdge[1]);
		Debug.Log(ballEdges[2] + " " + padEdge[3] + " " + padEdge[2]);
		
		if ((checkCollisions(pongGame.rightPaddle.rectTransform) || checkCollisions(pongGame.leftPaddle.rectTransform)) && bounceXCooldown == 0) {
			m_direction.x = -m_direction.x;

			bounceXCooldown = 2;
		}
		//Debug.Log(ballEdges[2] + " " + Screen.height);
		if ((ballEdges[3] <= 0 || ballEdges[2] >= Screen.height) && bounceYCooldown == 0) {
			m_direction.y = -m_direction.y;
			bounceYCooldown = 2;
		}

	}

	//RectTransforms and me don't get along very well, so here's some functions to get rid of them
	float[] getRectEdges(RectTransform rect) {
		float[] floats = new float[4];
		floats[0] = rect.position.x - rect.sizeDelta.x; //left
		floats[1] = rect.position.x + rect.sizeDelta.x; //right
		floats[2] = rect.position.y + rect.sizeDelta.y; //top
		floats[3] = rect.position.y - rect.sizeDelta.y; //bottom
		return floats;
	}

	bool checkCollisions(RectTransform padRect) {
		float[] ballEdges = getRectEdges(rectTransform);
		float[] padEdges = getRectEdges(padRect);
		bool xInRange = inRange(ballEdges[0], padEdges[0], padEdges[1]) || inRange(ballEdges[1], padEdges[0], padEdges[1]);
		bool yInRange = inRange(ballEdges[2], padEdges[3], padEdges[2]) || inRange(ballEdges[3], padEdges[3], padEdges[2]);
		return xInRange & yInRange;
	}

	bool inRange(float checkNum, float min, float max) {
		return checkNum >= min && checkNum <= max;
	}
}
