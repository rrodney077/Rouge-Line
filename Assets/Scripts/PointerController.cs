    using UnityEngine;

public class PointerController : MonoBehaviour
{
    public bool destroyNow = false;
    public bool success = false;
    public GameObject leader;
    [SerializeField] RectTransform SafeZone;
    [SerializeField] Transform pointA;
    [SerializeField] Transform pointB;

    public float moveSpeed = 200f;

    public float direction = 1f;
    RectTransform pointerTranform;
    Vector3 targetPos;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pointerTranform = GetComponent<RectTransform>();
        targetPos = pointB.position;
    }

    // Update is called once per frame
    void Update()
    {
        pointerTranform.position = Vector3.MoveTowards(pointerTranform.position, targetPos, moveSpeed * Time.deltaTime );

        if (Vector3.Distance(pointerTranform.position, pointA.position) < .1f)
        {
            targetPos = pointB.position;
            direction = 1f;
        }
        else if (Vector3.Distance(pointerTranform.position, pointB.position) < .1f)
        {
            targetPos = pointA.position;
            direction = 1f;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            CheckSuccess();

            targetPos = pointerTranform.position;
            direction = 0f;
        }
    }


    void CheckSuccess()
    {
        if (RectTransformUtility.RectangleContainsScreenPoint(SafeZone, pointerTranform.position, null))
        {
            Debug.Log("success");
            success = true;
        }
        else
        {
            Debug.Log("fail");
            destroyNow = true;
            // gameObject.transform.parent.GetComponentInParent<GoFish>().canInteract = true;
            
        }
    }
}
