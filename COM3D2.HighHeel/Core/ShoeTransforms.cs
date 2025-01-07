// You cannot change the position of the object's body bones, so this is useless
// If you want to, just tBodySkin.obj_tr.
// var shoe = __instance.GetSlot((int)TBody.SlotID.shoes);
// shoe.obj_tr.localPosition = transforms.Position;









// using UnityEngine;
//
// namespace COM3D2.Highheel.Plugin.Core
// {
//     public class ShoeTransforms
//     {
//         public readonly Vector3 OriginalScale;
//         public readonly Transform ShoeL;
//         public readonly Transform ShoeR;
//         public Vector3 LocalScale = Vector3.zero;
//         public Vector3 Position = Vector3.zero;
//         public Vector3 Rotation = Vector3.zero;
//
//         public ShoeTransforms(TBodySkin skin)
//         {
//             if (skin == null || skin.obj_tr == null || skin.body == null)
//             {
//                 Plugin.Instance?.Logger?.LogError("Invalid TBodySkin or uninitialized obj_tr/body.");
//                 return;
//             }
//
//             ShoeL = CMT.SearchObjName(skin.obj_tr, "Bip01 L Foot", false);
//             ShoeR = CMT.SearchObjName(skin.obj_tr, "Bip01 R Foot", false);
//
//             if (!ShoeR || !ShoeL)
//             {
//                 Plugin.Instance.Logger.LogError("ShoeL or ShoeR is null in ShoeTransforms constructor.");
//                 return;
//             }
//
//             if (skin.body == null)
//             {
//                 Plugin.Instance.Logger.LogError("skin.body is null in ShoeTransforms constructor.");
//                 return;
//             }
//
//             OriginalScale = skin.body.GetBone("Bip01 L Foot").localScale; // one side should enough
//
//             if (Hooks.IsInvalidTransform(ShoeL) || Hooks.IsInvalidTransform(ShoeR))
//             {
//                 Plugin.Instance.Logger.LogWarning("One of the shoe transforms contains NaN or Infinity in ShoeTransforms constructor.");
//
//                 ShoeL.localPosition = Vector3.zero;
//                 ShoeL.localRotation = Quaternion.identity;
//                 ShoeL.localScale = Vector3.one;
//
//                 ShoeR.localPosition = Vector3.zero;
//                 ShoeR.localRotation = Quaternion.identity;
//                 ShoeR.localScale = Vector3.one;
//
//                 OriginalScale = Vector3.one;
//                 Position = Vector3.zero;
//                 Rotation = Vector3.zero;
//                 LocalScale = Vector3.zero;
//             }
//             else
//             {
//                 Position = ShoeL.localPosition; // one side should enough
//                 Rotation = ShoeL.localEulerAngles;
//                 LocalScale = ShoeL.localScale;
//             }
//         }
//     }
// }