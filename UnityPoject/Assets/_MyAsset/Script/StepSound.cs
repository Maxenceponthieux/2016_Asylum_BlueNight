using UnityEngine;
using System.Collections;

public class StepSound : MonoBehaviour {

     

    void Start()
    {
    }

	public void PetitPas()
    {
        AkSoundEngine.PostEvent("Play_Player_Footsteps", gameObject);



    }
}   
