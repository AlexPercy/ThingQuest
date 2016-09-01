using UnityEngine;
using System.Collections;

public class En_Barbarian : BaseEnemy {

    //new public static Object prefab;//use of 'new' ensures hiding//dont need to though

	public static En_Barbarian Create(races r, int x, int y)
    {
        prefab = Resources.Load("Prefabs/Characters/En_Barbarian");

        En_Barbarian character = (Instantiate(prefab, new Vector3(((float)x * coordConv), ((float)y * coordConv)), Quaternion.identity) as GameObject).GetComponent<En_Barbarian>();

		character.name_ = "Barbo";
        character.race = r;
        character.class_ = classes.barbarian;

        character.maxHealth  = 5;
        character.curHealth  = character.maxHealth;
        character.maxEnergy  = 3;
        character.curEnergy  = character.maxEnergy;

		character.maxActions = 2;
		character.curActions = character.maxActions;

        character.maxMoves   = 3;
        character.curMoves   = character.maxMoves;
        
        character.bXCoord = x;
        character.bYCoord = y;


        //character.hostile = true;//already set in BaseChar/BaseEnemy

        return character;//change Create's type from void to En_Barbarian
    }

    new public void doTurn()
    {
        print("great success");
    }

	public void En_Move(int xTarget, int yTarget)
	{

	}
}
