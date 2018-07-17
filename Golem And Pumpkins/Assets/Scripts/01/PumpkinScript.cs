using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PumpkinScript : MonoBehaviour {

	// Use this for initialization
	void Update () {
        if (transform.position.y < -5f)
            Destroy(gameObject);
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Golem")
        {
            Destroy(collision.gameObject);
            Time.timeScale = 0f;
        }
        
    }
}
