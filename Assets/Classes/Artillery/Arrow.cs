using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Classes.Artillery
{
    public class Arrow
    {
        //Health shows us how many times we need to tap the object to destroy it 
        public int Health { get; set; }

        public float Speed { get; set; }

        public int Height { get; set; }

        public float Damage { get; set; }

        public GameObject GameObj { get; set; }

        public float lifeSpan { get; set; }

        public Arrow(int health,float speed, int height, float damage, GameObject gameObject)
        {
            Health = health;
            Speed = speed;
            Height = height;
            Damage = damage;
            GameObj = gameObject;
            lifeSpan = 3f;
        }

        public void ShootMe()
        {
            //Adding rotation
            var objectRigidBody = GameObj.GetComponent<Rigidbody2D>();
            Vector2 vector = objectRigidBody.velocity;
            float angle = Mathf.Atan2(vector.y, vector.x) * Mathf.Rad2Deg;
            objectRigidBody.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

            //Adding speed
            objectRigidBody.AddForce(Vector2.right * Speed);
            objectRigidBody.AddForce(Vector2.up * Height);
        }
    }
}
