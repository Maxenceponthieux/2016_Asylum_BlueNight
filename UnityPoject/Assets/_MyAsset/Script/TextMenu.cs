using UnityEngine;
using System.Collections;
using DG.Tweening;

public class TextMenu : MonoBehaviour {


    public Renderer rend;
    public Color col = new Color(1,1,1,0);

    public void Update()
    {
        rend.material.SetColor("_Color", col);
    }

    public void Appear()
    {
        CancelInvoke();

        DOTween.To(() => col.a, x => col.a = x, 1, 2);
        Invoke("Disappear", 3f);
    }

    public void Disappear()
    {
        DOTween.To(() => col.a, x => col.a = x, 0, 2);
    }
}
