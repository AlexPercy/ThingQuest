using UnityEngine;
using System.Collections;

public class Init_PCs : MonoBehaviour {

    void Start()
    {

        PC_Knight.Create(BaseChar.races.orc, 10, 10);

    }

}