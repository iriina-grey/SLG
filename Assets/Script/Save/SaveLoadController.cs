using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.EventMessenger;
using UnityEngine.SceneManagement;
public class SaveLoadController : MonoBehaviour
{
    const string SAVE_NAME = "DataSave.sav";
    GameDataValue GameDataValue;
    private void Awake()
    {
        GameDataValue = GameObject.Find("ValueOfGame").GetComponent<GameDataValue>();
    }
    public void Save()
    {
        SaveData save = new SaveData();
        BuildingController.Instance.SaveData();
        MapInsController.Instance.SaveData();
        ScienceEventController.Instance.SaveData();
        PlayerIns.Instance.SaveData();
        save = GameDataValue.Save();
        SaveMachine.SaveByJson(SAVE_NAME, save);

    }
    public void Load()
    {
        
        SaveData save = SaveMachine.LoadFormJson<SaveData>(SAVE_NAME);
        EventController.Instance.RemoveEvent();
        GameDataValue.LoadSave(save);
        SceneManager.LoadScene(3);
    }
}
