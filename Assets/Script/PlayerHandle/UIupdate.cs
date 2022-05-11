using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIupdate : Singleton<UIupdate>
{
    public GameObject textPrefabe;
    public Transform canves;

    [SerializeField]Transform[] UIOfValue;
    GameDataValue Data;
    
    // Start is called before the first frame update
    new void  Awake()
    {
        Data =GameObject.Find("ValueOfGame").transform.GetComponent<GameDataValue>();
        
        
        
    }
    private void Start()
    {
        ValueView();
    }

    public void AfterPlayerMove()
    {
        float[] changes = Data.ChangBaseValue_All();
        ValueView(Data.GetBaseValue_All(),changes); //回合消耗
        
    }
    //更新Ui数值显示
    void ValueView()
    {
        int i = 0;
        float[] value = Data.GetBaseValue_All();
        foreach (Transform transform in UIOfValue)
        {
            transform.GetComponent<Text>().text = "" + value[i];
            i++;
        }
    }
    public void ValueView(float[] values,float[] changes)
    {
        int i = 0;
        float[] value = values;
        foreach (Transform transform in UIOfValue)
        {
            transform.GetComponent<Text>().text = "" + value[i];
            ValueView_TextAnim(transform, changes[i]);
            i++;
        }
    }
    //单项资源减少
    public void ValueReduceView(float value,string type,int t_type)
    {

        Data.BaSeValue_Reduce(value, type);
        ValueView();
        ValueView_TextAnim(UIOfValue[t_type], value);

    }

    //数值动画
    void ValueView_TextAnim(Transform target,float changeNum)
    {
        Text text = Instantiate(textPrefabe, target.position + new Vector3(0f, -40f, 0), Quaternion.identity,canves).GetComponent<Text>();
        if (changeNum >= 0)
            text.text = "+" + changeNum;
        else
            text.text = "" + changeNum;
    }
}
