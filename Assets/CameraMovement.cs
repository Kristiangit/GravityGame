using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
        if (target != null)
        {
            if (target.transform.position.x > 0)
            {
                transform.position = new Vector3(target.transform.position.x, transform.position.y, -10);
            }
        }

        Destroy(gameObject);
        timer = 0;
        Debug.Log("time0");
        if (timer <= 1){
            Debug.Log("time");
            timer += Time.deltaTime;
        } else {
            Debug.Log("instantiate");

            GameObject newObject = Instantiate(PlayerPrefab, startPoint.transform.position, Quaternion.identity);
            Debug.Log(newObject);
            GameObject.Find("Main Camera").GetComponent<CameraMovement>().SetNewTarget(newObject);

            timer = 0;
        }
        Debug.Log("test destroyed");
    }
    public void SetNewTarget(GameObject camTarget)
    {
        target = camTarget;
    }
} 
