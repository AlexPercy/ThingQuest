using UnityEngine;
using System.Collections;

public class AIControls : MonoBehaviour {

    GameController gameController;

    public BaseEnemy[] aiUnits;
    public int numAiUnits;

    void Awake()
    {
        //numAiUnits = 6;//default, testing value. comment out & set in the scene
        aiUnits = new BaseEnemy[numAiUnits];
    }

    void Start()
    {
        gameController = this.gameObject.GetComponent<GameController>();
    }

    /*public void doTurn()
    {

    }*/

    void Update()
    {
        if (gameController.gameplayHapen)
        {
            if (!gameController.playersTurn)
            {
                //do ya thing

                /*foreach (BaseEnemy unit in aiUnits)
                {
                    unit.doTurn();
                }*/

                for(int i = 0; i <= (numAiUnits - 1); i++)
                {
                    /*if(aiUnits[i].class_ == BaseChar.classes.barbarian)
                    {
                        ((En_Barbarian)aiUnits[i]).doTurn();
                    }*/

                    switch(aiUnits[i].class_)
                    {
                        case BaseChar.classes.barbarian:
                            ((En_Barbarian)aiUnits[i]).doTurn();
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
                            print("error");
                            break;
                    }
                }

                /*StartCoroutine(timer());
                print("mid-pause");
                StartCoroutine(timer());*/

                //gameController.playersTurn = true;
            }
            else
            {
                //do not
                //i dont think we need this 'else'
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
    
    /*IEnumerator timer()
    {
        System.Threading.Thread.Sleep(1000);
        yield return null;
    }*/
}
