using System.Collections;
using UnityEngine;

namespace OpenAIToolkit
{
    internal class CoroutinesExecutor : MonoBehaviour
    {
        private static CoroutinesExecutor _instance;

        private static CoroutinesExecutor Instance
        {
            get
            {
                if (!_instance)
                {
                    _instance = FindObjectOfType<CoroutinesExecutor>();

                    if (!_instance)
                    {
                        var go = new GameObject("OpenAIToolkit.CoroutinesExecutor");
                        _instance = go.AddComponent<CoroutinesExecutor>();
                    }
                }

                return _instance;
            }
        }

        public static void Run(IEnumerator coroutine)
        {
            Instance.StartCoroutine(coroutine);
        }
    }
}