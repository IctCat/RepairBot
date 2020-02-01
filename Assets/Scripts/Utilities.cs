using System;
using UnityEngine;

public static class UtilityExtensions
{
    public static Vector2Int ToVector2Int(this Vector3 v)
    {
        return new Vector2Int(
            Mathf.RoundToInt(v.x),
            Mathf.RoundToInt(v.z));
    }

    public static Vector3 ToVector3(this Vector2Int v, float height = 0f)
    {
        return new Vector3(v.x, height, v.y);
    }

    public static Vector3 ToVector3(this Vector2 v, float height = 0f)
    {
        return new Vector3(v.x, height, v.y);
    }

    public static Vector2 ToVector2(this Vector3 v)
    {
        return new Vector2(v.x, v.z);
    }

    public static float GetAngle(this Vector2 v)
    {
        return Mathf.Atan2(v.y, v.x) * Mathf.Rad2Deg;
    }

    public static T Last<T>(this T[] arr)
    {
        return arr[arr.Length - 1];
    }

    public static void SetEulerY(this Transform t, float f)
    {
        t.rotation = Quaternion.Euler(0f, f, 0f);
    }
}
