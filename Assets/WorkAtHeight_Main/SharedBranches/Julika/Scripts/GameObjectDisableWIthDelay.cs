using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectDisableWIthDelay : MonoBehaviour
{
    public GameObject Destroygameobject;
    public GameObject Enablegameobject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameObjectChange()
    {
        StartCoroutine(DisEnaGameObject());
    }

    public IEnumerator DisEnaGameObject()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(Destroygameobject);
        Enablegameobject.GetComponent<SpriteRenderer>().enabled = true;

    }
}
