using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : MonoBehaviour
{
    public GameObject player;
    public GameObject arrowPrefab;

    GameObject arrow = null;

    int direction;
    float arrowSpeed = 20f;    

    IEnumerator CreateArrow()
    {
        // 0 : 위, 1 : 오른쪽, 2 : 아래, 3: 왼쪽
        yield return new WaitForSeconds(.4f);
        direction = player.GetComponent<PlayerMover>().direction;
        switch (direction)
        {
            case 0:
                arrow = Instantiate(arrowPrefab, new Vector3(player.transform.position.x, player.transform.position.y + 1f), Quaternion.identity);
                break;
            case 1:
                arrow = Instantiate(arrowPrefab, new Vector3(player.transform.position.x + 1f, player.transform.position.y - 0.3f), Quaternion.Euler(new Vector3(0, 0, -90)));
                break;
            case 2:
                arrow = Instantiate(arrowPrefab, new Vector2(player.transform.position.x, player.transform.position.y - 1.3f), Quaternion.Euler(new Vector3(0, 0, 180)));
                break;
            case 3:
                arrow = Instantiate(arrowPrefab, new Vector2(player.transform.position.x - 1f, player.transform.position.y - 0.3f), Quaternion.Euler(new Vector3(0, 0, 90))); ;
                break;

            default:
                break;
        }
    }   
    private void Update()
    {        
        if (Input.GetKeyDown("space"))
        {           
            StartCoroutine("CreateArrow");            
        }     

        if (null != arrow)
        {
            ArrowFire(direction);
        }
    }

    void ArrowFire(int _direction)
    {        
        switch (_direction)
        {
            case 0:
                arrow.transform.Translate(new Vector2(0, 1) * arrowSpeed * Time.deltaTime, Space.World);
                break;
            case 1:
                arrow.transform.Translate(new Vector2(1, 0) * arrowSpeed * Time.deltaTime, Space.World);
                break;
            case 2:
                arrow.transform.Translate(new Vector2(0, -1) * arrowSpeed * Time.deltaTime, Space.World);
                break;
            case 3:
                arrow.transform.Translate(new Vector2(-1, 0) * arrowSpeed * Time.deltaTime, Space.World);
                break;
            default:
                break;
        }
    }  
}
