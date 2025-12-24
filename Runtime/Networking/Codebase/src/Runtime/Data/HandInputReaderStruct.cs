using KadenZombie8.BIMOS.Rig;
using System;
using UnityEngine;

namespace KadenZombie8.BIMOS.Networking
{
    [Serializable]
    public struct HandInputReaderStruct {
        public float Trigger, Grip;
        public bool
            TriggerTouched,
            ThumbrestTouched,
            PrimaryTouched,
            PrimaryButton,
            SecondaryTouched,
            SecondaryButton,
            ThumbstickTouched;
        public HandInputReaderStruct(HandInputReader reader) {
            Trigger = reader.Trigger;
            Grip = reader.Grip;
            TriggerTouched = reader.TriggerTouched;
            ThumbrestTouched = reader.ThumbrestTouched;
            PrimaryTouched = reader.PrimaryTouched;
            PrimaryButton = reader.PrimaryButton;
            SecondaryTouched = reader.SecondaryTouched;
            SecondaryButton = reader.SecondaryButton;
            ThumbstickTouched = reader.ThumbstickTouched;
        }
        public void Serialize(HandInputReader reader) {
            Trigger = reader.Trigger;
            Grip = reader.Grip;
            TriggerTouched = reader.TriggerTouched;
            ThumbrestTouched = reader.ThumbrestTouched;
            PrimaryTouched = reader.PrimaryTouched;
            PrimaryButton = reader.PrimaryButton;
            SecondaryTouched = reader.SecondaryTouched;
            SecondaryButton = reader.SecondaryButton;
            ThumbstickTouched = reader.ThumbstickTouched;
        }

        public void Deserialize(HandInputReader reader) {
            reader.Trigger = Trigger;
            reader.Grip = Grip;
            reader.TriggerTouched = TriggerTouched;
            reader.ThumbrestTouched = ThumbrestTouched;
            reader.PrimaryTouched = PrimaryTouched;
            reader.PrimaryButton = PrimaryButton;
            reader.SecondaryTouched = SecondaryTouched;
            reader.SecondaryButton = SecondaryButton;
            reader.ThumbstickTouched = ThumbstickTouched;
        }
    }
}
