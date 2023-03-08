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
        PlayerPrefab = Resources.Load("Prefabs/Player") as GameObject;
        GameObject.Find("Main Camera").GetComponent<CameraMovement>().SetNewTarget(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -5){
            // PlayerDeath();
            StartCoroutine(DeathCoroutine());


        }
    }
    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Death")){


            StartCoroutine(DeathCoroutine());

            // PlayerDeath();
            
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
    }

    IEnumerator DeathCoroutine()
    {
        gameObject.GetComponent<Renderer>().enabled = false;
        yield return new WaitForSeconds(1);
        GameObject newObject = Instantiate(PlayerPrefab, startPoint.transform.position, Quaternion.identity);
        GameObject.Find("Main Camera").GetComponent<CameraMovement>().SetNewTarget(newObject);
        Destroy(gameObject);

    }

}
