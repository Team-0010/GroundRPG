using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public GameObject targetPoint;
    public GameObject player;

    private void OnCollisionEnter2D(Collision2D other)
    {
        player = GameObject.FindGameObjectWithTag("Player");

        Debug.Log("포탈 진입");
        if (gameObject.name == "Forest_Portal") 
        {
            SceneManager.LoadScene("Forest_Scene");
            Debug.Log("숲으로 진입");
            player.transform.position = new Vector3(54.15627f, 4.434933f, 0.4971692f);
        }
        else if (gameObject.name == "Boss_Portal")
        {
            SceneManager.LoadScene("BossCave_Scene");
            Debug.Log("보스방 진입");
            player.transform.position = new Vector3(-5.502505f, -12.61161f, 0.4971692f);
        }
    }


}
