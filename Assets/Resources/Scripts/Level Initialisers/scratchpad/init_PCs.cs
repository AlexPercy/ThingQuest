using UnityEngine;
using System.Collections;

public class Init_PCs : MonoBehaviour {

	PlayerControls playerControls;

    void Start()
    {
		playerControls = gameObject.GetComponent<PlayerControls>();
		
        playerControls.playerUnits[0] = PC_Knight.Create(BaseChar.races.orc, 10, 10);

		/*for(int i = 1; i <= 5; i++)
		{
			playerControls.playerUnits[i] = new BasePC;
		}*/
    }

}