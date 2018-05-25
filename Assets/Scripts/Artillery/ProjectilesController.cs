using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProjectilesController : MonoBehaviour {
    private Text infoText;
	// Use this for initialization
	void Start () {
        infoText = GameObject.Find("Canvas/ScoreBoard").GetComponent<UnityEngine.UI.Text>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Vector3 wp = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
            Vector2 touchPos = new Vector2(wp.x, wp.y);
            if (gameObject.GetComponent<Collider2D>() == Physics2D.OverlapCircle(touchPos,Input.GetTouch(0).pressure))
            {
                DestroyObject(gameObject);
                Debug.Log("The pressure of the touch is: " + Input.GetTouch(0).pressure);
                Debug.Log("WORKS");
                infoText.text = (Convert.ToInt32(infoText.text) + 1).ToString();
            }
            else
            {
                Debug.Log("MISS");
            }
        }
    }
    //void OnMouseDown()
    //{
    //    infoText.text = (Convert.ToInt32(infoText.text) + 1).ToString();
    //    DestroyObject(this.gameObject);
    //}
}
