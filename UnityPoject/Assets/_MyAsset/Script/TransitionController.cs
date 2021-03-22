using UnityEngine;
using System.Collections;
using com.ootii.Messages;

public class TransitionController : MonoBehaviour {

    EMTransition trans;

    // Use this for initialization
    void Start ()
    {
        trans = GetComponent<EMTransition>();
        MessageDispatcher.AddListener("BeginTransition", TransitionIn);
	}
	
    void OnDestroy()
    {
        MessageDispatcher.RemoveListener("BeginTransition", TransitionIn);
    }

    void TransitionIn(IMessage mess)
    {
        trans.Play();
        trans.onTransitionComplete.AddListener(TransitionInOut);
    }

    public void TransitionInOut()
    {
        StartCoroutine(Wait());
        
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.15f);
        trans.Play();
        trans.onTransitionComplete.RemoveListener(TransitionInOut);
        trans.onTransitionComplete.AddListener(ResetDoor);
        MessageDispatcher.SendMessage("OnPlayInstru");
    }

    void ResetDoor()
    {
        MessageDispatcher.SendMessage("ResetDoor");
        trans.onTransitionComplete.RemoveListener(ResetDoor);
    }
}

    
