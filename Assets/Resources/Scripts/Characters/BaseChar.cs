using UnityEngine;
using System.Collections;

public class BaseChar : MonoBehaviour {

    public const float coordConv = 3.2f;

	public static Object prefab;
	public PlayerControls playerControls;
	public Init_Floor init_Floor;
    
    /*public enum sexes { male, female };
    public sexes sex;*/

    public enum races { human, elf, orc, dwarf };
    public races race;

    public enum classes { barbarian, knight, rogue, ranger, mage, cleric };
    public classes class_;

    public int maxHealth;
    public int curHealth;
    public int maxEnergy;
    public int curEnergy;
    public int maxMoves;
    public int curMoves;

    public int bXCoord;
    public int bYCoord;

    public bool controllable = false;
    public bool hostile;// = true;
    public bool invincible = false;

    //public something vulnFear etc

    void Start()
    {
        playerControls = GameObject.Find("Level Controller").GetComponent<PlayerControls>();
		init_Floor = GameObject.Find("Level Controller").GetComponent<Init_Floor>();
    }

    void OnMouseOver()
    {
        if (Input.GetMouseButtonUp(0))//if we're left clicking
        {
            if (playerControls.actionMode == PlayerControls.ActionMode.selecting)
            {
                playerControls.selected = this;//you can select both controllable and non-controllable units (so you can see unit descs or w/e)

				playerControls.actionMode = PlayerControls.ActionMode.targeting;
				playerControls.targetingMode = PlayerControls.TargetingMode.move;
            }

            if (playerControls.actionMode == PlayerControls.ActionMode.targeting)//if we're currently trying to target something
            {
                if (playerControls.targetingMode == PlayerControls.TargetingMode.unit)//if we're targeting a move command
                {
                    playerControls.unitTarget = this;
                }

                /*else if (false)//clicking through?
                {

                }*/
            }
        }
    }

	public enum direction { up, down, left, right};
	public void MoveSquare(direction d)
	{

	}

	public bool canMove;
	public int validTiles;
	public int xMoveDist;
	public int yMoveDist;

	public void OnRightClick()
	{
		//if its a player-controlled unit
		//	do the right-click menu
	}

	public void PC_Move(int xTarget, int yTarget)//maybe move all this to basepc and write a separate thing for ai
	{
		validTiles = 0;
		xMoveDist = (bXCoord - xTarget);
		yMoveDist = (bYCoord - yTarget);

		if((curMoves >= xMoveDist) && (curMoves >= yMoveDist))
		{
			if ((xTarget > bXCoord) && (yTarget == bYCoord))//MOVING RIGHT
			{
				for (int i = 1; i <= xMoveDist; i++)//check to see if all the tiles you'd have to cross are traversable
				{
					if (init_Floor.floor[(bXCoord + i), bYCoord].traversable)
					{
						validTiles++;
					}
				}

				if (validTiles == xMoveDist)//if they all are traversable
				{
					//do move
					for (int i = 1; i <= (bXCoord - xTarget); i++)
					{
						MoveSquare(direction.right);
						curMoves--;
					}
				}

				else if (validTiles < (bXCoord - xTarget))//if one or more isn't traversable
				{
					//dont move
					print((xMoveDist - validTiles) + " not traversable");
				}

				else if (validTiles > (bXCoord - xTarget))//if there's more traversable tiles than tiles (debugging)
				{
					print("error: xMoveDist = " + xMoveDist + ", validTiles = " + validTiles);
				}

				else//somehow something else (debugging)
				{
					print("wtf");
				}
			}

			else if ((xTarget < bXCoord) && (yTarget == bYCoord))//MOVING LEFT
			{

			}

			else if ((xTarget == bXCoord) && (yTarget > bYCoord))//MOVING UP
			{

			}

			else if ((xTarget == bXCoord) && (yTarget < bYCoord))//MOVING DOWN
			{

			}
		}

		else
		{
			print("Insufficient moves");
			//do a nice ui thing for this later
		}
	}
}
