using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropGenerator : MonoBehaviour {
    public static DropGenerator Instance;

    public GameObject portionPrefab;
    public GameObject coin_TR_Prefab;
    public GameObject coin_EXP_Prefab;

    public float span = 1.0f;
    public float time = 0f;
    public float delta = 0;
    int portionCount;



    private void Awake()
    {
        Instance = this;
    }
	
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;
        this.delta += Time.deltaTime;
        
        // 포션 드랍
        if(this.delta > this.span)
        {
            this.delta  = 0;
            GameObject go = Instantiate(portionPrefab) as GameObject;
            int px = Random.Range(-6, 7);
            go.transform.position = new Vector3(px, 7, 0);
            go.GetComponent<Rigidbody2D>().gravityScale = Random.Range(0.1f, 1);
            portionCount = portionCount + 1;
        }
        // TR 드랍
        if (portionCount == 8)
        {
            portionCount = portionCount + 1;
            this.delta = 0;
            GameObject go = Instantiate(coin_TR_Prefab) as GameObject;
            int px = Random.Range(-6, 7);
            go.transform.position = new Vector3(px, 7, 0);
            go.GetComponent<Rigidbody2D>().gravityScale = Random.Range(0.3f, 0.7f);
            portionCount = 0;
        }
        // EXP 드랍
        if (portionCount == 4)
        {
            portionCount = portionCount + 1;
            this.delta = 0;
            GameObject go = Instantiate(coin_EXP_Prefab) as GameObject;
            int px = Random.Range(-6, 7);
            go.transform.position = new Vector3(px, 7, 0);
            go.GetComponent<Rigidbody2D>().gravityScale = Random.Range(0.1f, 0.5f);
        }
    }
}
