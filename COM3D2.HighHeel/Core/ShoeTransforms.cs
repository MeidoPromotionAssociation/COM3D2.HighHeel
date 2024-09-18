using UnityEngine;

namespace COM3D2.HighHeel.Core
{
    public class ShoeTransforms
    {
        public readonly Transform ShoeL;
        public readonly Transform ShoeR;
        public readonly Vector3 OriginalScale;

        public Vector3 Position = Vector3.zero;
        public Vector3 Rotation = Vector3.zero;
        public Vector3 LocalScale = Vector3.zero;

        public ShoeTransforms(TBodySkin skin)
        {
            ShoeL = CMT.SearchObjName(skin.obj_tr, "Bip01LFoot", false);
            ShoeR = CMT.SearchObjName(skin.obj_tr, "Bip01RFoot", false);
            OriginalScale = skin.body.GetBone("Bip01LFoot").localScale;

            if (Hooks.IsInvalidTransform(ShoeL) || Hooks.IsInvalidTransform(ShoeR))
            {
                Plugin.Instance.Logger.LogWarning(
                    "One of the shoe transforms contains NaN or Infinity in ShoeTransforms constructor.");

                ShoeL.localPosition = Vector3.zero;
                ShoeL.localRotation = Quaternion.identity;
                ShoeL.localScale = Vector3.one;

                ShoeR.localPosition = Vector3.zero;
                ShoeR.localRotation = Quaternion.identity;
                ShoeR.localScale = Vector3.one;

                OriginalScale = Vector3.one;
                Position = Vector3.zero;
                Rotation = Vector3.zero;
                LocalScale = Vector3.zero;
            }
            else
            {
                Position = ShoeL.localPosition;
                Rotation = ShoeL.localEulerAngles;
                LocalScale = ShoeL.localScale;
            }
        }
    }
}