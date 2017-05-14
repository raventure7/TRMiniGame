using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
    Rigidbody2D rigid2D;

    public Sprite ChangePlayer;
    float jumpForce = 700.0f;
    //float walkForce = 100.0f;
    //float maxWalkSpeed = 6.0f;
    int jumpCount = 0;

    float move;
    bool isDead = false;
    public enum State
    {
        Ready,
        Play,
        GameOver
    }
    public bool IsDead()
    {
        return isDead;

    }

    public float maxSpeed;
    [HideInInspector]
    public bool isFactingRight = true;
    [HideInInspector]
    public bool isJumping = false;
    [HideInInspector]
    public bool isGrounded = false;
    [HideInInspector]
    public bool isPlay = false;
    // Use this for initialization
    void Start () {
        
        this.rigid2D = this.GetComponent<Rigidbody2D>();
	}


    void FixedUpdate()
    {
        if (!isDead)
        {

            move = Input.GetAxis("Horizontal");


            this.GetComponent<Rigidbody2D>().velocity = new Vector2(move * maxSpeed, this.GetComponent<Rigidbody2D>().velocity.y);


            if ((move > 0.0f && isFactingRight == false) || (move < 0.0f && isFactingRight == true))
            {
                Flip();
            }
        }
    }// Update is called once per frame
    void Update () {
        
        // 점프 처리

        if (Input.GetKeyDown(KeyCode.LeftControl) && jumpCount < 2)
        {
            this.rigid2D.AddForce(transform.up * jumpForce);
            jumpCount = jumpCount + 1;

        }
        /*
        int key = 0;
        if (Input.GetKey(KeyCode.RightArrow) ) key = 1;
        if (Input.GetKey(KeyCode.LeftArrow) ) key = -1;

        // 플레이어 속도
        float speedx = Mathf.Abs(this.rigid2D.velocity.x);

        if(speedx < this.maxWalkSpeed)
        {
            this.rigid2D.AddForce(transform.right * key * this.walkForce);
        }
        if(key != 0)
        {
            transform.localScale = new Vector3(key, 1, 1);
        }
        */
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        switch (other.gameObject.tag)
        {
            case "Ground":
                jumpCount = 0;
                break;

            // 포션과 충돌 시
            case "Portion":
                if (isDead) return;
                isDead = true;

                this.GetComponent<SpriteRenderer>().sprite = ChangePlayer;
                transform.localScale = new Vector3(2, 2, 2);
                SoundManager.Instance.HitSound();
                break;
            // 코인과 충돌 시
            case "Coin":
                // 게임 매니져에게 코인과 충돌 알림.
                GameManager.Instance.CollisionHandller("Coin");
                SoundManager.Instance.ScoreSound();
                printRewardTXT("TR");

                break;
            case "Exp":
                // 게임 매니져에게 EXP와 충돌 알림.
                GameManager.Instance.CollisionHandller("Exp");
                SoundManager.Instance.ScoreSound();
                printRewardTXT("EXP");
                break;
        }
    }
    // 방향 전환
    void Flip()
    {
        isFactingRight = !isFactingRight;
        Vector3 playerScale = transform.localScale;
        playerScale.x = playerScale.x * -1;
        transform.localScale = playerScale;
    }

    void printRewardTXT(string Type)
    {
        GameObject Prefab_rewardTXT = Resources.Load("prefab/RewardTXT") as GameObject;
        GameObject rewardTXT = Instantiate(Prefab_rewardTXT) as GameObject;
        rewardTXT.GetComponent<Text>().text = "+ " + GameManager.Instance.GetTimer() + " "+Type;
        rewardTXT.transform.SetParent(GameObject.Find("Canvas").transform);
        var pos = Camera.main.WorldToScreenPoint(transform.position);
        rewardTXT.transform.position = pos;
    }
}
