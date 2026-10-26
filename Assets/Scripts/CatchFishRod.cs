using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using TMPro;


public class CatchFishRod : MonoBehaviour
{
    public bool destroyNow = false;
    public bool success = false;
    public TMP_Text timerText;
    public TMP_Text resultText;
    static float catchRate = 0;
    [SerializeField] RectTransform fishTarget;
    [SerializeField] RectTransform targetArea;
    [SerializeField] ocean o;
    public GameObject plane;
    /*[SerializeField] Transform pointA;
    [SerializeField] Transform pointB;*/

    public float direction = 1f;
    public Transform[] pointArray;

    public float moveSpeed = 100;
    public Vector3 targetPos;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        plane = GameObject.Find("plane");
        o = plane.GetComponent<ocean>();
        targetPos = pointArray[Random.Range(0, 1)].position;
    }

    // Update is called once per frame
    void Update()
    {
        MoveFish();
        MoveTarget();
        FishCapture();
    }
    void MoveFish()
    {
        fishTarget.position = Vector3.MoveTowards(fishTarget.position, targetPos, moveSpeed * Time.deltaTime);

        if (Vector3.Distance(fishTarget.position, pointArray[0].position) < .1f)
        {
            targetPos = pointArray[1].position;
            direction = 1f;
        }
        else if (Vector3.Distance(fishTarget.position, pointArray[1].position) < .1f)
        {
            targetPos = pointArray[0].position;
            direction = 1f;
        }

        if (Vector3.Distance(fishTarget.position, pointArray[0].position) < .1f || Vector3.Distance(fishTarget.position, pointArray[1].position) < .1f)
        {
            StopCoroutine("ChangeTarget");
        }
        else
        {
            StartCoroutine("ChangeTarget");
        }
    }
    private IEnumerator ChangeTarget()
    {
        yield return new WaitForSeconds(Random.Range(.5f, 8f));
        targetPos = pointArray[Random.Range(0, 1)].position;
        //Debug.Log("CHANGE");
    }
    void MoveTarget()
    {
        if (Input.GetKey(KeyCode.W))
        {
            targetArea.localPosition += new Vector3(0,1,0);
        } 
        if (Input.GetKey(KeyCode.S))
        {
            targetArea.localPosition += new Vector3(0,-1,0);
        }
    }

    void FishCapture()
    {
        
        if (RectTransformUtility.RectangleContainsScreenPoint(targetArea, fishTarget.position, null))
        {
            catchRate += 5 * Time.deltaTime;
            
        }
        else
        {
            catchRate -=  2* Time.deltaTime; 
        }

        if (catchRate >= 25)
        {
            resultText.text = "Caught!";
            resultText.color = Color.green;
            targetPos = fishTarget.position;
            direction = 0f;
            success = true;
            catchRate = 0;
        }

        else if (catchRate <= -10)
        {
            resultText.text = "it got away!";
            resultText.color = Color.red;
            targetPos = fishTarget.position;
            direction = 0f;
            destroyNow = true;
            catchRate = 0;
        }

        string Seconds = (catchRate % 60).ToString("f2");
        timerText.text = Seconds;
        //Debug.Log(catchRate);
    }

    public void AddToFishCount()
    {
        if (success)
        {
            o.fishCount += o.fishYield;
        }
    }

}
