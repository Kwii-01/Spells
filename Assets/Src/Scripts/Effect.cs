using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;

using Cysharp.Threading.Tasks;

using Entities;

using UnityEngine;

using VisualScripting;

namespace Effects {
    [CreateAssetMenu(menuName = "Spells/Effects")]
    public class Effect : ScriptableObject {
        [SerializeField, SerializeReference, SubclassSelector] private Component[] _components;

        public async void Execute(EffectData data, CancellationToken token) {
            await Instructions.Execute(data, this._components, token);
        }

        public async void ExecuteLoop(EffectData data, CancellationToken token, Func<bool> stopCondition, PlayerLoopTiming playerLoopTiming) {
            await Instructions.ExecuteLoop(data, this._components, token, stopCondition, playerLoopTiming);
        }
    }

    [Serializable]
    public class EffectData {
        public Vector3 Position;
        public Entity User;
        public Entity Target;
    }

    [Serializable]
    public abstract class Component : IInstruction<EffectData> {
        public abstract UniTask Execute(EffectData data, CancellationToken token);
    }
}