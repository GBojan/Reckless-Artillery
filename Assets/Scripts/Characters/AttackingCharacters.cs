using Assets.Classes.Artillery;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackingCharacters : MonoBehaviour {
    public int projectileSpeed;
    public int projectileHeightFrom;
    public int projectileHeightTo;
    public GameObject projectile;
    private ShootArrows shootArrows;
	// Use this for initialization
	void Start () {

        shootArrows = new ShootArrows()
        {
            arrowToShoot = projectile,
            HeightFrom = projectileHeightFrom,
            HeightTo = projectileHeightTo,
            Speed = 150,
            projectileFired = false
        };
	}
	
	// Update is called once per frame
	void Update () {
        if (shootArrows.projectileFired == false)
        {
            //Time between shooting arrows
            var seconds = Random.Range(2.0f, 5.0f);
            StartCoroutine(ShootArrow(seconds));
        }
    }
    void Movement()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector2.right * projectileSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector2.left * projectileSpeed * Time.deltaTime);
        }
    }
    void Shooting()
    {
        if (shootArrows.projectileFired == false)
        {
            Instantiate(projectile, gameObject.transform.position, gameObject.transform.rotation);
        }
    }
    IEnumerator ShootArrow(float seconds)
    {
        shootArrows.projectileFired = true;
    
        Debug.Log("Seconds to trigger: " + seconds);
        yield return new WaitForSeconds(seconds);
        print(gameObject.name);

        //Spawning an arrow
        Vector3 newVector = new Vector3(this.transform.position.x, this.transform.position.y);
        GameObject newArrow = Instantiate(shootArrows.arrowToShoot, newVector, this.transform.rotation);

        var height = Random.Range(shootArrows.HeightFrom, shootArrows.HeightTo);
        var gmobject = new Arrow(2, shootArrows.Speed, height, 2, newArrow);
        gmobject.ShootMe();
        shootArrows.projectileFired = false;
    }
}
