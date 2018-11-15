using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollower : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] Vector3 defaultDistance = new Vector3(0f, 2f, -10f);
    [SerializeField] float distanceDamp = 10f;
    [SerializeField] float rotationalDamp = 10f;

    Transform myTransform;


    void Awake()
    {
        myTransform = transform;
    }


        void LateUpdate()
        {
            if (!FindTarget())
            {
                return;
            }

            Vector3 toPos = target.position + (target.rotation * defaultDistance);
            Vector3 curPos = Vector3.Lerp(myTransform.position, toPos, distanceDamp * Time.deltaTime);
            myTransform.position = curPos;

            Quaternion toRot = Quaternion.LookRotation(target.position - myTransform.position, target.up);
            Quaternion curRot = Quaternion.Slerp(myTransform.rotation, toRot, rotationalDamp * Time.deltaTime);
            myTransform.rotation = curRot;

        }

    bool FindTarget()
    {
        if (target == null)
        {
            GameObject temp = GameObject.FindGameObjectWithTag("Player");
            if (temp != null)
            {
                target = temp.transform;
            }
        }

        if (target == null)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}
