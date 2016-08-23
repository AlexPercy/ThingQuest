using UnityEngine;
using System.Collections;

public class test : MonoBehaviour {

	GameController gameController;

	void Start()
	{
		gameController = this.gameObject.GetComponent<GameController>();
	}

	public void Test()
	{
		if(gameController.playersTurn)
		{
			print("test");
		}
	}
}
