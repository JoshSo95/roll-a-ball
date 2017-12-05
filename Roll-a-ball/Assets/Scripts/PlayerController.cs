using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float Speed; //public variable shows up in the unity inspector 
    public Text countText;
    public Text winText;



    private Rigidbody rb;
    private int count;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winText.text = "";
    }


    //Update is called every frame rendered
    //FixedUpdate is called before physics calculation
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        //Vector3(x,y,z)
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);


        rb.AddForce(movement * Speed); //muliplied by public variable speed

    }


    //called when player collides with a trigger collider
    //(tags need to be added in unity)
     void OnTriggerEnter(Collider other)
    {
        //if the object tag is pick up
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            count++;
            SetCountText();
        }

    }

    //subroutine to set count text
    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= 8)
        {
            winText.text = "You Win!";
        }
    }

}
