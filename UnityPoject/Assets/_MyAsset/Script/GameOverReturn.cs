using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameOverReturn : MonoBehaviour {
    public EMTransition trans;

	// Use this for initialization
	void Start () {
		Invoke ("loadNextScene", 7f);
	}

	public void loadNextScene()
	{
        if (trans == null)
            return;

        trans.onTransitionComplete.AddListener(ChangeScene);
        trans.Play();
       
	}

    void ChangeScene()
    {
        trans.onTransitionComplete.RemoveListener(ChangeScene);
        SceneManager.LoadScene("Menu");
    }
}
