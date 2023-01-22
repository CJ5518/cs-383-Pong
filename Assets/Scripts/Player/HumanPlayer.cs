using UnityEngine;

//An implementation of a player made to accept human user input
//Dog user input coming soon
public class HumanPlayer : MonoBehaviour {
	public Paddle paddle;
	public PongGame pongGame;

	void Start() {
		pongGame.pongUpdate.AddListener(tick);
	}

	void tick() {
		bool goUp = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow);
		bool goDown = Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow);
		if (goUp) {
			paddle.upwardSpeed = 1.0f;
		}
		if (goDown) {
			paddle.upwardSpeed = -1.0f;
		}
		if (!(goDown || goUp)) {
			paddle.upwardSpeed = 0.0f;
		}
	}
}
