using UnityEngine;
using System.Collections;
using DG.Tweening;

public class BlockController : MonoBehaviour
{
    public KeyController.key color;
    public DoorController toLock;
    public FinalDoor door;
    bool destroying = false;

    public bool fin;

    // Use this for initialization
    void Start ()
    {
        if (fin == false)
            toLock.enabled = false;
        else
            door.enabled = false;

        if(fin == false)
            toLock.GetComponentInChildren<CursorController>().enabled = false;
        else
            door.GetComponentInChildren<CursorControllerMenu>().enabled = false;
    }
	
    void Update()
    {
        if (destroying)
            return;

        if (fin == false)
            toLock.enabled = false;
        else
            door.enabled = false;
        if (fin == false)
            toLock.GetComponentInChildren<CursorController>().enabled = false;
        else
            door.GetComponentInChildren<CursorControllerMenu>().enabled = false;
    }


	void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag != "Player")
            return;



        switch (color)
        {
            case KeyController.key.blue:
                if (col.gameObject.GetComponent<KeyManager>().blue == true)
                    BeginDestroy();
                break;
            case KeyController.key.green:
                if (col.gameObject.GetComponent<KeyManager>().green == true)
                    BeginDestroy();
                break;
            case KeyController.key.red:
                if (col.gameObject.GetComponent<KeyManager>().red == true)
                    BeginDestroy();
                break;
            default:
                break;
        }
    }

    void BeginDestroy()
    {
        destroying = true;

        if (fin == false)
            toLock.enabled = true;
        else
            door.enabled = true;

        if (fin == false)
            toLock.GetComponentInChildren<CursorController>().enabled = true;
        else
            door.GetComponentInChildren<CursorControllerMenu>().enabled = true; 

        transform.DOScale(0, 1.2f).SetEase(Ease.InBack).OnComplete(DestroyGameObject);
    }

    void DestroyGameObject()
    {
        Destroy(gameObject);
    }
}
