using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class PlantManager : Singleton<PlantManager>
{
    public GameObject plantUI;
    public Transform mainPlayer;
    [SerializeField] Button botton;
    [SerializeField] Text infoText;
    [SerializeField] Text message;
    [SerializeField] Image image;
    [SerializeField] Plant[] plants;
    [SerializeField] Sprite[] plantsImage;
    GameObject nowPlant;

    LayerMask LayerMask = 1 << 10;
    Vector3 offer = new Vector3(0f, 50f, 0f);
    bool allowToCatch = true;
     
    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
            GetPlant();
    }
    void GetPlant()
    {

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (!EventSystem.current.IsPointerOverGameObject())
        {
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, LayerMask))
            {
                nowPlant = hit.transform.gameObject;
                if ((hit.transform.position + offer) == mainPlayer.position)
                {
                    PlantUI(true, hit.transform.GetComponent<PlantData>());
                }
                else
                {
                    PlantUI(false, hit.transform.GetComponent<PlantData>());
                }
            }
        }
    }
    void PlantUI(bool isOnplant, PlantData data)
    {
        
        if (isOnplant && allowToCatch&&(data.caijiRound<=3))
        {
            botton.interactable = true;
        }
        else
        {
            botton.interactable = false;
        }
        plantUI.SetActive(true);
        image.sprite = plantsImage[data.type- 1];
        infoText.text = plants[data.type - 1].infoText;
        message.text = "食物：" + data.food + "\n" + "矿物：" + data.mineral + "\n" + "能源：" + data.energy + "\n";
        
    }
    
    public void Return_Click()
    {
        plantUI.SetActive(false);
    }
    public void Caiji_Click()
    {
        //改变Value
        allowToCatch = false;
        botton.interactable = false;

        float[] value= nowPlant.transform.GetComponent<PlantData>().GetValue();
        int round = nowPlant.transform.GetComponent<PlantData>().caijiRound;
        nowPlant.transform.GetComponent<PlantData>().caijiRound = round + 1;
        UIupdate.Instance.ValueReduceView(value[0], "food", 0);
        UIupdate.Instance.ValueReduceView(value[1], "energy", 1);
        UIupdate.Instance.ValueReduceView(value[2], "mineral", 2);

    }
    public void RoundEvent()
    {
        allowToCatch = true;
        botton.interactable = true;
    }
}
