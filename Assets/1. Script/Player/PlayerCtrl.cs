using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerCtrl : MonoBehaviour
{

    
    public float speed;
    
    public GameObject joyStick;
    public Settings settings_script;
    Animator anim;

    public bool isCantMove;

    private void Start()
    {
        anim = GetComponent<Animator>();
        Camera.main.transform.parent = transform; // ī�޶� ĳ������ �ڽ����� �ִ� �� 
        Camera.main.transform.localPosition = new Vector3(0, 0, -10);
    }
    private void Update()
    {
        if (isCantMove)
        {
            joyStick.SetActive(false);
        }
        else{
            Move();
        }
    }

    //ĳ���� ������ ����
    void Move()
    {
        if (settings_script.isJoyStick)
        {
            joyStick.SetActive(true);
        }
        else
        {
            joyStick.SetActive(false);
            // Ŭ���ߴ��� �Ǵ�
            if (!EventSystem.current.IsPointerOverGameObject() ) // ���� Ŭ���Ѱ� ui�� �ƴ϶��
            {
                if (Input.GetMouseButton(0))
                {
                    Vector3 dir = (Input.mousePosition - new Vector3(Screen.width * 0.5f, Screen.height * 0.5f)).normalized;
                    transform.position += dir * speed * Time.deltaTime;
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
                }
                else // Ŭ������ �ʴ´ٸ�
                {
                    anim.SetBool("isWalk", false);
                }
            }
        }
    }

}
