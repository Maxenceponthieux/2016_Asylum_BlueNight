using UnityEngine;
using System.Collections;

public class StepSound : MonoBehaviour {

    void Start()
    {
        WwiseManager.Instance.playWwiseEvent(WwiseManager.EventsEnum.play_sfx_ukulele);
    }

	public void PetitPas()
    {
        WwiseManager.Instance.playWwiseEvent(WwiseManager.EventsEnum.play_girl_footsteps);
    }
}
