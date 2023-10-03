using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FlickScript : MonoBehaviour
{
    Vector2 touchPos;
    RaycastHit _hit;
    GameObject carObject = null;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        //Unity��ł̑���
        if (Input.GetMouseButtonDown(0))
        {
            //�N���b�N�����Ƃ���ɃI�u�W�F�N�g�����邩
            var _ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(_ray, out _hit))
            {
                if(_hit.collider != null && _hit.collider.gameObject.CompareTag("Car"))
                {
                    // ���������I�u�W�F�N�g�̃^�O��car�Ȃ�擾
                    carObject = _hit.collider.gameObject; 
                }
            }
            touchPos = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0) && carObject != null)
        {
            Rigidbody rb = carObject.GetComponent<Rigidbody>();

            //�X���C�v�̕������擾
            Vector2 releasePos = Input.mousePosition;
            Vector2 vec = releasePos - touchPos;

            //forward��vector2�ɕϊ�
            Vector2 fo;
            fo.x = carObject.transform.forward.x;
            fo.y = carObject.transform.forward.z;


            //forward�Ƃ̓��ς��O�ȏ�Ȃ�O�ɐi�߂�
            if (Vector2.Dot(vec, fo) > 0)
            {
                //rb.AddForce(hitObject.transform.forward * 10, ForceMode.Impulse);
                rb.velocity = carObject.transform.forward * 20;

            }
            else
            {
                //rb.AddForce(-hitObject.transform.forward * 10, ForceMode.Impulse);
                rb.velocity = -carObject.transform.forward * 20;
            }


            carObject = null;
        }
    }
}