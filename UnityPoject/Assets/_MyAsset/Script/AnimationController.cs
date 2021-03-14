using UnityEngine;
using System.Collections;
using com.ootii.Messages;

public class AnimationController : MonoBehaviour
{
    Rigidbody body;
    Animator ator;
	// Use this for initialization
	void Start ()
    {
        ator = GetComponent<Animator>();
        body = GetComponent<Rigidbody>();
        MessageDispatcher.AddListener("OnPowerUse", PowerUseAnimation);
	}
	
    void OnDestroy()
    {
        MessageDispatcher.RemoveListener("OnPowerUse", PowerUseAnimation);
    }

	// Update is called once per frame
	void Update ()
    {
        if (Vector3.Distance(body.velocity,Vector3.zero) < 0.2f)
            ator.SetBool("Moving", false);
        else
            ator.SetBool("Moving", true);
    }

    void PowerUseAnimation(IMessage mess)
    {
        ator.SetTrigger("Power");
    }
}
