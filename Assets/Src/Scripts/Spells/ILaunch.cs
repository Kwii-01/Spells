using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;

using Cysharp.Threading.Tasks;

using Effects;

using Entities;

using UnityEngine;

namespace Spells {
    public interface ILaunch {
        public void Execute(Entity User, Spell spell);
    }


    [Serializable]
    public class ClickLaunch : ILaunch {
        [SerializeField] private Effect[] _effects;

        public void Execute(Entity User, Spell spell) {
            EffectData data = new EffectData { Position = User.transform.position, User = User, Target = null };
            foreach (Effect effect in this._effects) {
                effect.Execute(data, User.GetCancellationTokenOnDestroy());
            }
        }
    }

    // [Serializable]
    // public class HoldLaunch : ILaunch {
    //     [SerializeField] private Effect[] _effectsOnBegin;
    //     [SerializeField] private float _timer;
    //     [SerializeField] private Effect[] _effectsOnHold;
    //     [SerializeField] private Effect[] _effectsOnEnd;

    //     public async void Execute(Entity User, Spell spell) {
    //         EffectData data = new EffectData { Position = User.transform.position, User = User, Target = null };
    //         CancellationToken token = User.GetCancellationTokenOnDestroy();
    //         foreach (Effect effect in this._effectsOnBegin) {
    //             effect.Execute(data, token);
    //         }

    //         foreach (Effect effect in this._effectsOnHold) {
    //             effect.ExecuteLoop(data, token, )
    //         }


    //         foreach (Effect effect in this._effectsOnEnd) {
    //             effect.Execute(data, token);
    //         }
    //     }
    // }
}