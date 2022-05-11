using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.EventMessenger;
using System;

public class EventController : Singleton<EventController>
{
    

    private new void Awake()
    {
        base.Awake();
        


        AddEventLisener();
    }
    private void Start()
    {
        
    }
    void AddEventLisener()
    {
        try
        {
            
            Messenger.AddListener("Move", MapInsController.Instance.AfterPlayerMove);     
            Messenger.AddListener("Move", UIupdate.Instance.AfterPlayerMove);
            Messenger.AddListener("Move", BuildingController.Instance.RoundEvent);           
            Messenger.AddListener("Move", ScienceEventController.Instance.RoundEvent);           
            Messenger.AddListener("Move", PlantManager.Instance.RoundEvent);
            Messenger.AddListener("Move", GameEventController.Instance.DoEvent);
            Messenger.AddListener("Move", PlayerIns.Instance.LoseGame);

        }
        catch 
        {
           
        }
        




    }
    public void RemoveEvent()
    {
        Messenger.RemoveListener("Move", MapInsController.Instance.AfterPlayerMove);
        Messenger.RemoveListener("Move", UIupdate.Instance.AfterPlayerMove);
        Messenger.RemoveListener("Move", BuildingController.Instance.RoundEvent);
        Messenger.RemoveListener("Move", ScienceEventController.Instance.RoundEvent);
        Messenger.RemoveListener("Move", PlantManager.Instance.RoundEvent);
        Messenger.RemoveListener("Move", GameEventController.Instance.DoEvent);
        Messenger.RemoveListener("Move", PlayerIns.Instance.LoseGame);

    }
    public void DoEvent()
    {
        
        Messenger.Broadcast("Move");
        
    }
}
