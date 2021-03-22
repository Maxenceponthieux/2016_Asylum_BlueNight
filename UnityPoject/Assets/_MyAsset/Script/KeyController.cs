using UnityEngine;
using System.Collections;
using DG.Tweening;

public class KeyController : MonoBehaviour {

    public enum key
    {
        blue,
        green,
        red
    }

    public key color;

	void OnTriggerEnter()
    {
        transform.DOScale(0, 1.5f).SetEase(Ease.InBack).OnComplete(NotifyPlayer) ;
        GetComponentInChildren<ParticleSystem>().transform.DOScale(0, 1.5f).SetEase(Ease.InBack).OnComplete(NotifyPlayer);
    }

    void NotifyPlayer()
    {
        KeyManager manager = GameObject.FindGameObjectWithTag("Player").GetComponent<KeyManager>();

        switch (color)
        {
            case key.blue:
                manager.blue = true;
                break;
            case key.green:
                manager.green = true;
                break;
            case key.red:
                manager.red = true;
                break;
            default:
                break;
        }

        Destroy(gameObject);
    }
}
