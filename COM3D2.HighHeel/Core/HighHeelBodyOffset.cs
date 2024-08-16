using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

namespace COM3D2.HighHeel.Core
{
    public static class HighHeelBodyOffset
    {
        private static readonly Dictionary<TBody, float> BodyOffsets = new Dictionary<TBody, float>();

        public static float GetBodyOffset(TBody body)
        {
            if (body == null) return 0f;
            if (BodyOffsets.TryGetValue(body, out float offset))
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

        public static float GetSnityouOutScale(TBody body)
        {
            if (body == null) return 1f;
            if (BodyOffsets.TryGetValue(body, out float offset) && offset != 0)
            {
                // SnityouOutScale = Thigh_SCL_.Scale ** 0.9
                float thighDistance = Vector3.Distance(body.Thigh_L.position, body.Calf_L.position);

                if (thighDistance == 0)
                {
                    Plugin.Instance.Logger.LogWarning("thighDistance is zero in GetSnityouOutScale, returning default scale of 1.");
                    return 1f;
                }

                float scale = (float)Math.Pow(Math.Pow(body.bonemorph.SnityouOutScale, 1 / 0.9) * (1 + offset / 2 / thighDistance), 0.9);

                if (float.IsNaN(scale) || float.IsInfinity(scale))
                {
                    Plugin.Instance.Logger.LogWarning("Scale resulted in NaN or Infinity in GetSnityouOutScale, returning default scale of 1.");
                    return 1f;
                }

                return scale;
            }
            return body.bonemorph.SnityouOutScale;
        }




        public static void SetBodyOffset(TBody body, float offset)
        {
            if (body != null)
            {
                BodyOffsets[body] = offset;
            }
        }

        public static void Clean()
        {
            var keysToRemove = BodyOffsets.Keys.Where(key => key == null).ToList();
            foreach (var key in keysToRemove)
            {
                BodyOffsets.Remove(key);
            }
        }
    }
}