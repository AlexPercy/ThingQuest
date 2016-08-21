using UnityEngine;
using System.Collections;

public class BlankTile : Tile {

    public static Object prefab;

    
    public static BlankTile Create (int x, int y)//used for instantiating with parameters
    {
        prefab = Resources.Load("Prefabs/Tiles/Blank Tile");

        BlankTile floorTile = (Instantiate(prefab, new Vector3(((float)x * coordConv), ((float)y * coordConv)), Quaternion.identity) as GameObject).GetComponent<BlankTile>();
        floorTile.transform.parent = GameObject.Find("Floor").transform;
        

        floorTile.type = "blank";
        floorTile.bXCoord = x;
        floorTile.bYCoord = y;
        floorTile.walkable = true;

        return floorTile;
	}
    
    

}
