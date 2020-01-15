using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    // Start is called before the first frame update
    private float canJump = 0f;
    private float canRope = 0f;
    [SerializeField]
    private Rigidbody2D RigidPlayer;
    float speed = 10.0f;
    float RopeDifference = 1.03f;
    float RopeLength = 0.732f;
    public Transform Rope;
    private Transform CurrentRope;
    private List<GameObject> currentRopes;
    void Start()
    {
        RigidPlayer.freezeRotation = true;
        currentRopes = new List<GameObject>();

    }

    // Update is called once per frame
    void Update()
    {
        /*
        float moveHorizontal = Input.GetAxis("Horizontal");
        Vector2 movement = new Vector2(moveHorizontal, 0);
        RigidPlayer.AddForce(movement * speed);
        RigidPlayer.velocity = new Vector2(0, 0);
        */
        this.transform.Translate(Input.GetAxis("Horizontal")/10, 0, 0);

        if (Input.GetKeyDown(KeyCode.Space) && Time.time > canJump)
        {

            RigidPlayer.AddForce(new Vector3(0, 6, 0), ForceMode2D.Impulse);
            canJump = Time.time + 1.95f;
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) && Time.time > canRope)
        {
            print("InsertPressed");
            Vector3 currentPosition = this.transform.position;
            currentPosition.y += RopeDifference;
            CurrentRope = Instantiate(Rope, currentPosition, Quaternion.identity);
            currentRopes.Add(CurrentRope.gameObject);
            StartCoroutine(ExpandRope());
            canRope = Time.time + 5.50f;
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            if (Time.timeScale == 0)
            {
                Time.timeScale = 1;
            }
            else
            {
                Time.timeScale = 0;
                RigidPlayer.velocity = Vector3.zero;
                RigidPlayer.angularVelocity = 0;
            }
        }
    }

    private IEnumerator ExpandRope()
    {
        for (int i = 0; i < 11; i++)
        {
            yield return new WaitForSeconds(0.4f);
            Vector3 currentPosition = CurrentRope.position;
            currentPosition.y += RopeLength;
            CurrentRope = Instantiate(Rope, currentPosition, Quaternion.identity);
            currentRopes.Add(CurrentRope.gameObject);

            /*
            CurrentRope.localScale += new Vector3(0, CurrentRope.localScale.y, 0);
            Vector3 currentPosition = CurrentRope.position;
            currentPosition.y -= CurrentRope.position.y;
            CurrentRope.position = currentPosition;
            print("lul");
            */

        }
        yield return new WaitForSeconds(0.6f);

        foreach (GameObject item in currentRopes)
        {
            Destroy(item);
        }

        
    }
}

// rope y 0,85