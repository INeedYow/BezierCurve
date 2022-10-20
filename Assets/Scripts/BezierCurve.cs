using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BezierCurve : MonoBehaviour
{
    public static Vector3 GetPoint(Vector3 a, Vector3 b, Vector3 c, Vector3 d, float t)
    {
        Vector3 ab = Vector3.Lerp(a,b,t);
        Vector3 bc = Vector3.Lerp(b,c,t);
        Vector3 cd = Vector3.Lerp(c,d,t);

        Vector3 abc = Vector3.Lerp(ab,bc,t);
        Vector3 bcd = Vector3.Lerp(bc,cd,t);

        Vector3 abcd = Vector3.Lerp(abc,bcd,t);

        return abcd;
    }


    public static Vector3 GetPoint(Vector3 a, Vector3 b, Vector3 c, float t)
    {
        Vector3 ab = Vector3.Lerp(a,b,t);
        Vector3 bc = Vector3.Lerp(b,c,t);

        Vector3 abc = Vector3.Lerp(ab,bc,t);

        return abc;
    }
}
