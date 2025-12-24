using KadenZombie8.BIMOS;
using KadenZombie8.BIMOS.Rig;
using UnityEngine;

namespace KadenZombie8.BIMOS.Networking.Samples {
    public class GamemodePlayer : MonoBehaviour {
        public float MaxHealth = 30;
        public float Health { get; set; } = new();
        public uint Kills { get; set; } = new();
        public uint Deaths { get; set; } = new();
        public BIMOSRig rig;
        public static GamemodePlayer LocalRig = new();
        private void Start() {
            rig = GetComponent<BIMOSRig>();
            if (!LocalRig)
                return;
            LocalRig = this;
        }

        public void NewDeath() {
        }

        public void RequestKill() {

        }

        public void RequestDamage(float damage) {

        }
    }
}