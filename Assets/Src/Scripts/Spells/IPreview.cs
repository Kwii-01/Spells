using System.Collections;
using System.Collections.Generic;

using Entities;

using UnityEngine;

namespace Spells {
    public interface IPreview {
        public void Show(Entity user, Vector3 point);
        public void Hide(Entity user);
    }
}