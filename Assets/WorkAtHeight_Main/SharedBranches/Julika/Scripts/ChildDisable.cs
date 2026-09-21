using Obi;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ChildDisable : MonoBehaviour
{
    public GameObject ColliderObj;
    public GameObject newParent;
    public Transform LanyardPos;
    public Transform LanyardPos2;
    public UnityEvent ColliderEvent;
    public UnityEvent TimeDelayEvent;
    public UnityEvent InteractionEnable;
    public bool OnOff;
    //public ObiParticleAttachment obi;
    // Start is called before the first frame update

    private void Start()
    {
        //obi.patarget = LanyardPos;

        //obi.target = LanyardPos;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == ColliderObj)
        {
            ColliderObj.transform.parent = newParent.transform;
            ColliderObj.transform.position = LanyardPos.position;
            ColliderObj.transform.rotation = LanyardPos.rotation;
            ColliderEvent.Invoke();
            StartCoroutine(TimeDel());


        }
    }

    public IEnumerator TimeDel()
    { if(OnOff)
        {
            yield return new WaitForSeconds(0.5f);
            TimeDelayEvent.Invoke();
            yield return new WaitForSeconds(2f);
            ColliderObj.transform.position = LanyardPos2.position;
            ColliderObj.transform.rotation = LanyardPos2.rotation;
            yield return new WaitForSeconds(2f);
            InteractionEnable.Invoke();
        }


    }
}
