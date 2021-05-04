using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterSeconds : MonoBehaviour
{

    public float TimeInSeconds = 3f;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DestroyAfterXSeconds());
    }

    IEnumerator DestroyAfterXSeconds()
    {
        yield return new WaitForSeconds(TimeInSeconds);
        Destroy(gameObject);

    }

}
