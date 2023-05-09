using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int totalItemCount;
    public int stage;
    public Text stageCountText;
    public Text playerCountText;
    void Awake()
    {
        stageCountText.text = " / " + totalItemCount;
    }
     public void GetItem(int count)
    {
        //¾ÈµÇ³×
        //playerCountText.text = GetComponent<PlayerBall>().itemCount.ToString();
        playerCountText.text = count.ToString();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
            SceneManager.LoadScene(stage);

    }
}
