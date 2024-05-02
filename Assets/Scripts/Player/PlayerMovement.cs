using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float speed = 7;
    public float hInput;
    public float vInput;
    public GameObject bullet;
    private Vector3 mousePosition;
    private Quaternion bulletRotation;
    private float offset = -90f;
    public GameObject crosshair;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        hInput = Input.GetAxis("Horizontal");
        vInput = Input.GetAxis("Vertical");

        transform.Translate(Vector2.up * vInput * speed * Time.deltaTime);
        transform.Translate(Vector2.right * hInput * speed * Time.deltaTime);

        Gun();
    }
    private void Gun()
    {
        
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 target = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
            Vector2 myPos = new Vector2(transform.position.x, transform.position.y);
            Vector2 direction = target - myPos;
            direction.Normalize();
            Quaternion rotation = Quaternion.Euler(0, 0, Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + -90f);
            GameObject projectile = (GameObject)Instantiate(bullet, myPos, rotation);
        }
    }
}
