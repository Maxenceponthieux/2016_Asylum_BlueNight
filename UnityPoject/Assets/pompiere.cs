using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using DG.Tweening;

public class pompiere : MonoBehaviour
{
    Text texte;

	// Use this for initialization
	void Start () {
        texte = GetComponent<Text>();
        texte.transform.DOScale(1.1f, 1).SetLoops(-1, LoopType.Yoyo);
    }

    // Update is called once per frame
    void Update ()
    {
        if (Input.GetButtonDown("Fire1") || Input.GetKeyDown(KeyCode.A))
            texte.transform.parent.DOScale(0f, 0.8f).SetEase(Ease.InBack);
    }
}
