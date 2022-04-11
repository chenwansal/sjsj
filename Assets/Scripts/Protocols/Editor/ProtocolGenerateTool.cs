#if UNITY_EDITOR
using System;
using System.IO;
using System.Reflection;
using UnityEngine;
using UnityEditor;
using JackBuffer;
using JackBuffer.Editor;
using JackAST;
using JackFrame;

namespace ActSample.Protocol.EditorTool {

    public class ProtocolGenerateTool {

        [MenuItem("Tools/GenerateProtocol")]
        public static void Generate() {

            string protocolDir = Path.Combine(Application.dataPath, "Scripts", "Protocols");
            GenerateMessage(protocolDir);
            GenerateService(protocolDir);

        }

        static void GenerateMessage(string protocolDir) {
            string inputDir = Path.Combine(protocolDir, "Runtime", "Messages");
            JackBufferGenerator.GenModel(inputDir);
        }

        static void GenerateService(string protocolDir) {

            // TODO ServiceID filter by different direction

            string serviceFile = Path.Combine(protocolDir, "Runtime", "ProtocolService.cs");
            string serviceCode = File.ReadAllText(serviceFile);
            ClassEditor classEditor = new ClassEditor();
            classEditor.LoadCode(serviceCode);

            MethodEditor methodEditor = new MethodEditor();
            methodEditor.Initialize(VisitLevel.Private, false, "void", "Init");

            var asm = Assembly.GetAssembly(typeof(ProtocolService));
            var types = asm.GetTypes();
            types = types.FindAll(value => value.GetCustomAttribute(typeof(JackMessageObjectAttribute)) != null);
            const string MESSAGE_DICTIONARY_NAME = "messageInfoDic";
            const string FUNC_DICTIONARY_NAME = "generateDic";
            for (int i = 0; i < types.Length; i += 1) {
                var msgType = types[i];
                methodEditor.AppendLine($"{MESSAGE_DICTIONARY_NAME}.Add(typeof({msgType.Name}), {i.ToString()});");
                methodEditor.AppendLine($"{FUNC_DICTIONARY_NAME}.Add(typeof({msgType.Name}), new Func<{msgType.Name}>(() => new {msgType.Name}()));");
            }

            classEditor.RemoveMethod("Init");
            classEditor.AddMethod(methodEditor);

            serviceCode = classEditor.Generate();
            FileHelper.SaveFileText(serviceCode, serviceFile);

        }

    }

}
#endif