using UnityEngine;
using System.Collections;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class CursorControllerMenu : MonoBehaviour
{
    public Ease touse;
    Quaternion baseRotation;

    public bool Quit;
    public string scene;

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
        transform.Rotate(new Vector3(0, 2, 0));
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
        transform.DORotate(new Vector3(0, 180 * 4, 0), 0.5f, RotateMode.WorldAxisAdd);

        if (Quit)
            Application.Quit();
        else
            Invoke("LoadScene", 1f);
            

    }

    void LoadScene()
    {
        SceneManager.LoadScene(scene);
    }
}
