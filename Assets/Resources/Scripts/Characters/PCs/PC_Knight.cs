﻿using UnityEngine;
using System.Collections;

public class PC_Knight : BasePC {

    public static PC_Knight Create(races r, int x, int y)
    {
        prefab = Resources.Load("Prefabs/Characters/PC_Knight");

        PC_Knight character = (Instantiate(prefab, new Vector3(((float)x * coordConv), ((float)y * coordConv)), Quaternion.identity) as GameObject).GetComponent<PC_Knight>();

		character.name_ = "Davion";
        character.race = r;
        character.class_ = classes.knight;

        character.maxHealth = 8;
        character.curHealth = character.maxHealth;
        character.maxEnergy = 3;
        character.curEnergy = character.maxEnergy;

		character.maxActions = 2;
		character.curActions = character.maxActions;

		character.maxMoves = 2;
        character.curMoves = character.maxMoves;
		character.canMove = true;

		//character.bXCoord = x;
		//character.bYCoord = y;
		character.RefreshCoords();

        character.controllable = true;

		return character;
    }

    

    
}
