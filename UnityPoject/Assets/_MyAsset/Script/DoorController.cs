using UnityEngine;
using System.Collections;
using com.ootii.Messages;

public class DoorController : MonoBehaviour
{
    public GameObject tpPoint;
    bool isIn = false;
    public DoorController goTo;
    RoomBehaviour room;
    static bool canOpenDoor = true;

	// Use this for initialization
	void Awake ()
    {
        room = GetComponentInParent<RoomBehaviour>();
        canOpenDoor = true;
    }
	
    void OnDestroy()
    {
        MessageDispatcher.RemoveListener("ResetDoor", RenitOpenDoor);
    }

	// Update is called once per frame
	void Update ()
    {
        if (isIn && (Input.GetKeyDown(KeyCode.A) || Input.GetButtonDown("Fire1")) && canOpenDoor)
        {
            MessageDispatcher.AddListener("ResetDoor", RenitOpenDoor);
            canOpenDoor = false;
            BroadcastMessage("Validate");
            MessageDispatcher.SendMessage("BeginTransition");
            Invoke("TeleportPlayer",1.2f);
        }  
	}

    void RenitOpenDoor(IMessage mess)
    {
        canOpenDoor = true;
    }

    void TeleportPlayer()
    {
        if (goTo == null)
            return;

        GameObject.FindGameObjectWithTag("Player").transform.position = goTo.GetTpPoint();
        this.NotifyRoom();
        goTo.NotifyRoom();
        isIn = false;

    }

    public Vector3 GetTpPoint()
    {
        return tpPoint.transform.position;
    }

    public void NotifyRoom()
    {
        room.HandleState();
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

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        if(goTo != null)
        Gizmos.DrawLine(transform.position, goTo.transform.position);
    }
}
