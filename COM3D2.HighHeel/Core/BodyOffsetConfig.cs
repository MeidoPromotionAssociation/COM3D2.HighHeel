namespace COM3D2.HighHeel.Core {
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class BodyOffsetConfig {
        public float DefaultBodyOffset { get; set; }
        public Dictionary<int, float> SceneSpecificOffsets { get; set; }

        public BodyOffsetConfig() {
            SceneSpecificOffsets = new Dictionary<int, float>();
            DefaultBodyOffset = 0.04f; // default
        }

        public float GetBodyOffsetForScene(int sceneIndex) {
            if (SceneSpecificOffsets.TryGetValue(sceneIndex, out float offset)) {
                return offset;
            }
            return DefaultBodyOffset;
        }
    }
}
