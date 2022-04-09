#if UNITY_EDITOR
using System.IO;
using UnityEngine;
using UnityEditor;
using JackBuffer.Editor;

namespace ActSample.Protocol.EditorTool {

    public class ProtocolGenerateTool {

        [MenuItem("Tools/GenerateProtocol")]
        public static void Generate() {
            string inputDir = Path.Combine(Application.dataPath, "Scripts", "Protocols", "Runtime");
            JackBufferGenerator.GenModel(inputDir);
        }

    }

}
#endif