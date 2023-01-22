using UnityEngine;
using UnityEngine.Events;


//Requires a rect transform, which is what will be updated and moved across the screen
//Controlled by players by changing upward speed, where a speed of 1 is config move rate upward,
//-1 is config speed downwards, 20 is 20 times faster than config speed, etc.
public class Paddle : MonoBehaviour {
	public PongGame pongGame;
	public bool rightSide = true;
	public RectTransform rectTransform;

	public float upwardSpeed = 0.0f;

	public void init() {
		//Set size according to config
		Debug.Log(rectTransform);
		Debug.Log(rectTransform.sizeDelta);
		Debug.Log(pongGame.config);
		rectTransform.sizeDelta = new Vector2(pongGame.config.paddleWidth, Screen.height * pongGame.config.paddleHeightPercent);

		float posX = rightSide //If right side
		? (Screen.width - pongGame.config.paddleWidth) - (Screen.width * pongGame.config.paddleDistanceFromSidesPercentage) 
		//If left side
		: Screen.width * pongGame.config.paddleDistanceFromSidesPercentage;

		rectTransform.position = new Vector3(posX, (Screen.height / 2) + rectTransform.sizeDelta.y / 2.0f, 0.0f);
	}

	void Start() {
		init();
		pongGame.pongInit.AddListener(init);
		pongGame.pongUpdate.AddListener(tick);
	}
	
	void tick() {
		rectTransform.position += new Vector3(0, upwardSpeed * pongGame.config.paddleSpeedPercent * Screen.height, 0);
		rectTransform.position = new Vector3(rectTransform.position.x, Mathf.Clamp(
			rectTransform.position.y, 0 + rectTransform.sizeDelta.y, Screen.height
		), 0);
	}

	// Update is called once per frame
	void Update() {
		
	}
}
