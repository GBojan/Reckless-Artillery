using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Classes;
using Assets.Classes.Artillery;

public class ShootArrows : MonoBehaviour {
    public int HeightFrom, HeightTo;
    public int Speed;
    public GameObject arrowToShoot;
    bool projectileFired = false;
	// Use this for initialization
	void Start () {
        StartCoroutine(this.ShootArrow());
    }
	
	// Update is called once per frame
	void Update () {
     
	}
  
    IEnumerator ShootArrow()
    {
        while (true)
        {
            //Time between shooting arrows
            System.Random random = new System.Random();
            var seconds = random.Next(1, 4);
            Debug.Log("Seconds to trigger: "+seconds);
            yield return new WaitForSeconds(3);

            //Spawning an arrow
            Vector3 newVector = new Vector3(this.transform.position.x, this.transform.position.y);
            GameObject newArrow = Instantiate(arrowToShoot, newVector, this.transform.rotation);

            System.Random randomHeight = new System.Random();
            var height = random.Next(HeightFrom, HeightTo);
            Debug.Log("My arrow height: "+height);
            var gmobject = new Arrow(2, Speed, height, 2, newArrow);
            gmobject.ShootMe();
        }
    }

}
