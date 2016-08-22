using UnityEngine;
using System.Collections;

public class AIControls : MonoBehaviour {

    GameController gameController;

    public BaseEnemy[] aiUnits;
    public int numAiUnits;//set value in scene

    void Awake()
    {
        aiUnits = new BaseEnemy[numAiUnits];
    }

    void Start()
    {
        gameController = this.gameObject.GetComponent<GameController>();
    }

    void Update()
    {
        if (gameController.gameplayHapen)
        {
            if (!gameController.playersTurn)
            {
                //do ya thing

                for(int i = 0; i <= (numAiUnits - 1); i++)
                {
                    switch(aiUnits[i].class_)
                    {
                        case BaseChar.classes.barbarian:
                            ((En_Barbarian)aiUnits[i]).doTurn();//apparently stuff in an array becomes the type of the array? so en_barbs become BaseEnemys and need to be casted back to en_barbs
                            break;
                        case BaseChar.classes.cleric:
                            //((En_Cleric)aiUnits[i]).doTurn();
                            break;
                        case BaseChar.classes.knight:
                            //((En_Knight)aiUnits[i]).doTurn();
                            break;
                        case BaseChar.classes.mage:
                            //((En_Mage)aiUnits[i]).doTurn();
                            break;
                        case BaseChar.classes.ranger:
                            //((En_Ranger)aiUnits[i]).doTurn();
                            break;
                        case BaseChar.classes.rogue:
                            //((En_Rogue)aiUnits[i]).doTurn();
                            break;
                        default:
                            print("how did you even manage this");
                            break;
                    }
                }

                gameController.playersTurn = true;
            }
            else
            {
                //do not
                //i dont think we need this 'else' block
            }
        }
    }

    /*public int timer;

    void FixedUpdate()
    {
        if(gameController.gameplayHapen)
        {
            if(!gameController.playersTurn)
            {
                if (timer > 0)
                {
                    timer--;
                }
                else
                {
                    gameController.playersTurn = true;
                }
            }
        }
    }*/
}
