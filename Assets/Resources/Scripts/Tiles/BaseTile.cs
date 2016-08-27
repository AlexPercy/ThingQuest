using UnityEngine;
using System.Collections;

public class BaseTile : MonoBehaviour
{

    public const float coordConv = 3.2f;

    public PlayerControls playerControls;

    public string type;

    public int bXCoord;
    public int bYCoord;

    public bool traversable;

    void Start()
    {
        playerControls = GameObject.Find("Level Controller").GetComponent<PlayerControls>();
    }

    void OnMouseOver()//if the mouse is hover over this tile
    {
        if(traversable)
		{
			if (Input.GetMouseButtonDown(0))//if we're left clicking
			{
				if (playerControls.actionMode == PlayerControls.ActionMode.targeting_move)//if we're currently trying to target something
				{
					playerControls.moveTarget = this;
					//need to find a way to move this into basechar//the tile reference is passed to playercontrols, which can then pass it to the selected unit reference i guess?
				}

				else if (playerControls.actionMode == PlayerControls.ActionMode.targeting_aoe)//if we're targeting the centrepoint of an aoe
				{
					playerControls.aoeTarget = this;
				}
			}
		}
    }

}