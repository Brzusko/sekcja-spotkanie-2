using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public string playerName = "Nazwa";
    public Rigidbody2D rb;
    public float movementSpeed = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.UpArrow)) rb.velocity = (new Vector2(0, 1) * Time.deltaTime * movementSpeed);
        else if(Input.GetKey(KeyCode.DownArrow)) rb.velocity = (new Vector2(0, -1) * Time.deltaTime * movementSpeed);
        else rb.velocity = new Vector2(0, 0);
        
    }
}
