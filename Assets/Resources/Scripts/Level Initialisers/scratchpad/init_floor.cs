using UnityEngine;
using System.Collections;

public class Init_Floor : MonoBehaviour {

    public enum colour { blank, red, blue };
    //public colour tileColour;
    public Tile[,] floor;
	public int floorXSize;
	public int floorYSize;

    void Awake ()
    {

        floor = new Tile[floorXSize, floorYSize];

        for (int j = 0; j < floorYSize; j++)
        {
            for (int i = 0; i < floorXSize; i++)
            {
                
                if (j % 3 == 0)//tileColour == colour.blank)
                {
                    floor[i,j] = BlankTile.Create(i, j);//does this work??? blanktile.create returns a BlankTile, not a Tile, but BlankTile extends Tile so??? its not throwing a shitfit at least // haha yo were getting back to our old friend that thing where arrays rek the types of the things in them i guess probably
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
