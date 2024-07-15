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

            return BodyOffsets.TryGetValue(body, out float offset) ? offset : 0f;
        }

        public static float GetSnityouOutScale(TBody body)
        {
            if (body == null) return 1f;

            if (BodyOffsets.TryGetValue(body, out float offset) && offset != 0)
            {
                // SnityouOutScale = Thigh_SCL_.Scale ** 0.9
                float thighDistance = Vector3.Distance(body.Thigh_L.position, body.Calf_L.position);
                float scale = (float)Math.Pow(
                    Math.Pow(body.bonemorph.SnityouOutScale, 1 / 0.9) *
                    (1 + offset / 2 / thighDistance), 0.9);
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