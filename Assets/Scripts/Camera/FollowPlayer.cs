using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class FollowPlayer : MonoBehaviour
{
    private float xRange = 20;
    private float yRange = 20;
    private bool insideBorderX = true;
    private bool insideBorderY = true;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        //follows player on the x axis
        if (insideBorderX)
        {
            transform.position = new Vector2(player.transform.position.x, transform.position.y);
        }
        //follows player on the y axis
        if (insideBorderY)
        {
            transform.position = new Vector2(transform.position.x, player.transform.position.y);
        }

        //stops camera if reaches the x border
        if (player.transform.position.x > xRange || player.transform.position.x < -xRange)
        {
            insideBorderX = false;
        }
        else
        {
            insideBorderX = true;
        }
        //stops camera if reaches the y border
        if (player.transform.position.y > yRange || player.transform.position.y < -yRange)
        {
            insideBorderY = false;
        }
        else
        {
            insideBorderY = true;
        }
    }
}
