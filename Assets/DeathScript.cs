using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DeathScript : MonoBehaviour
{
    private GameObject startPoint;
    public GameObject PlayerPrefab;
    
    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("Main Camera").GetComponent<CameraMovement>().SetNewTarget(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -5){
            PlayerDeath();
        }
    }
    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Death")){

            PlayerDeath();
            
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Respawn"))
        {
            startPoint = other.gameObject;
        }
    }

    void PlayerDeath(){

        Destroy(gameObject);

        StartCoroutine(ExampleCoroutine());
    }

    IEnumerator ExampleCoroutine()
    {
        yield return new WaitForSeconds(1);
        Instantiate(PlayerPrefab, startPoint.transform.position, Quaternion.identity);
    }

}
