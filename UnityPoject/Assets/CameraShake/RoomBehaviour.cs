using UnityEngine;
using System.Collections;
using com.ootii.Messages;

public class RoomBehaviour : MonoBehaviour
{
    public bool BeginRoom;

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
        gameObject.SetActive(true);
        
    }

    void PlayInstru(IMessage mess)
	{
    }

    void Desactivate()
    {
        MessageDispatcher.RemoveListener("OnPlayInstru", PlayInstru);
        gameObject.SetActive(false);
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
