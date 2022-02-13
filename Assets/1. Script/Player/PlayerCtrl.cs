using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{

    public float speed;
    public bool isJoyStick;
    public GameObject joyStick;
    Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
        Camera.main.transform.parent = transform; // 카메라를 캐릭터의 자식으로 넣는 것 
        Camera.main.transform.localPosition = new Vector3(0, 0, -10);
    }
    private void Update()
    {
        Move();
    }

    //캐릭터 움직임 관리
    void Move()
    {
        if (isJoyStick)
        {
            joyStick.SetActive(true);
        }
        else
        {
            joyStick.SetActive(false);
            // 클릭했는지 판단
            if (Input.GetMouseButton(0))
            {
                Vector3 dir = (Input.mousePosition - new Vector3(Screen.width * 0.5f, Screen.height * 0.5f)).normalized;
                transform.position += dir * speed * Time.deltaTime;
                anim.SetBool("isWalk", true);

                // 왼쪽으로 이동
                if(dir.x < 0)
                {
                    transform.localScale = new Vector3(-1, 1, 1);

                }
                // 오른쪽으로 이동
                else
                {
                    transform.localScale = new Vector3(1, 1, 1);
                }
            }
            else // 클릭하지 않는다면
            {
                anim.SetBool("isWalk", false);
            }
        }
    }

}
