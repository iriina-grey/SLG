using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{

    public GameObject buildPanel;
    public GameObject sciencePanel;

    bool buildFlag;
    bool scienceFlag;
    private void Awake()
    {
        scienceFlag = false;
        //sciencePanel.SetActive(false);
        buildFlag = false;
        //buildPanel.SetActive(false);

    }

    public void Click_ShutOrOpen_Science()
    {
        scienceFlag = !scienceFlag;
        sciencePanel.SetActive(scienceFlag);
    }
    public void Click_shut_Science()
    {
        scienceFlag = false;
        sciencePanel.SetActive(false);
    }
    public void Click_ShutOrOpen_Build()
    {
        buildFlag = !buildFlag;
        buildPanel.SetActive(buildFlag);
    }
    public void Click_shut_Build()
    {
        buildFlag = false;
        buildPanel.SetActive(false);
    }
}
