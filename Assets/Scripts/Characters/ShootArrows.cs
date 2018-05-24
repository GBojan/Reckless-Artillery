using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Classes;
using Assets.Classes.Artillery;

public class ShootArrows : MonoBehaviour {
    public int HeightFrom, HeightTo;
    public int Speed;
    public GameObject arrowToShoot;
    public bool projectileFired = false;
	// Use this for initialization
	void Start () {
        //StartCoroutine(this.ShootArrow());
    }
	
	// Update is called once per frame
	void Update () {
        if (projectileFired==false)
        {
            StartCoroutine("ShootArrow");
        }
    }
    IEnumerator ShootArrow()
    {
            projectileFired = true;
            //Time between shooting arrows
            System.Random random = new System.Random();
            var seconds = random.Next(3, 5);
           
            yield return new WaitForSeconds(seconds);

            //Spawning an arrow
            Vector3 newVector = new Vector3(this.transform.position.x, this.transform.position.y);
            GameObject newArrow = Instantiate(arrowToShoot, newVector, this.transform.rotation);

            System.Random randomHeight = new System.Random();
            var height = random.Next(HeightFrom, HeightTo);
            var gmobject = new Arrow(2, Speed, height, 2, newArrow);
            gmobject.ShootMe();
            projectileFired = false;
    }

}
