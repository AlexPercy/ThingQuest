﻿using UnityEngine;
using System.Collections;

public class Init_Floor : MonoBehaviour {

    //public enum colour { blank, red, blue };
    //public colour tileColour;
    public BaseTile[,] floor;
	public int floorXSize;
	public int floorYSize;


    void Start ()
    {

        floor = new BaseTile[floorXSize, floorYSize];

        for (int j = 0; j < floorYSize; j++)
        {
            for (int i = 0; i < floorXSize; i++)
            {
                
                if (j % 3 == 0)//tileColour == colour.blank)
                {
                    floor[i,j] = BlankTile.Create(i, j);//does this work??? blanktile.create returns a BlankTile, not a BaseTile, but BlankTile extends BaseTile so??? its not throwing a shitfit at least // haha yo were getting back to our old friend that thing where arrays rek the types of the things in them i guess probably
                }

                else if (j % 3 == 1)//tileColour == colour.red)
                {
					floor[i, j] = RedTile.Create(i, j);
                }

                else if (j % 3 == 2)//tileColour == colour.blue)
                {
					floor[i, j] = BlueTile.Create(i, j, true);
                }

            }
		}

		NullTile.Create(-1, -1);
	}
	
    

    // Update is called once per frame
    /*void Update () {
	
	}*/
}
