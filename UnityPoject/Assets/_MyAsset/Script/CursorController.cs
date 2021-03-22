using UnityEngine;
using System.Collections;
using DG.Tweening;

public class CursorController : MonoBehaviour
{
    public Ease touse;
    Quaternion baseRotation;

    void Awake()
    {
        baseRotation = transform.rotation;
    }

    void OnEnable()
    {
        transform.localScale = Vector3.zero;
        transform.rotation = baseRotation;
    }

    public void Update()
    {
        transform.Rotate(new Vector3(0, 40, 0) * Time.deltaTime);
    }

    void Appear()
    {
        transform.DOScale(0.3f, 0.7f).SetEase(Ease.OutBack);
    }
	
    void Disappear()
    {
        transform.DOScale(0f, 0.7f).SetEase(Ease.InBack);
    }

    void Validate()
    {
        transform.DORotate(new Vector3( 0,180*4,0 ), 0.5f, RotateMode.WorldAxisAdd);
    }
}
