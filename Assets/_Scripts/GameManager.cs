using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public static GameManager Instance;
    public PlayerController Player;
    public DropGenerator Drop;
    public Text Timer;
    public Text TR_text;
    public Text EXP_text;
    public GameObject GAMEOVER_panel;



    public float timer;

    private int TR = 0;
    private int EXP = 0;


    public enum State
    {
        Ready,
        Play,
        GameOver
    }
    public State state;

    private void Awake()
    {
        Instance = this;
    }

    // Use this for initialization
    void Start () {
        timer = 0;
        state = State.Play;
        StartCoroutine("LevelUp");
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
                Player.isPlay = true;
                if (Player.IsDead()) GameOver();
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
                TR = TR + (int)timer;
                TR_text.text = "+ " + TR.ToString() +" TR";
                break;
            case "Exp":
                Debug.Log("Exp");
                EXP = EXP + (int)timer;
                EXP_text.text = "+ " + EXP.ToString() + " EXP";
                break;
        }
    }

    void GameOver()
    {
        Debug.Log("Game Over");
        Drop.gameObject.SetActive(false);
        state = State.GameOver;
        GameObject RewardPanel = GameObject.Find("Canvas/RewardPanel") as GameObject;
        RewardPanel.SetActive(false);
        GAMEOVER_panel.SetActive(true);
        GAMEOVER_panel.transform.Find("Panel/TR").gameObject.GetComponent<Text>().text = TR_text.text;
        GAMEOVER_panel.transform.Find("Panel/EXP").gameObject.GetComponent<Text>().text = EXP_text.text;
    }

    public void ReStart()
    {
        SceneManager.LoadScene("Game");
    }
    public string GetTimer()
    {
        return string.Format("{0:N0}", timer);
    }

}
