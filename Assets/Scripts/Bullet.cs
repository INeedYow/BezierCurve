using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float duration = 1f;

    public float curveOffset = 10f;

    public Vector3 curvePoint;



    public void Launch(GameObject owner, GameObject target)
    {   
        if (owner == null || target == null)
        {
            return;
        }

        transform.position = owner.transform.position;

        SetCurvePoint(owner);

        StartCoroutine(BezierMove(owner.transform.position, target));
    }



    void SetCurvePoint(GameObject owner)
    {
        curvePoint = new Vector3(Random.Range(-curveOffset, curveOffset), Random.Range(-curveOffset, curveOffset), Random.Range(-curveOffset, curveOffset));
        curvePoint += owner.transform.position;
    }



    // 발사 중에 오너가 움직여도 이미 발사 중인 bullet은 원래 궤도 유지하도록 vector3로 받음
    // 발사 중에 타겟이 움직이면 따라가도록 target으로 받음
    IEnumerator BezierMove(Vector3 ownerPos, GameObject target)
    {   
        float t = 0f;
        float acc = 1 / duration;

        while (t < 1f)
        {   
            transform.position = BezierCurve.GetPoint(ownerPos, curvePoint, target.transform.position, t);

            t += Time.deltaTime * acc;
            yield return null;
        }
        
        transform.position = target.transform.position;

        Destroy(gameObject);
    }

}
