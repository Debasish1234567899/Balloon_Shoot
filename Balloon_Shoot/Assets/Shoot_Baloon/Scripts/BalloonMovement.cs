
using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class BalloonMovement : MonoBehaviour
{
    public MovementType _movementType;
    float positionX;
    Vector2 SpawnPoint;
    public LayerMask BalloonLayer;
    [SerializeField] public GameObject ScorePop;

    AudioSource Balloon_Burst;

    // Score
    Text ScoreText;
    public static int ScoreNumbers;

    //Combo
    public int ComboCount;
    [SerializeField] public GameObject ComboText;
    

    //Health
    public static int HealthNumber = 3;
    Text HealthText;

    

    private void Start()
    {
        ScoreText = GameObject.Find("Scoring_Text (Legacy)").GetComponent<Text>();
        HealthText = GameObject.Find("Health_Number").GetComponent<Text>();
        if (ComboText != null)
        {
            Debug.Log("Combo-Text Foubd");
        }
        else
        {
            Debug.Log("Combo Text Not Found");
        }
        
        
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


    void RaycastEvent()
    {


        if (Input.GetMouseButtonDown(0))
        {

            Vector2 MousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(MousePosition, Vector2.up, 60f, BalloonLayer);
            //AudioSource burstSound = GameObject.Find("Balloon_Burst").GetComponent<AudioSource>();


            if (hit.collider != null)
            {
                Debug.Log("Balloon Tag hits");
                ComboCount++;
                GameObject Go = Instantiate(ComboText,Vector2.zero, Quaternion.identity);
                Destroy(Go,0.3f);
                Go.GetComponentInChildren<Text>().text = "X" + ComboCount;

                //burstSound.Play();
                //Debug.Log("RayCast2D Hits " + hit.collider.name);
                //StartCoroutine(ResetState());
                //ScoreNumbers++;

                //GameObject go = Instantiate(ScorePop, new Vector2(this.transform.position.x, this.transform.position.y), Quaternion.identity);
                //go.transform.position += new Vector3(0, 3) * Time.deltaTime * 3;
                //Destroy(go, 0.65f);

            }
            else 
            {
                

                ComboCount = 0;
            }
            //ScoreText.text = "Score: " + ScoreNumbers;
        }


    }
    private void OnMouseDown()
    {
        AudioSource burstSound = GameObject.Find("Balloon_Burst").GetComponent<AudioSource>();
        burstSound.Play();
        StartCoroutine(ResetState());
        ScoreNumbers++;

        GameObject go = Instantiate(ScorePop, new Vector2(this.transform.position.x, this.transform.position.y), Quaternion.identity);
        go.transform.position += new Vector3(0, 3) * Time.deltaTime * 3;
        Destroy(go, 0.65f);
        ScoreText.text = "Score: " + ScoreNumbers;
       
    }

    IEnumerator ResetState()
    {
        float positionX = Random.Range(-5, 5);
        SpawnPoint = new Vector2(positionX, -9.75f);
        GetComponent<Animator>().enabled = true;
        yield return new WaitForSeconds(0.44f);
        GetComponent<Animator>().enabled = false;
        this.transform.position = SpawnPoint;
        this.gameObject.SetActive(false);

    }

    void MoveStraight()
    {
        
        Vector3 movement = new Vector3(0, 1, 0)*1 *Time.deltaTime;
        transform.Translate(movement);
    }
    void MoveZigZag()
    {
        float ZigzagMovementX = Mathf.Sin(Time.time * 1) * 0.5f;
        Vector3 movement = new Vector3(ZigzagMovementX, 1, 0)*Time.deltaTime*5;
        transform.Translate(movement);
    }
    void MoveWavy()
    {
        float ZigzagMovementX = Mathf.Sin(Time.time * 1) * 0.7f;
        Vector3 movement = new Vector3(ZigzagMovementX, 1, 0)*Time.deltaTime*5;
        transform.Translate(movement);
    }
    void MoveSlow()
    {
        transform.Translate(Vector2.up*2*Time.deltaTime);
    }
    void MoveFast()
    {
        transform.Translate(Vector2.up * 5 * Time.deltaTime);
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
