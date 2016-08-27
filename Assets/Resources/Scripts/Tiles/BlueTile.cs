using UnityEngine;
using System.Collections;

public class BlueTile : BaseTile {

    public static Object prefab;

    public static BlueTile Create(int x, int y, bool w)
    {
        prefab = Resources.Load("Prefabs/Tiles/Blue Tile");

        BlueTile floorTile = (Instantiate(prefab, new Vector3(((float)x * coordConv), ((float)y * coordConv)), Quaternion.identity) as GameObject).GetComponent<BlueTile>();
        floorTile.transform.parent = GameObject.Find("Floor").transform;

        floorTile.type = "blue";
        floorTile.bXCoord = x;
        floorTile.bYCoord = y;
        floorTile.traversable = w;

        return floorTile;
    }
}
