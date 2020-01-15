using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private Rigidbody2D BallRigid;
    public float kraft = 350.0f;
    //private float kraft2 = 350.0f;
    private Vector3 velocity;
    Vector2 direction;
    [SerializeField] 
    private Text lebenText;
    [SerializeField]
    private Text punkteText;
    private int punkte = 0;
    private int leben = 3;
    [SerializeField]
    private Text loseText;



    //  Rigidbody2D BallRigid;
    void Start()
    {
        //  BallRigid = Ball.GetComponent<Rigidbody2D>();
      
        direction = new Vector2(Random.Range(-10.0f, 10.0f), Random.Range(-10.0f, 10.0f));
        lebenText.text = "Leben: " + leben;
        punkteText.text = "Punkte: " + punkte;
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
            punkte++;
            punkteText.text = "Punkte: " + punkte;

        }
        else if (collision.gameObject.tag == "Figure")
            {
                print("Lebenverlust!");
                leben--;
                lebenText.text = "Leben: " + leben;

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
        if (punkte >= 0 && punkte <10)
            kraft = 400.0f;
        else if (punkte >= 10 && punkte < 20)
            kraft = 500.0f;
        else if (punkte >= 20 && punkte < 25)
            kraft = 700.0f;
        else if (punkte >= 25 && punkte < 35)
            kraft = 900.0f;
        else if (punkte >= 35 && punkte < 40)
            kraft = 1000.0f;
        else if (punkte >= 40 && punkte < 45)
            kraft = 1100.0f;
        else if (punkte >= 45 && punkte < 50)
            kraft = 1250.0f;
        else if (punkte >= 50)
            kraft = 2000.0f;

        /*
    if (kraft >= 0)
        kraft = 350.0f;
        */

        //add force in the direction the ball bounces or starts
        BallRigid.AddForce(direction * kraft);
        print(kraft);
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
        if (leben <=0)
        {
            StartCoroutine(EndGame());
          //  SceneManager.LoadScene(0);
        }
    }

    IEnumerator EndGame()
    {
        loseText.gameObject.SetActive(true);
        
     //   Time.timeScale = 0;
         
        yield return new WaitForSeconds(2.8f);

      //  Time.timeScale = 1;
        SceneManager.LoadScene(0);

    }
}
