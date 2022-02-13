using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// 1. ��ƽ �巡�� + ����
// 2. �巡���� ��ŭ ĳ���� �̵�
public class JoyStick : MonoBehaviour
{
    public RectTransform stick ,backGround;

    PlayerCtrl playerCtrl_script;
    Animator anim;

    bool isDrag;
    float limit;
    private void Start()
    {
        playerCtrl_script = GetComponent<PlayerCtrl>();
        limit = backGround.rect.width * 0.5f;
        anim = GetComponent<Animator>();

    }

    private void Update()
    {

        // �巡�� �ϴ� ����
        if(isDrag)
        {
            Vector2 vec = Input.mousePosition - backGround.position;
            stick.localPosition = Vector2.ClampMagnitude(vec, limit); // vector2�� ������ �����ϴ� ���

            Vector3 dir = (stick.position - backGround.position).normalized;
            transform.position += dir * playerCtrl_script.speed * Time.deltaTime;

            anim.SetBool("isWalk", true);

            // �������� �̵�
            if (dir.x < 0)
            {
                transform.localScale = new Vector3(-1, 1, 1);

            }
            // ���������� �̵�
            else
            {
                transform.localScale = new Vector3(1, 1, 1);
            }


            // �巡�װ�������
            if (Input.GetMouseButtonUp(0))
            {
                stick.localPosition = new Vector3(0, 0, 0);
                isDrag = false;
                anim.SetBool("isWalk", false);
            }
            
        }
    }

    //��ƽ�� ������ Ȩ��
    public void ClickStick()
    {
        isDrag = true;
    }
}
