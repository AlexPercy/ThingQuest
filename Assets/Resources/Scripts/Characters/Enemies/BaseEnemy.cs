using UnityEngine;
using System.Collections;

public class BaseEnemy : BaseChar {

    //public static Object prefab;

    /*public static BaseEnemy Create(races r, classes c, int m, float x, float y)
    {
        prefab = Resources.Load("Prefabs/Characters/Base Character");

        BaseEnemy character = (Instantiate(prefab, new Vector3(x, y), Quaternion.identity) as GameObject).GetComponent<BaseEnemy>();

        character.race = r;
        character.class_ = c;


        character.maxMoves = m;

        character.bXCoord = (int)(x / 3.2f);
        character.bYCoord = (int)(y / 3.2f);

        character.hostile = true;

        return character;
    }*/

    public void doTurn()
    {
        print("catastrophic failure :(");
    }
}
