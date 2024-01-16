using System;
using System.Collections.Generic;
using System.Threading;

using Cysharp.Threading.Tasks;

using UnityEngine;

namespace VisualScripting {
    public static class Instructions {
        public static async UniTask Execute<T>(T data, IInstruction<T>[] instructions, CancellationToken token) {
            try {
                await ExecuteNoCatch(data, instructions, token);
            } catch (Exception ex) {
#if UNITY_EDITOR
                Debug.LogError(ex.Message);
#endif
            }
        }

        public static async UniTask ExecuteLoop<T>(T data, IInstruction<T>[] instructions, CancellationToken token, Func<bool> stopCondition, PlayerLoopTiming playerLoopTiming = PlayerLoopTiming.Update) {
            try {
                while (stopCondition() == false) {
                    await ExecuteNoCatch(data, instructions, token);
                    await UniTask.Yield(playerLoopTiming);
                }
            } catch (Exception ex) {
#if UNITY_EDITOR
                Debug.LogError(ex.Message);
#endif
            }
        }

        private static async UniTask ExecuteNoCatch<T>(T data, IInstruction<T>[] instructions, CancellationToken token) {
            List<UniTask> tasks = new List<UniTask> { instructions[0].Execute(data, token) };
            for (int i = 1; i < instructions.Length; i++) {
                int current = i;
                tasks.Add(tasks[i - 1].ContinueWith(() => {
                    instructions[current].Execute(data, token);
                }));
            }
            await UniTask.WhenAll(tasks);
        }

    }
}