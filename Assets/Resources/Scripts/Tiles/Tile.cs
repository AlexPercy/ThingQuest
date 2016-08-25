﻿using UnityEngine;
using System.Collections;

public class Tile : MonoBehaviour
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
				if (playerControls.actionMode == PlayerControls.ActionMode.targeting)//if we're currently trying to target something
				{
					if (playerControls.targetingMode == PlayerControls.TargetingMode.move)//if we're targeting a move command
					{
						playerControls.moveTarget = this;
						//need to find a way to move this into basechar//the tile reference is passed to playercontrols, which can then pass it to the selected unit reference i guess?
					}

					else if (playerControls.targetingMode == PlayerControls.TargetingMode.aoe)//if we're targeting the centrepoint of an aoe
					{
						playerControls.aoeTarget = this;
					}
				}
			}
		}
    }

}