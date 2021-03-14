using UnityEngine;
using System.Collections;
using com.ootii.Messages;

public class FinalDoor : MonoBehaviour {

    bool isIn = false;



    // Update is called once per frame
    void Update()
    {
        if (isIn && (Input.GetKeyDown(KeyCode.A) || Input.GetButtonDown("Fire1")))
        {
           
            WwiseManager.Instance.playWwiseEvent(WwiseManager.EventsEnum.play_sfx_open_door);
            WwiseManager.Instance.playWwiseEvent(WwiseManager.EventsEnum.stop_monster_chase);
            BroadcastMessage("Validate");
            MessageDispatcher.SendMessage("BeginTransition");

        }
    }

    
    void OnTriggerEnter(Collider col)
    {
        if (!enabled)
            return;

        BroadcastMessage("Appear");
        isIn = true;
    }

    void OnTriggerExit(Collider col)
    {
        if (!enabled)
            return;

        BroadcastMessage("Disappear");
        isIn = false;
    }


}
