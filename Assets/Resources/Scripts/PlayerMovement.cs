using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    private float Move;
    public float jump;
    public bool isJumping;
    public bool GravAbility = false;
    public Rigidbody2D rb;
    public float maxTime = 2f;
    public float abilityTimer;
    public Slider timerSlider;
    // Start is called before the first frame update
    void Start()
    {
        timerSlider = (Slider)FindObjectOfType(typeof(Slider));
        rb = GetComponent<Rigidbody2D>();
        timerSlider.maxValue = maxTime;
        timerSlider.value = abilityTimer;
        abilityTimer = maxTime;
    }
 
    // Update is called once per frame
    void Update()
    {
        timerSlider.value = abilityTimer;

        Move = Input.GetAxis("Horizontal");

        rb.velocity = new Vector2(speed * Move, rb.velocity.y);

        if (Input.GetButtonDown("Jump") && isJumping == false){
            rb.AddForce(new Vector2(rb.velocity.x, jump));
        }
        if (Input.GetKeyDown("j")){
            if (GravAbility){
                rb.gravityScale = 1;
                GravAbility = false;
            } else if(abilityTimer > 0.5f) {
            GravAbility = true;
            rb.gravityScale = 0;
            }
        }
        if (GravAbility){
            if (abilityTimer > 0){
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.995f);
                abilityTimer -= Time.deltaTime;
            } else {
                rb.gravityScale = 1;
                GravAbility = false;
            }
        } else if (!GravAbility && abilityTimer < maxTime){
            abilityTimer += Time.deltaTime/2;
        } else if (abilityTimer >= maxTime)
        {
            abilityTimer = maxTime;
        }

    }
    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Ground")){
            isJumping = false;
        }
    }
    private void OnCollisionExit2D(Collision2D other) {
        if (other.gameObject.CompareTag("Ground")){
            isJumping = true;
        }
    }
}
