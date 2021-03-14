using UnityEngine;
using System.Collections;
using com.ootii.Messages;

public class RoomBehaviour : MonoBehaviour
{
    public bool BeginRoom;
    public WwiseManager.EventsEnum toPlay;
	public WwiseManager.EventsEnum switchInstru;
	public WwiseManager.EventsEnum rtpcStep;

    /*[Range(0,100)]
    public float rtpcValue;*/

    void Start()
    {
        if (BeginRoom == false)
            Desactivate();
        else
            Activate();
    }


    void Activate()
    {
        MessageDispatcher.AddListener("OnPlayInstru", PlayInstru);
        WwiseManager.Instance.playWwiseEvent(toPlay);
        gameObject.SetActive(true);
        
    }

    void PlayInstru(IMessage mess)
	{
		WwiseManager.Instance.playWwiseEvent(switchInstru);
		WwiseManager.Instance.playWwiseEvent(rtpcStep);
        WwiseManager.Instance.playWwiseEvent(WwiseManager.EventsEnum.play_sfx_ukulele);
    }

    void Desactivate()
    {
        MessageDispatcher.RemoveListener("OnPlayInstru", PlayInstru);
        gameObject.SetActive(false);
        WwiseManager.Instance.playWwiseEvent(WwiseManager.EventsEnum.stop_amb_all);
    }

    public void HandleState()
    {
        if (gameObject.activeInHierarchy)
            Desactivate();
        else
            Activate();
    }

    void OnDestroy()
    {
        MessageDispatcher.RemoveListener("OnPlayInstru", PlayInstru);

    }
}
