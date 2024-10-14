
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BalloonMovement : MonoBehaviour
{
    public MovementType _movementType;
    float positionX;
    Vector2 SpawnPoint;
    public LayerMask BalloonLayer;

    AudioSource Balloon_Burst;

    // Score
    Text ScoreText;
    static int ScoreNumbers;

    //Health
    public static int HealthNumber = 3;
    Text HealthText;

    

    private void Start()
    {
        ScoreText = GameObject.Find("Scoring_Text (Legacy)").GetComponent<Text>();
        HealthText = GameObject.Find("Health_Number").GetComponent<Text>();
    }
    void SetMovement(MovementType movementType)
    {
        _movementType = movementType;
        switch(movementType)
        {
            case MovementType.Straight:
                MoveStraight();
                break;  
            case MovementType.Wavy:
                MoveWavy();
                break;
            case MovementType.Fast:
                MoveFast();
                break;
            case MovementType.Slow:
                MoveSlow();
                break;
            case MovementType.Zigzag:
                MoveZigZag();
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            Debug.Log("Triggererd");
            
            HealthNumber--;
            HealthText.text = "" + HealthNumber;

        }
    }
    void GameOver()
    {

    }

    void RaycastEvent()
    {


        if (Input.GetMouseButtonDown(0))
        {

            Vector2 MousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(MousePosition, Vector2.up, 60f, BalloonLayer);
            Debug.Log("RayCast Enters");
            Debug.DrawRay(MousePosition, Vector2.up * 0.01f, Color.red, 1f);
            if (hit.collider != null)
            {
                Debug.Log("RayCast2D Hits " + hit.collider.name);
                StartCoroutine(ResetState());
                ScoreNumbers++;

            }
            ScoreText.text = "Score: " + ScoreNumbers;
        }


    }

    IEnumerator ResetState()
    {
        float positionX = Random.Range(-5, 5);
        SpawnPoint = new Vector2(positionX, -9.75f);
        GetComponent<Animator>().enabled = true;
        yield return new WaitForSeconds(0.5f);
        GetComponent<Animator>().enabled = false;
        this.transform.position = SpawnPoint;
        this.gameObject.SetActive(false);

    }

    void MoveStraight()
    {
        
        Vector3 movement = new Vector3(0, 1, 0)*3 *Time.deltaTime;
        transform.Translate(movement);
    }
    void MoveZigZag()
    {
        float ZigzagMovementX = Mathf.Sin(Time.time * 3) * 0.5f;
        Vector3 movement = new Vector3(ZigzagMovementX, 1, 0)*Time.deltaTime*5;
        transform.Translate(movement);
    }
    void MoveWavy()
    {
        float ZigzagMovementX = Mathf.Sin(Time.time * 2) * 0.7f;
        Vector3 movement = new Vector3(ZigzagMovementX, 1, 0)*Time.deltaTime*5;
        transform.Translate(movement);
    }
    void MoveSlow()
    {
        transform.Translate(Vector2.up*6*Time.deltaTime);
    }
    void MoveFast()
    {
        transform.Translate(Vector2.up * 12 * Time.deltaTime);
    }

    
    void Update()
    {
        SetMovement(_movementType);
        RaycastEvent();
    }
}
public enum MovementType
{
    Straight,
    Wavy,
    Zigzag,
    Slow,
    Fast
}
