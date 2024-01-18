using System.Collections;
using System.Collections.Generic;

using Effects;

using UnityEngine;

// A spell is defined by:
// - How they are launched: click / hold / activation-deactivation
// - How they target: point click / skillshot / None
// - Their effects
// - which thing they can have effects on (ally / enemy / world)
// - which resources they use
// - cooldown
// - has icon + description

namespace Spells {
    public class Spell : MonoBehaviour {
        public string Name;
        public Sprite Icon;
        public float Cooldown;
        [TextArea] public string Description;
        [SerializeReference, SubclassSelector] public ILaunchCondition[] LaunchCondition;
        [SerializeReference, SubclassSelector] public IPreview Preview;

        public Effect[] PassiveEffects;



    }
}