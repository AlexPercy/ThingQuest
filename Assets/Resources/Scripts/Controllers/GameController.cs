using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

    PlayerControls playerControls;
    //AIControls aiControls;

    public bool playersTurn;
	public bool gameplayHapen;

	public bool gameOver;
    public bool playerIsWinning;
	public bool handlingGameOver;
    

    void Start()
    {
        playerControls = this.gameObject.GetComponent<PlayerControls>();
		//aiControls = this.gameObject.GetComponent<AIControls>();
		
		gameplayHapen = true;//this should probably start false for cutscenes/whatever?

		gameOver = false;
        playerIsWinning = false;
		handlingGameOver = false;

        //playerControls.playerHasControl = false;
        //Level_Start();
    }

    /*void Level_Start()
    {
        //start of level

        playerControls.playerHasControl = false;
        //do cutscene or w/e

        //Gameplay_Happen();
    }*/

    /*void Gameplay_Happen()
    {
        //begin gameplay

        /*if (playersTurn)//if it's the player's turn, just let them fuck around as they please
        {
            playerControls.actionMode = PlayerControls.ActionMode.selecting;
            playerControls.Turn_Player();
        }* /

        if(!playersTurn)//if it's not the player's turn, restrict them and let the AI have at it
        {
            playerControls.actionMode = PlayerControls.ActionMode.nocontrol;
            aiControls.doTurn();
        }

        if(gameOver)
        {
            Level_End();
        }
    }*/

    void Update()
    {
        if(!handlingGameOver)
		{
			if (gameOver)
			{
				gameplayHapen = false;
				playerControls.playerHasControl = false;
				handlingGameOver = true;

				if (playerIsWinning)
				{
					//player wins!

					print("ya done it");
					//do cutscene
					//move onto next level/customisation screen/whatever
				}

				else
				{
					//player loses :(

					print("ya done goofed");
					//do game over cutscene
					//go back to last customisation screen
				}
			}
		}
    }

    public void EndTurn(bool isPlayer)
	{
		if(isPlayer)
		{
			playersTurn = false;
		}

		else
		{
			playersTurn = true;
		}
	}
}
