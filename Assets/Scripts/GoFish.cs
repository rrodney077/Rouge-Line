using UnityEngine;
using System.Collections;


public class GoFish : MonoBehaviour
{

    [SerializeField] Transform interactBox;
    [SerializeField] LayerMask fishingLayer;
    [SerializeField] GameObject CastingMinigame1;
    [SerializeField] CharacterController cc;
    [SerializeField] SpriteRenderer excalim;

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
            excalim.enabled = true;

            if (Input.GetKeyDown(KeyCode.Space) && canInteract)
            {
                Debug.Log("workin");
                Instantiate(CastingMinigame1, transform);
                canInteract = false;
                cc.enabled = false;
                
            }
        }
        else
        {
            excalim.enabled = false;
        }

        if(transform.GetComponentInChildren<PointerController>() && transform.GetComponentInChildren<PointerController>().destroyNow)
        {
            Destroy(transform.GetComponentInChildren<PointerController>().leader);
            StartCoroutine("InteractReset");
        }
    }
    
    private IEnumerator InteractReset()
    {
        yield return new WaitForSeconds(.5f);
        canInteract = true;
        cc.enabled = true;
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawCube(interactBox.position, interactBox.localScale);
        Gizmos.color = Color.blue;
    }
}

