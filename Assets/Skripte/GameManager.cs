using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private Rigidbody2D BallRigid;
    public float kraft = 350.0f;
    //private float kraft2 = 350.0f;
    private Vector3 velocity;
    Vector2 direction;


    //  Rigidbody2D BallRigid;
    void Start()
    {
        //  BallRigid = Ball.GetComponent<Rigidbody2D>();
      
        direction = new Vector2(Random.Range(-10.0f, 10.0f), Random.Range(-10.0f, 10.0f));
        choseDirection(direction);
      //  BallRigid.AddForce(transform.right * kraft);
       // BallRigid.AddForce(transform.up * kraft);
    }

    // Update is called once per frame
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        //ReflectProjectile(BallRigid, collision.contacts[0].normal);
        if (collision.gameObject.tag == "Rope")
        {
            print("PUNKT!");
        }
        BallRigid.velocity = Vector2.zero;
        Vector2 CollisionNormal = collision.contacts[0].normal;

        ReflectProjectile(BallRigid, collision.GetContact(0).normal);
        //print("LUL");
    }

    private void choseDirection(Vector2 inDirection)
    {
        direction = inDirection;

        //Normalize directional vector
        direction.Normalize();

        if (kraft >= 0)
            kraft = 350.0f;

        //add force in the direction the ball bounces or starts
        BallRigid.AddForce(direction * kraft);
    }

    private void ReflectProjectile(Rigidbody2D rb, Vector3 reflectVector)
    {
        direction = Vector3.Reflect(direction, reflectVector);
        choseDirection(direction);
        /*
        print("LUXD");
        velocity.Normalize();
        BallRigid.AddForce(velocity * kraft2);
        */
    }

    
    void Update()
    {

    }
}
