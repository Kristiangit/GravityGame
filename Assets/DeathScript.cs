using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathScript : MonoBehaviour
{
    public GameObject startPoint;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -5){
            transform.position = startPoint.transform.position;
        }
    }
    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Death")){
            StartCoroutine(ExampleCoroutine());
            
        }
    }
    IEnumerator ExampleCoroutine()
    {
        yield return new WaitForSeconds(1);
        transform.position = startPoint.transform.position;
    }

}
