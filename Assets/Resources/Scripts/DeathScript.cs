using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DeathScript : MonoBehaviour
{
    private GameObject startPoint;
    public GameObject PlayerPrefab;
    public bool dying;
    public int deathCount = 0;
    
    // Start is called before the first frame update
    void Start()
    {   
        PlayerPrefab = Resources.Load("Prefabs/Player") as GameObject;
        GameObject.Find("Main Camera").GetComponent<CameraMovement>().SetNewTarget(gameObject);
        dying = false;
        gameObject.name = "Player";
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -5 && !dying){
            // PlayerDeath();
            StartCoroutine(DeathCoroutine());


        }
    }
    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Death") && !dying){


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
        dying = true;
        gameObject.GetComponent<Renderer>().enabled = false;
        gameObject.GetComponent<PlayerMovement>().rb.velocity = new Vector2(0f, 0f);
        gameObject.GetComponent<PlayerMovement>().enabled = false;
        deathCount += 1;
        yield return new WaitForSeconds(0.5f);
        GameObject newObject = Instantiate(PlayerPrefab, startPoint.transform.position, Quaternion.identity);
        GameObject.Find("Main Camera").GetComponent<CameraMovement>().SetNewTarget(newObject);
        Destroy(gameObject);

    }

}
