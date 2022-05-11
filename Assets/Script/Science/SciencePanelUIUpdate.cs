using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SciencePanelUIUpdate : Singleton<SciencePanelUIUpdate>
{ 
    public GameObject[] buildLine;
    public GameObject Panel;

    public Text pointText;
    bool openFlag;

    
    private void Start()
    {
        
        
    }
    public void BuildLineUpdate(int lineNum, float load)
    {
        Slider slider = buildLine[lineNum].transform.GetComponent<Slider>();
        float value = slider.value;
        slider.value = value + load;
    }
    public void BuildLineUpdate(int lineNum, string name,string infoText)
    {
        Text text = buildLine[lineNum].transform.Find("Text").GetComponent<Text>();
        Slider slider = buildLine[lineNum].GetComponent<Slider>();
        Transform image = slider.gameObject.transform.Find("Image");
        image.Find("Text").GetComponent<Text>().text = infoText;
        buildLine[lineNum].SetActive(true);
        
        text.text = name;

        //infotext;
        slider.value = 0;
    }
    public void BuildLine_Remove(int lineNum)
    {
        buildLine[lineNum].SetActive(false);
    }
    public void ViewPoint(float point)
    {
        pointText.text = "科技点：" + point;
    }
    
}
