using UnityEngine;
using System.Collections;

public class WwiseManager : MonoBehaviour {

	// SINGLETON ?
	public static WwiseManager Instance;

	public enum EventsEnum{
		play_amb_style_01,
		play_amb_style_02,
		play_amb_style_03,
		play_amb_style_04,
		play_amb_style_05,
		play_amb_style_06,
		stop_amb_all,
		play_girl_footsteps,
		play_girl_pickup,
		play_girl_research_fail,
		play_girl_research_launch,
		play_girl_research_win,
		play_monster_catch,
		play_monster_founded,
		play_sfx_close_door,
		play_sfx_open_door,
		play_sfx_ukulele,
		play_cinematic_begin,
		play_music_guitar,
		play_monster_chase,
		stop_monster_chase,
		stop_cinematic_begin,
		play_cinematic_end,
		play_sfx_unlock_door,
		play_amb_style_07,
		play_amb_style_08,
		play_amb_style_09,
		play_amb_style_10,
		stop_cinematic_end,
		stop_all,
		Switch_step01,
		Switch_step02,
		Switch_step03,
		Switch_step04,
		rtpc_step01,
		rtpc_step02,
		rtpc_step03,
		rtpc_step04,
		rtpc_step05
	}

	public enum SwitchEnum
	{
		step01,
		step02,
		step03,
		step04
	}

	// Use this for initialization
	void Awake () {
		Instance = this;
		uint bankID; // Not used
		AkSoundEngine.LoadBank ("AsylumJam2016Bank", AkSoundEngine.AK_DEFAULT_POOL_ID, out bankID);
	}

	// utiliser une enum pour appeler un event
	public void playWwiseEvent(EventsEnum eventToPlay)
	{
		AkSoundEngine.PostEvent (eventToPlay.ToString(),gameObject);
	}

	// utiliser un string pour appeler un event
	public void playWwiseEvent(string eventToPlay)
	{
		AkSoundEngine.PostEvent (eventToPlay,gameObject);
	}

	// change switch
	public void switchUkulele(SwitchEnum switchValue){
		AkSoundEngine.SetSwitch ("girl_step_ukulele",switchValue.ToString(),gameObject);
	}

	public void changeRtpcValueUkulele(float rtpcValue){
		AkSoundEngine.SetRTPCValue ("girl_step_ukulele",rtpcValue);
	}
}