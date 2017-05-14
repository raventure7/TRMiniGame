using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinInfo : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnCollisionEnter2D(Collision2D other)
    {
        switch (other.gameObject.tag)
        {
            case "Ground":
                Destroy(this.gameObject);
                break;
            case "Player":
                Destroy(this.gameObject);
                break;
        }


    }
}
