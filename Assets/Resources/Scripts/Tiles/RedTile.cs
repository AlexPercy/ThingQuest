using UnityEngine;
using System.Collections;

public class RedTile : Tile {

    public static Object prefab;
        
    public static RedTile Create(int x, int y)
    {
        prefab = Resources.Load("Prefabs/Tiles/Red Tile");

        RedTile floorTile = (Instantiate(prefab, new Vector3(((float)x * coordConv), ((float)y * coordConv)), Quaternion.identity) as GameObject).GetComponent<RedTile>();
        floorTile.transform.parent = GameObject.Find("Floor").transform;

        floorTile.type = "red";
        floorTile.bXCoord = x;
        floorTile.bYCoord = y;
        floorTile.traversable = true;

        return floorTile;
    }
    
    //damage on walkover() { }

}
