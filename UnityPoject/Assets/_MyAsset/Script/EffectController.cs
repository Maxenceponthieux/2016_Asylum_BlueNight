using UnityEngine;
using System.Collections.Generic;
using DG.Tweening;
using com.ootii.Messages;

public class EffectController : MonoBehaviour
{
    public float maxDistance = 5f;
    public float duration = 2f;
    float distance;
    float width;
    Color color;
    public Gradient gradient;

    bool effectIsReady = true;

    public LayerMask mask;
    bool havefoundmonster;


    public bool monster = true;

    List<KeyValuePair<AI, float>> monsters = new List<KeyValuePair<AI, float>>();
    List<KeyValuePair<TextMenu, float>> textes = new List<KeyValuePair<TextMenu, float>>();

    // Use this for initialization
    void Start ()
    {
        distance = 0;
        width = 0;
        color = new Color(0,0,0,0);
    }
	
	// Update is called once per frame
	void Update ()
    {
	    if( (Input.GetKeyDown(KeyCode.Z) || Input.GetButtonDown("Fire3")) && effectIsReady == true)
        {
            havefoundmonster = false;

            DOTween.To(() => distance, x => distance = x, maxDistance, duration).OnComplete(OnEffectComplete);
            width = 1f;
            color = Color.red;
            Shader.SetGlobalVector("_PlayerPos",transform.position);
            effectIsReady = false;
            MessageDispatcher.SendMessage("OnPowerUse");

            Collider[] hitColliders = Physics.OverlapSphere(transform.position, maxDistance);
            for (int i = 0; i < hitColliders.Length;i++)
            {
                if (hitColliders[i].gameObject.tag == "Monster")
                {
                    if(monster)
                    {
                        AI monsterAi = hitColliders[i].gameObject.GetComponent<AI>();
                        float dist = Vector3.Distance(hitColliders[i].gameObject.transform.position, transform.position);
                        monsters.Add(new KeyValuePair<AI, float>(monsterAi, dist));
                    }
                    else
                    {
                        TextMenu monsterAi = hitColliders[i].gameObject.GetComponent<TextMenu>();
                        float dist = Vector3.Distance(hitColliders[i].gameObject.transform.position, transform.position);
                        textes.Add(new KeyValuePair<TextMenu, float>(monsterAi, dist));
                    }
                    
                }
            }

            if (monsters.Count != 0)
                havefoundmonster = true;
        }

        if(effectIsReady == false)
        {
            if(monster)
            {
                for (int i = 0; i < monsters.Count; i++)
                {
                    if (distance >= monsters[i].Value)
                    {
                        monsters[i].Key.Appear();
                        monsters.Remove(monsters[i]);
                    }
                }
            }
            else
            {
                for (int i = 0; i < textes.Count; i++)
                {
                    if (distance >= textes[i].Value)
                    {
                        textes[i].Key.Appear();
                        textes.Remove(textes[i]);
                    }
                }
            }
            
        }

        Shader.SetGlobalFloat("_Width", width);
        Shader.SetGlobalFloat("_MinDistance", distance);

        if(distance !=0)
        Shader.SetGlobalColor("_RainbowColor", gradient.Evaluate(distance/ maxDistance));
    }

    void OnEffectComplete()
    {
        if (havefoundmonster == false)
        {
            
        }

        effectIsReady = true;
        distance = 0;
    }

    void OnDestroy()
    {
        distance = 0;
        width = 0;
        color = new Color(0, 0, 0, 0);
        Shader.SetGlobalFloat("_Width", width);
        Shader.SetGlobalFloat("_MinDistance", distance);
        Shader.SetGlobalColor("_RainbowColor", color);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, maxDistance);
    }
}
