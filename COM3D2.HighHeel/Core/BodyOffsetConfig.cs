using System;
using System.Collections.Generic;

namespace COM3D2.Highheel.Plugin.Core
{
    public class BodyOffsetConfig
    {
        private readonly object _lock = new();

        public BodyOffsetConfig()
        {
            PerSceneBodyOffsets = new Dictionary<string, float>();
            PerSceneManBodyOffsets = new Dictionary<string, float>();
            DefaultBodyOffset = 0.04f;  // Experience-based values
            DefaultManBodyOffset = 0f;
        }

        public float DefaultBodyOffset { get; set; }
        public float DefaultManBodyOffset { get; set; }
        public Dictionary<string, float> PerSceneBodyOffsets { get; private set; }
        public Dictionary<string, float> PerSceneManBodyOffsets { get; private set; }

        public float GetBodyOffsetForScene(string currentSceneName, bool isGlobal, ShoeConfig config)
        {
            try
            {
                // If in edit mode, use this value directly, since there is a GUI
                if (Plugin.Instance.EditMode)
                {
                    return config.BodyOffset;
                }

                if (isGlobal)
                {
                    lock (_lock)
                    {
                        if (PerSceneBodyOffsets != null && PerSceneBodyOffsets.TryGetValue(currentSceneName, out var offset))
                        {
                            return offset;
                        }
                        return DefaultBodyOffset;
                    }
                }
                else
                {
                    if (config == null)
                    {
                        Plugin.Instance.Logger.LogError("ShoesConfig is null. Returning default body offset.");
                        return DefaultBodyOffset;
                    }
                    lock (_lock)
                    {
                        if (config.PerSceneBodyOffset != null && config.PerSceneBodyOffset.TryGetValue(currentSceneName, out var offset))
                        {
                            return offset;
                        }

                        return config.BodyOffset;
                    }
                }
            }
            catch (Exception ex)
            {
                Plugin.Instance.Logger.LogError($"Error in GetBodyOffsetForScene: {ex.Message}");
                return DefaultBodyOffset; // Return a safe default value
            }
        }

        public float GetManBodyOffsetForScene(string currentSceneName, bool isGlobal)
        {
            try
            {
                // If in edit mode, use this value directly, since there is a GUI
                if (Plugin.Instance.EditMode)
                {
                    var maid0 = GameMain.Instance.CharacterMgr.GetMaid(0);
                    var config = Hooks.GetConfig(maid0.body0);
                    if (config != null)
                    {
                        return config.ManBodyOffset;
                    }
                }
                if (isGlobal)
                {
                    lock (_lock)
                    {
                        if (PerSceneManBodyOffsets != null &&
                            PerSceneManBodyOffsets.TryGetValue(currentSceneName, out var offset))
                            return offset;
                    }

                    return DefaultManBodyOffset;
                }
                else
                {
                    // I don't know if it's possible to know man is doing something to a maid, so instead we use the value from maid0's shoe configuration
                    var maid0 = GameMain.Instance.CharacterMgr.GetMaid(0);
                    var config = Hooks.GetConfig(maid0.body0);
                    if (config == null)
                    {
                        Plugin.Instance.Logger.LogError("ShoesConfig is null. Returning default body offset.");
                        return DefaultManBodyOffset;
                    }
                    lock (_lock)
                    {
                        if (config.PerSceneManBodyOffset != null && config.PerSceneManBodyOffset.TryGetValue(currentSceneName, out var offset))
                        {
                            return offset;
                        }

                        return config.ManBodyOffset;
                    }
                }
            }
            catch (Exception ex)
            {
               Plugin.Instance.Logger.LogError($"Error in GetManBodyOffsetForScene: {ex.Message}");
                return DefaultManBodyOffset; // Return a safe default value
            }
        }

        public void SetBodyOffsetForScene(string currentSceneName, float offset)
        {
            try
            {
                lock (_lock)
                {
                    PerSceneBodyOffsets ??= new Dictionary<string, float>();
                    PerSceneBodyOffsets[currentSceneName] = offset;
                }
            }
            catch (Exception ex)
            {
               Plugin.Instance.Logger.LogError($"Error in SetBodyOffsetForScene: {ex.Message}");
            }
        }

        public void SetManBodyOffsetForScene(string currentSceneName, float offset)
        {
            try
            {
                lock (_lock)
                {
                    PerSceneManBodyOffsets ??= new Dictionary<string, float>();
                    PerSceneManBodyOffsets[currentSceneName] = offset;
                }
            }
            catch (Exception ex)
            {
               Plugin.Instance.Logger.LogError($"Error in SetManBodyOffsetForScene: {ex.Message}");
            }
        }
    }
}