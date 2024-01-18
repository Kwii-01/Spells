using System.Collections;
using System.Collections.Generic;

using Entities;

using UnityEngine;

namespace Spells {
    public interface ILaunchCondition {
        public bool IsLaunchable(Entity user, Spell spell);
    }
}