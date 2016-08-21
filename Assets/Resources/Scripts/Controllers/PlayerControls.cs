using UnityEngine;
using System.Collections;

public class PlayerControls : MonoBehaviour {

    GameController gameController;


    public bool playerHasControl;
    public enum ActionMode { selecting, targeting, executing };//selecting is choosing one of your squad to give a command to - targeting is targeting a command - executing is when performing a command (overlaps with nocontrol)
    public ActionMode actionMode;

    public enum TargetingMode { move, unit, aoe };
    public TargetingMode targetingMode;


    public BaseChar selected;//the unit you're giving commands to

    public Tile moveTarget;//yo lets get some a* up in this delirious biznasty
    //public int moveTargetX;
    //public int moveTargetY;

    public BaseChar unitTarget;//for attacking, single-target abilities, etc. -- should maybe make a BaseUnit and have BaseChar extend it (for non-character units, like an interactable object (switch or w/e))

    public Tile aoeTarget;//centrepoint target for aoe things
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
    }

    /*public void Turn_Player()
    {

    }*/
}
