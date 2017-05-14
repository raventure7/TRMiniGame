using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamaManager : MonoBehaviour {
    public static GamaManager Instance;

    

    public Text Timer;
    public float timer;

    public int TR;
    public int EXP;


    public enum State
    {
        Ready,
        Play,
        GameOver
    }
    public State state;


    
    // Use this for initialization
    void Start () {
        timer = 0;
        state = State.Ready;
        StartCoroutine("LevelUp");
    }

    private void Awake()
    {
        Instance = this;
    }
    // Update is called once per frame
    void Update () {

        if (state != State.GameOver)
        {
            timer += Time.deltaTime;
            Timer.text = string.Format("{0:N0}", timer);

        }
    }
    private void LateUpdate()
    {
        switch (state)
        {
            case State.Ready:

                break;
            case State.Play:
                //Player.isPlay = true;
                //if (Player.IsDead()) GameOver();
                break;
        }
    }
    // 5초마다 난이도 상승.
    IEnumerator LevelUp()
    {
        while (state != State.GameOver)
        {
            yield return new WaitForSeconds(3.0f);
            if(DropGenerator.Instance.span >= 0.2f)
            {
                DropGenerator.Instance.span = DropGenerator.Instance.span - 0.05f;
                Debug.Log("Level Up : " + DropGenerator.Instance.span);
            }

        }
    }

    public void CollisionHandller(string type)
    {
        switch (type)
        {
            case "Coin":
                Debug.Log("Coin");
                break;
            case "Exp":
                break;
        }
    }
}
