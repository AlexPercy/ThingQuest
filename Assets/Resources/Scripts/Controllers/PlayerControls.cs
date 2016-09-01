using UnityEngine;
using System.Collections;

public class PlayerControls : MonoBehaviour {

    GameController gameController;
	public BaseChar[] playerUnits;

    public bool playerHasControl;
    public enum ActionMode { none, selecting, targeting_move, targeting_unit, targeting_aoe, executing };//selecting is choosing one of your squad to give a command to - targeting is targeting a command - executing is when performing a command (overlaps with none)
    public ActionMode actionMode;

    //public enum TargetingMode { none, move, unit, aoe };
    //public TargetingMode targetingMode;


    public BaseChar selected;//the unit you're giving commands to

    public BaseTile moveTarget;//yo lets get some a* up in this delirious biznasty
    //public int moveTargetX;
    //public int moveTargetY;

    public BaseChar unitTarget;//for attacking, single-target abilities, etc. -- should maybe make a BaseUnit and have BaseChar extend it (for non-character units, like an interactable object (switch or w/e))

    public BaseTile aoeTarget;//centrepoint target for aoe things
    //public int aoeTargetX;
    //public int aoeTargetY;

    void Start()
    {
        gameController = this.gameObject.GetComponent<GameController>();
        playerHasControl = false;
    }
    
    void Update()
    {
        if(gameController.gameplayHapen)//would we not want gpHapen to be true here? im pretty sure we would
        {
            if (gameController.playersTurn)
            {
                playerHasControl = true;
            }
            else
            {
                playerHasControl = false;
            }
        }
		else
		{
			playerHasControl = false;
		}
    }

	int n;
    public void MoveUnit()
	{
		n = 0;
		//moveTarget = null;
		actionMode = ActionMode.targeting_move;
		//targetingMode = TargetingMode.move;

		while(n < 3)//while theres no tile selected
		{
			print("asdf");
			n++;
		}

		selected.PC_Move(moveTarget.bXCoord, moveTarget.bYCoord);

		//actionMode = ActionMode.selecting;
	}
}
