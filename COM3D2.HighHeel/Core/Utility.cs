using System;
using UnityEngine;

namespace COM3D2.Highheel.Plugin.Core
{
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

        //<summary>
        // Extract the configName part starting with "hhmod_" from the input string.
        // example "foo_hhmod_shoeA_bar" -> "shoeA"
        // </summary>
        public static string ExtractShoeConfigName(string input)
        {
            // Find the location of "hhmod_"
            int index = input.IndexOf("hhmod_", StringComparison.OrdinalIgnoreCase);
            if (index < 0)
            {
                return string.Empty;
            }

            // Take out the whole section after "hhmod_"
            // example "abc_hhmod_shoeA_xyz" -> rawName = "hhmod_shoeA_xyz"
            var rawName = input.Substring(index);

            // Find next delimiter
            int nextSeparator = rawName.IndexOfAny(new[] { '_', '.' }, "hhmod_".Length);
            if (nextSeparator < 0)
            {
                // If it is not found, it means there are no extra underscores/periods, so the whole thing is returned.
                return rawName;
            }
            else
            {
                // If found, stop at the delimiter.
                // example "hhmod_shoeA_xyz" -> "hhmod_shoeA" -> "shoeA"
                return rawName.Substring(0, nextSeparator).Substring("hhmod_".Length);
            }
        }
    }
}