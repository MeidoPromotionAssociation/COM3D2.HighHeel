using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace COM3D2.Highheel.Plugin.Core
{
    public static class HighHeelBodyOffset
    {
        private static readonly Dictionary<TBody, float> BodyOffsets = new();

        public static float GetBodyOffset(TBody body)
        {
            if (body == null) return 0f;
            if (BodyOffsets.TryGetValue(body, out var offset))
            {
                if (float.IsNaN(offset) || float.IsInfinity(offset))
                {
                    Plugin.Instance.Logger.LogWarning("Detected NaN or Infinity in BodyOffset. Set to 0.");
                    return 0f;
                }

                return offset;
            }

            return 0f;
        }

        /// <summary>
        /// Get the SnityouOutScale value of the specified body, which is calculated based on the thigh distance and body offset
        /// Snityou is an official typo in BoneMorph_
        /// </summary>
        /// <param name="body">Body object to get the SnityouOutScale value</param>
        /// <returns>The calculated SnityouOutScale value. If an exception occurs during the calculation, the default value 1 is returned</returns>
        public static float GetSnityouOutScale(TBody body)
        {
            if (body == null) return 1f;
            if (BodyOffsets.TryGetValue(body, out var offset) && offset != 0)
            {
                // Calculate thigh distance
                // SnityouOutScale = Thigh_SCL_.Scale ** 0.9
                var thighDistance = Vector3.Distance(body.Thigh_L.position, body.Calf_L.position);

                if (thighDistance == 0)
                {
                    Plugin.Instance.Logger.LogWarning(
                        "thighDistance is zero in GetSnityouOutScale, returning default scale of 1.");
                    return 1f;
                }

                // Calculate the SnityouOutScale value according to the formula
                var scale =
                    (float)Math.Pow(
                        Math.Pow(body.bonemorph.SnityouOutScale, 1 / 0.9) * (1 + offset / 2 / thighDistance), 0.9);

                if (float.IsNaN(scale) || float.IsInfinity(scale))
                {
                    Plugin.Instance.Logger.LogWarning(
                        "Scale resulted in NaN or Infinity in GetSnityouOutScale, returning default scale of 1.");
                    return 1f;
                }

                return scale;
            }

            // If the offset of the specified body is not found, or the offset is 0, the original SnityouOutScale value of the body object is returned directly
            return body.bonemorph.SnityouOutScale;
        }


        public static void SetBodyOffset(TBody body, float offset)
        {
            if (body != null) BodyOffsets[body] = offset;
        }

        public static void Clean()
        {
            var keysToRemove = BodyOffsets.Keys.Where(key => key == null).ToList();
            foreach (var key in keysToRemove) BodyOffsets.Remove(key);
        }
    }
}