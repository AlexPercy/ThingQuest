using UnityEngine;
using System.Collections;

public class init_floor : MonoBehaviour {

    public enum colour { blank, red, blue };
    //public colour tileColour;
    public Tile[,] floor;

    void Awake ()
    {

        floor = new Tile[9, 9];

        for (int j = 0; j < 9; j++)
        {
            for (int i = 0; i < 9; i++)
            {
                
                if (j % 3 == 0)//tileColour == colour.blank)
                {
                    floor[i,j] = BlankTile.Create(i, j);//does this work??? blanktile.create returns a BlankTile, not a Tile, but BlankTile extends Tile so??? its not throwing a shitfit at least
                }

                else if (j % 3 == 1)//tileColour == colour.red)
                {
                    RedTile.Create(i, j);
                }

                else if (j % 3 == 2)//tileColour == colour.blue)
                {
                    BlueTile.Create(i, j, true);
                }

            }
        }

    }
	
    

    // Update is called once per frame
    /*void Update () {
	
	}*/
}
