using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestRunner;
using UnityEngine.TestTools;
using NUnit.Framework;
using JackFrame;

namespace SJSJ.Client.Tests {

    public class TestApp {

        static float timeout = 2f;
        public static WaitForSeconds tick = new WaitForSeconds(0.016f);

        public static void SetUp() {
            PLog.OnAssert += (condition, msg) => Assert.That(condition, msg);
            PLog.OnAssertWithoutMessage += (condition) => Assert.That(condition);
        }

        public static void ResetTimeout() {
            timeout = 2f;
        }

        public static void Timeout() {
            timeout -= 0.016f;
            if (timeout <= 0) {
                Assert.Fail("TIMEOUT");
            }
        }

    }

}