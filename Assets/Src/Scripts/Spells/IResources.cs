using System.Collections;
using System.Collections.Generic;

using Entities;

using UnityEngine;

namespace Spells {
    public interface IResources {
        public void Use(Entity user);
    }
}