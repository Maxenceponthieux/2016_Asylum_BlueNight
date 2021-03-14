using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class cinematiqueSkip : MonoBehaviour {
    bool canSkip;
    Text texte;
    public MovieController movieCtrl;

	// Use this for initialization
	void Start ()
    {
        texte = GetComponent<Text>();
        texte.enabled = false;

        transform.DOScale(1.1f, 1).SetLoops(-1, LoopType.Yoyo);
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if(canSkip == false)
        {
            if (Input.anyKey)
            {
                canSkip = true;
                texte.enabled = true;
            }
                
        }
        else
        {
            if (Input.GetButtonDown("Fire1") || Input.GetKeyDown(KeyCode.A))
                movieCtrl.BeginChangeScene();
        }
	}
}
