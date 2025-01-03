using System;
using System.Collections.Generic;


namespace COM3D2.Highheel.Plugin.Core
{
    public class BodyOffsetConfig
    {
        public float DefaultBodyOffset { get; set; }
        public float DefaultManBodyOffset { get; set; }
        public Dictionary<int, float> SceneSpecificOffsets { get; private set; }
        public Dictionary<int, float> SceneSpecificManOffsets { get; private set; }

        private readonly object _lock = new object();

        public BodyOffsetConfig()
        {
            SceneSpecificOffsets = new Dictionary<int, float>();
            SceneSpecificManOffsets = new Dictionary<int, float>();
            DefaultBodyOffset = 0.04f;
            DefaultManBodyOffset = 0f;
        }

        public float GetBodyOffsetForScene(int sceneIndex)
        {
            try
            {
                if (sceneIndex < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(sceneIndex), "Scene index cannot be negative.");
                }

                lock (_lock)
                {
                    if (SceneSpecificOffsets != null && SceneSpecificOffsets.TryGetValue(sceneIndex, out float offset))
                    {
                        return offset;
                    }
                }

                return DefaultBodyOffset;
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error in GetBodyOffsetForScene: {ex.Message}");
                return DefaultBodyOffset; // Return a safe default value
            }
        }

        public float GetManBodyOffsetForScene(int sceneIndex)
        {
            try
            {
                if (sceneIndex < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(sceneIndex), "Scene index cannot be negative.");
                }

                lock (_lock)
                {
                    if (SceneSpecificManOffsets != null &&
                        SceneSpecificManOffsets.TryGetValue(sceneIndex, out float offset))
                    {
                        return offset;
                    }
                }

                return DefaultManBodyOffset;
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error in GetManBodyOffsetForScene: {ex.Message}");
                return DefaultManBodyOffset; // Return a safe default value
            }
        }

        public void SetBodyOffsetForScene(int sceneIndex, float offset)
        {
            try
            {
                if (sceneIndex < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(sceneIndex), "Scene index cannot be negative.");
                }

                lock (_lock)
                {
                    SceneSpecificOffsets ??= new Dictionary<int, float>();
                    SceneSpecificOffsets[sceneIndex] = offset;
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error in SetBodyOffsetForScene: {ex.Message}");
            }
        }

        public void SetManBodyOffsetForScene(int sceneIndex, float offset)
        {
            try
            {
                if (sceneIndex < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(sceneIndex), "Scene index cannot be negative.");
                }

                lock (_lock)
                {
                    SceneSpecificManOffsets ??= new Dictionary<int, float>();
                    SceneSpecificManOffsets[sceneIndex] = offset;
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error in SetManBodyOffsetForScene: {ex.Message}");
            }
        }
    }
}