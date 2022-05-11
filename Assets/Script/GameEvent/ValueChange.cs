using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "ValueCHnang", menuName = "Data/GameEvent/ValueCHnangEvent")]
public class ValueChange : GameEventItem { 
    public int type;
    public bool isIncreat;
    public override void Event()
    {
        base.Event();
        GameDataValue dataValue = GameObject.Find("ValueOfGame").GetComponent<GameDataValue>();
        switch (type)
        {
            case 1:
                if (isIncreat)
                {
                    //infoText += "获得食物：" + Value;
                    UIupdate.Instance.ValueReduceView(Value, "food", type - 1);
                    
                }
                
                   
                
                else{//infoText += "获得食物：-" + Value;
                    UIupdate.Instance.ValueReduceView(-Value, "food", type - 1);
                    
                }

                    


                break;
            case 2:
                if (isIncreat)
                {//infoText += "获得能源：" + Value;
                    UIupdate.Instance.ValueReduceView(Value, "energy", type - 1);
                    
                }

                    

                else{//infoText += "获得能源：-" + Value;
                    UIupdate.Instance.ValueReduceView(-Value, "energy", type - 1);
                    
                }

                   
                break;
            case 3:
                if (isIncreat)
                {//infoText += "获得矿物：" + Value;

                    UIupdate.Instance.ValueReduceView(Value, "mineral", type - 1);
                    
                }


                else
                {//infoText += "获得矿物：-" + Value;
                    UIupdate.Instance.ValueReduceView(-Value, "mineral", type - 1);
                    
                }
                    
                
                break;
            case 4:
                if (isIncreat)
                {//infoText += "获得工业品：" + Value;
                    UIupdate.Instance.ValueReduceView(Value, "products", type - 1);
                    
                }
                    


                else
                {//infoText += "获得工业品：-" + Value;
                    UIupdate.Instance.ValueReduceView(-Value, "products", type - 1);
                    
                }
                   
                
                
                break;
            default:
                break;
        }
    }

}
