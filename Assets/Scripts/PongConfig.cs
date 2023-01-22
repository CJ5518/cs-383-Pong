using UnityEngine;


//Configuration for the pong game
public class PongConfig {
	//Ball settings
	//1 would mean the ball travels the horizontal width of the screen in one tick
	//while moving straight across .5 is half, etc.
	public float ballSpeedPercent = 0.3f;
	//Min and max angles the ball can bounce on a paddle
	public float ballMinBounceAngle = 0.0f;
	public float ballMaxBounceAngle = 80.0f * Mathf.Deg2Rad;

	//Ball width and height
	public float ballSize = 30;

	//Paddle settings
	//How far are the paddles from the blast zones?
	public float paddleDistanceFromSidesPercentage = 0.03f;
	//1.0f means it travels the entire height in one tick
	public float paddleSpeedPercent = 0.01f;

	//Paddle size
	public float paddleWidth = 20;
	public float paddleHeightPercent = 0.2f;

	//Game settings
	//How many points do you need to win?
	public int winningPoint = 4;
	//Right now we just use fixed update, which should be 50 per second
	//But yea changing this does nothing
	public float tps = 50.0f;
}