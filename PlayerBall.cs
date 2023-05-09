using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerBall : MonoBehaviour
{
    public float jumpPower;
    public int itemCount;
    Rigidbody rigid;
    public bool isJump;
    AudioSource auDio;
    public GameManager gameManager;
    void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        auDio = GetComponent<AudioSource>();
    }
    void Update()
    {

        if (Input.GetButtonDown("Jump") && !isJump)
        {
            rigid.AddForce(new Vector3(0, jumpPower, 0), ForceMode.Impulse);
            isJump = true;

        }
    }   
    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        rigid.AddForce(new Vector3(h,0,v), ForceMode.Impulse);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Floor")
            isJump = false;

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Item")
        {
            //플레이어의 변수를 가져와서 쓸수도있네
            itemCount++;
            gameManager.GetItem(itemCount);
            auDio.Play();
            other.gameObject.SetActive(false);

        }
        if (other.gameObject.tag == "Finish")
        {
            if(gameManager.totalItemCount == itemCount)
            {
                //GameClear
                if(gameManager.stage == 2)
                SceneManager.LoadScene(0);
                else 
                SceneManager.LoadScene("SampleScene" + (gameManager.stage + 1).ToString());
            }
            else
            {
                //ReStart
                SceneManager.LoadScene("SampleScene" + gameManager.stage.ToString());
            }

        }
    }
}
