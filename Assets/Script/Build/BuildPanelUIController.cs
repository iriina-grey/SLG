using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildPanelUIController : Singleton<BuildPanelUIController>
{
    [SerializeField] GameObject[] buildLine;
    [SerializeField] GameObject buildText;
    [SerializeField] GameObject buildMainPanel;
    [SerializeField] Text numText;


    private new void Awake()
    {
        
    }

    public void BuildLineUpdate(int lineNum,float load)
    {
        Slider slider = buildLine[lineNum].transform.Find("Slider").GetComponent<Slider>();
        slider.gameObject.SetActive(true);
        float value=slider.value;
        slider.value = value + load;
    }
    public void BuildLineUpdate(int lineNum,string name)
    {
        Text text = buildLine[lineNum].transform.Find("Slider").transform.Find("Text").GetComponent<Text>() ;
        Slider slider = buildLine[lineNum].transform.Find("Slider").GetComponent<Slider>();
        buildLine[lineNum].SetActive(true);
        buildLine[lineNum].transform.Find("Slider").gameObject.SetActive(true);
        text.text = name;
        slider.value = 0;
    }
    public void BuildLine_Remove(int lineNum)
    {
        buildLine[lineNum].transform.Find("Slider").gameObject.SetActive(false);
    }
    public void OnClick_Return()
    {
        buildMainPanel.SetActive(false);
    }
    public void BuildLine_On(int lineNum)
    {
        buildLine[lineNum].SetActive(true);
    }
     public void BuildInformation_Update()
    {

    }
    public void BuildNum_Update(int max,int all)
    {
        numText.text = all + "/" + max;
    }
}
