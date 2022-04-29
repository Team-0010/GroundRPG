using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : MonoBehaviour
{
    public GameObject player;
    public GameObject arrowPrefab;

    GameObject arrow = null;

    int direction;
    float arrowSpeed = 10f;

    IEnumerator CreateArrow(int _direction)
    {
        yield return new WaitForSeconds(.4f);
        switch (_direction)
        {
            case 0:
                arrow = Instantiate(arrowPrefab, new Vector2(player.transform.position.x, player.transform.position.y + 1f), Quaternion.identity);
                Debug.Log("위쪽에 화살 생성");
                break;
            case 1:
                arrow = Instantiate(arrowPrefab, new Vector2(player.transform.position.x + 1f, player.transform.position.y), Quaternion.identity);

                break;
            case 2:
                arrow = Instantiate(arrowPrefab, new Vector2(player.transform.position.x, player.transform.position.y - 1f), Quaternion.identity);
                break;
            case 3:
                arrow = Instantiate(arrowPrefab, new Vector2(player.transform.position.x - 1f, player.transform.position.y), Quaternion.identity);
                break;

            default:
                break;
        }
    }


    private void Update()
    { 

        // if ()
        // {            
        //     StartCoroutine("CreateArrow", direction);
        // }
        // 0 : 위, 1 : 오른쪽, 2 : 아래, 3: 왼쪽
        direction = player.GetComponent<PlayerMover>().direction;
        
        if (null != arrow)
        {
            ArrowFire();
        }
    }

    void ArrowFire()
    {
        //arrow.transform.Translate(new Vector2(hSpeed, vSpeed) * arrowSpeed * Time.deltaTime);

        arrow.transform.Translate(new Vector2(0, 1) * arrowSpeed * Time.deltaTime, Space.World);
    }
}
