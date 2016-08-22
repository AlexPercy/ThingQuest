using UnityEngine;
using System.Collections;

public class BaseChar : MonoBehaviour {

    public const float coordConv = 3.2f;

    public PlayerControls playerControls;
    
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

    public bool selectable = false;
    public bool hostile;// = true;
    public bool invincible = false;

    //public something vulnFear etc

    void Start()
    {
        playerControls = GameObject.Find("Level Controller").GetComponent<PlayerControls>();
    }

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))//if we're left clicking
        {
            if (playerControls.actionMode == PlayerControls.ActionMode.selecting)
            {
                playerControls.selected = this;//you can select both controllable and non-controllable units (so you can see unit descs or w/e)
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

	public void Move(int xTarget, int yTarget)
	{
		if(yTarget != bYCoord)
		{

		}

		if(xTarget != bXCoord)
		{

		}
	}
}
