using UnityEngine;
using System.Collections;

public class menuDetail : MonoBehaviour {

    EMTransition trans;
    public Color col;

    void Awake()
    {
        trans = GetComponent<EMTransition>();
        Cursor.visible = false;
    }

	public void SetColor()
    {
        trans.SetColor(col);
        trans.onTransitionComplete.RemoveListener(SetColor);
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();
    }
	
}
