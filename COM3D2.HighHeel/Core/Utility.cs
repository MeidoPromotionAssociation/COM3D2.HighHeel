using UnityEngine;

namespace COM3D2.Highheel.Plugin.Core;

public static class Utility
{
    /// <summary>
    ///     Clamps the given angle to be between the specified minimum and maximum angles.
    /// </summary>
    public static float ClampAngle(float angle, float min, float max)
    {
        var normalizedMin = Normalize180(min - angle);
        var normalizedMax = Normalize180(max - angle);

        if (normalizedMin <= 0f && normalizedMax >= 0f) return angle;

        return Mathf.Abs(normalizedMin) < Mathf.Abs(normalizedMax) ? min : max;
    }

    /// <summary>
    ///     Checks if the given angle is between the specified minimum and maximum angles.
    /// </summary>
    /// <param name="angle">The angle to check. </param>
    /// <param name="min">The minimum value of the angle. </param>
    /// <param name="max">The maximum value of the angle. </param>
    /// <returns>Returns true if the angle is within the specified range, otherwise returns false. </returns>
    public static bool BetweenAngles(float angle, float min, float max)
    {
        return Normalize180(min - angle) <= 0f && Normalize180(max - angle) >= 0f;
    }

    /// <summary>
    ///     Normalizes the given angle to the range -180 to 180 degrees.
    /// </summary>
    public static float Normalize180(float angle)
    {
        angle %= 360f;
        angle = (angle + 360f) % 360f;
        if (angle > 180f) angle -= 360f;

        return angle;
    }
}