using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sky : MonoBehaviour {

    float speed = 0.08f;

    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
        float ofsX = speed * Time.time;
        transform.GetComponent<SpriteRenderer>().material.mainTextureOffset = new Vector2(ofsX, 0);
    }
}
