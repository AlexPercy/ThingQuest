using UnityEngine;
using System.Collections;

public class init_enemies : MonoBehaviour {

    AIControls aiControls;

	void Start ()
    {
        aiControls = this.gameObject.GetComponent<AIControls>();

        aiControls.aiUnits[0] = En_Barbarian.Create(BaseChar.races.human, 2, 2);
        aiControls.aiUnits[1] = En_Barbarian.Create(BaseChar.races.human, 4, 2);

    }

}
