using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

	// Use this for initialization
	void Start () {
        StartCoroutine("DisplayScore");
        //transform.GetComponent<GUIText>().material.color = new Vector4(10, 10, 10, 100);

    }
	
	// Update is called once per frame
	void Update () {
        Vector3 pos = transform.position;
        pos.y += 0.5f;
        transform.position = pos;
	}

    IEnumerator DisplayScore()
    {
        yield return new WaitForSeconds(0.1f);
        for(float a = 1; a >= 0; a -= 0.05f)
        {
            //transform.GetComponent<GUIText>().material.color = new Vector4(1, 1, 1, a);
            //transform.GetComponent<Text>().material.color = new Vector4(1, 1, 1, a);
            // 위 U.I가 모두 사라지는 버그가 있음 확인 필요.
            yield return new WaitForFixedUpdate();
            
        }
        Destroy(gameObject);
    }
}
