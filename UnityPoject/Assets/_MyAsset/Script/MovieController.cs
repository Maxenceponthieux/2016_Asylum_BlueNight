using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Threading;
using UnityEngine.Video;

public class MovieController : MonoBehaviour {

    public string sceneToGo;
    public EMTransition trans;
    public float SwitchAfter = 21f;

    public VideoPlayer videoPlayer;
    
	// Use this for initialization
	void Start ()
    {
        videoPlayer.Play();
        Invoke("BeginChangeScene", SwitchAfter);
    }

    public void BeginChangeScene()
    {
        trans.Play();
        trans.onTransitionComplete.AddListener(ChangeScene);
    }

    // Update is called once per frame
    void ChangeScene()
    {
        SceneManager.LoadScene(sceneToGo);
    }
}
