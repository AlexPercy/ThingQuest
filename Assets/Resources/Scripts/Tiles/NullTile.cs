using UnityEngine;
using System.Collections;

public class NullTile : BaseTile {

    public static Object prefab;

    
    public static void Create (int x, int y)//used for instantiating with parameters
    {
        prefab = Resources.Load("Prefabs/Tiles/Null Tile");

        NullTile floorTile = (Instantiate(prefab, new Vector3(((float)x * coordConv), ((float)y * coordConv)), Quaternion.identity) as GameObject).GetComponent<NullTile>();
        //floorTile.transform.parent = GameObject.Find("Floor").transform;//why doesnt this work
        

        floorTile.type = "null_";//???
        floorTile.bXCoord = x;
        floorTile.bYCoord = y;
        floorTile.traversable = false;

        //return floorTile;
	}
}
