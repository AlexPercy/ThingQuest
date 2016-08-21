using UnityEngine;
using System.Collections;

public class init_PCs : MonoBehaviour {

    void Start()
    {

        PC_Knight.Create(BaseChar.races.orc, 0, 0);

    }

}