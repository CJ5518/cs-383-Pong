using UnityEngine;
using System.Threading;

public class AIPlayer : MonoBehaviour {
	public Paddle paddle;
	public PongGame pongGame;

	void Start() {
		pongGame.pongUpdate.AddListener(tick);
	}

	void tick() {
		if (pongGame.ball.rectTransform.position.y - pongGame.ball.rectTransform.rect.height
		> paddle.rectTransform.position.y - paddle.rectTransform.rect.height) {
			paddle.upwardSpeed = 1.0f;
		} else {
			paddle.upwardSpeed = -1.0f;
		}
	}
}
