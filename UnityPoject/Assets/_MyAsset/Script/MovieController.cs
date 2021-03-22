using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Threading;
using UnityEngine.Video;

public class MovieController : MonoBehaviour {

    public string sceneToGo;
    public EMTransition trans;
    public float SwitchAfter = 21f;
    public WwiseManager.EventsEnum eventToLaunch = WwiseManager.EventsEnum.play_cinematic_begin;

    public VideoPlayer videoPlayer;
    
	// Use this for initialization
	void Start ()
    {
        WwiseManager.Instance.playWwiseEvent(eventToLaunch);
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
        WwiseManager.Instance.playWwiseEvent(WwiseManager.EventsEnum.stop_all);
        SceneManager.LoadScene(sceneToGo);
    }
}
