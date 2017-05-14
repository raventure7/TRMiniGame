using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortionInfo : MonoBehaviour {
    public Sprite crack;
    public GameObject hitEffect;
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
                this.GetComponent<SpriteRenderer>().sprite = crack;
                SoundManager.Instance.breakSound();
                Destroy(this.gameObject, 0.1f);
                break;
            case "Player":
                Destroy(this.gameObject);
                GameObject PlayerHit = (GameObject)Instantiate(hitEffect, gameObject.transform.position, Quaternion.identity);
                PlayerHit.transform.localScale = new Vector3(6, 6, 6);
                Destroy(PlayerHit, 1.0f);
                break;
        }

        
    }
}
