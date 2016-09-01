using UnityEngine;
using System.Collections;

public class BaseChar : MonoBehaviour {

    public const float coordConv = 3.2f;

	public static Object prefab;
	public PlayerControls playerControls;
	public Init_Floor init_Floor;


	public string name_;

	public enum races { human, elf, orc, dwarf };
    public races race;

    public enum classes { barbarian, knight, rogue, ranger, mage, cleric };
    public classes class_;

    public int maxHealth;
    public int curHealth;

    public int maxEnergy;
    public int curEnergy;

	public int maxActions;
	public int curActions;

    public int maxMoves;
    public int curMoves;

	public bool canMove;//i forget what this was for. i dont think it was for roots or anything. i think its deprecated
	public int validTiles;
	public int xMoveDist;
	public int yMoveDist;
	public enum direction { up, down, left, right };


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

	public float rcXCoord;
	public float rcYCoord;

	public void RefreshCoords()
	{
		//bXCoord = (int)(gameObject.transform.position.x / coordConv);
		bXCoord = System.Convert.ToInt32(gameObject.transform.position.x / coordConv);//apparently just casting it to the correct type was fucking with it for some reason (16/3.2 = 4???)
		//bYCoord = (int)(gameObject.transform.position.y / coordConv);
		bYCoord = System.Convert.ToInt32(gameObject.transform.position.y / coordConv);
	}

    void OnMouseOver()
    {
        if (Input.GetMouseButtonUp(0))
        {
			OnLeftClick();
        }

		if (Input.GetMouseButtonUp(1))
		{
			OnRightClick();
		}
    }

	void OnLeftClick()
	{
		if (playerControls.actionMode == PlayerControls.ActionMode.selecting)
		{
			playerControls.selected = this;//you can select both controllable and non-controllable units (so you can see unit descs or w/e)

			//playerControls.actionMode = PlayerControls.ActionMode.targeting;
			//playerControls.targetingMode = PlayerControls.TargetingMode.move;
		}

		if (playerControls.actionMode == PlayerControls.ActionMode.targeting_unit)//if we're currently trying to target something
		{
			playerControls.unitTarget = this;
		}

		/*else if (false)//clicking through?
		{

		}*/
	}

	public void OnRightClick()
	{
		//if its a player-controlled unit
		print("right clock");
		//	do the right-click menu
	}


	public void MoveSquare(direction d)
	{
		if (d == direction.right)
		{
			gameObject.transform.position = new Vector3(gameObject.transform.position.x + coordConv, gameObject.transform.position.y);
		}

		else if (d == direction.left)
		{
			gameObject.transform.position = new Vector3(gameObject.transform.position.x - coordConv, gameObject.transform.position.y);
		}

		else if (d == direction.up)
		{
			gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + coordConv);
		}

		else if (d == direction.down)
		{
			gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y - coordConv);
		}

		//System.Threading.Thread.Sleep(500);

		RefreshCoords();
		//GetTileEffect();
		print(gameObject.transform.name.ToString() + " moved " + d.ToString() + "!");
	}

	public void PC_Move(int xTarget, int yTarget)//    Make it check to see if there's a unit on the tile too
	{
		validTiles = 0;
		xMoveDist = Mathf.Abs((xTarget - bXCoord));
		yMoveDist = Mathf.Abs((yTarget - bYCoord));

		if((curMoves >= xMoveDist) && (curMoves >= yMoveDist))
		{
			//----------------MOVING RIGHT----------------
			if ((xTarget > bXCoord) && (yTarget == bYCoord))
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
					print("do move");//do move
					for (int i = 1; i <= xMoveDist; i++)
					{
						MoveSquare(direction.right);
						curMoves--;
					}
				}

				else if (validTiles < xMoveDist)//if one or more isn't traversable
				{
					//dont move
					print((xMoveDist - validTiles) + " not traversable");
				}

				else if (validTiles > xMoveDist)//if there's more traversable tiles than tiles (debugging)
				{
					print("error: xMoveDist = " + xMoveDist + ", validTiles = " + validTiles);
				}

				else//somehow something else (debugging)
				{
					print("wtf");
				}
			}

			//----------------MOVING LEFT----------------
			else if ((xTarget < bXCoord) && (yTarget == bYCoord))
			{
				for (int i = 1; i <= xMoveDist; i++)//check to see if all the tiles you'd have to cross are traversable
				{
					if (init_Floor.floor[(bXCoord - i), bYCoord].traversable)
					{
						validTiles++;
					}
				}

				if (validTiles == xMoveDist)//if they all are traversable
				{
					print("do move");//do move
					for (int i = 1; i <= xMoveDist; i++)
					{
						MoveSquare(direction.left);
						curMoves--;
					}
				}

				else if (validTiles < xMoveDist)//if one or more isn't traversable
				{
					//dont move
					print((xMoveDist - validTiles) + " not traversable");
				}

				else if (validTiles > xMoveDist)//if there's more traversable tiles than tiles (debugging)
				{
					print("error: xMoveDist = " + xMoveDist + ", validTiles = " + validTiles);
				}

				else//somehow something else (debugging)
				{
					print("wtf");
				}
			}

			//----------------MOVING UP----------------
			else if ((xTarget == bXCoord) && (yTarget > bYCoord))
			{
				for (int i = 1; i <= yMoveDist; i++)//check to see if all the tiles you'd have to cross are traversable
				{
					if (init_Floor.floor[bXCoord, (bYCoord + i)].traversable)
					{
						validTiles++;
					}
				}

				if (validTiles == yMoveDist)//if they all are traversable
				{
					print("do move");//do move
					for (int i = 1; i <= yMoveDist; i++)
					{
						MoveSquare(direction.up);
						curMoves--;
					}
				}

				else if (validTiles < yMoveDist)//if one or more isn't traversable
				{
					//dont move
					print((yMoveDist - validTiles) + " not traversable");
				}

				else if (validTiles > yMoveDist)//if there's more traversable tiles than tiles (debugging)
				{
					print("error: yMoveDist = " + yMoveDist + ", validTiles = " + validTiles);
				}

				else//somehow something else (debugging)
				{
					print("wtf");
				}
			}

			//----------------MOVING DOWN----------------
			else if ((xTarget == bXCoord) && (yTarget < bYCoord))
			{
				for (int i = 1; i <= yMoveDist; i++)//check to see if all the tiles you'd have to cross are traversable
				{
					if (init_Floor.floor[bXCoord, (bYCoord - i)].traversable)
					{
						validTiles++;
					}
				}

				if (validTiles == yMoveDist)//if they all are traversable
				{
					print("do move");//do move
					for (int i = 1; i <= yMoveDist; i++)
					{
						MoveSquare(direction.down);
						curMoves--;
					}
				}

				else if (validTiles < yMoveDist)//if one or more isn't traversable
				{
					//dont move
					print((yMoveDist - validTiles) + " not traversable");
				}

				else if (validTiles > yMoveDist)//if there's more traversable tiles than tiles (debugging)
				{
					print("error: yMoveDist = " + yMoveDist + ", validTiles = " + validTiles);
				}

				else//somehow something else (debugging)
				{
					print("wtf");
				}
			}

			//ZERO MOVEMENT (TRYING TO MOVE TO THE TILE YOU'RE ON) diagonal movement also?
			else
			{
				print("Move Cancelled");
				playerControls.actionMode = PlayerControls.ActionMode.none;

			}
		}

		else
		{
			print("Insufficient moves - " + "curMoves = " + curMoves + ", xMoveDist = " + xMoveDist + ", yMoveDist = " + yMoveDist);
			//do a nice ui thing for this later
		}
	}
}
