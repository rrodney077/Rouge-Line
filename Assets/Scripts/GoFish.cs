using UnityEngine;
using System.Collections;

public class GoFish : MonoBehaviour
{

    [SerializeField] Transform interactBox;
    [SerializeField] LayerMask fishingLayer;
    [SerializeField] GameObject CastingMinigame1;

    public bool canInteract = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Physics.OverlapBox(interactBox.position, interactBox.localScale, interactBox.rotation.normalized, fishingLayer, QueryTriggerInteraction.Ignore).Length !=0)
        {
            if (Input.GetKeyDown(KeyCode.Space) && canInteract)
            {
                Debug.Log("workin");
                Instantiate(CastingMinigame1, transform);
                canInteract = false;
                
            }
        }

        if(transform.GetComponentInChildren<PointerController>() && transform.GetComponentInChildren<PointerController>().destroyNow)
        {
            Destroy(transform.GetComponentInChildren<PointerController>().leader);
            StartCoroutine("InteractReset");
        }
    }
    
    private IEnumerator InteractReset()
    {
        yield return new WaitForSeconds(2);
        canInteract = true;
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawCube(interactBox.position, interactBox.localScale);
        Gizmos.color = Color.blue;
    }
}

