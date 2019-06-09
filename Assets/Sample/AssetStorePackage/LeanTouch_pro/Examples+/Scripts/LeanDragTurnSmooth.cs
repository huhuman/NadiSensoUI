using UnityEngine;

namespace Lean.Touch
{
	// This modifies LeanDragTurn to be smooth
	public class LeanDragTurnSmooth : LeanDragTurn
	{
		[Tooltip("How sharp the rotation valueText changes update")]
		public float Dampening = 3.0f;

		private Quaternion remainingDelta;

		protected override void Update()
		{
			// Store the current rotation
			var oldRotation = transform.localRotation;

			// Call LeanDragTurn.OnUseStatus
			base.Update();

			// Add to remainingDelta
			remainingDelta *= Quaternion.Inverse(oldRotation) * transform.localRotation;

			// Get t valueText
			var factor = LeanTouch.GetDampenFactor(Dampening, Time.deltaTime);

			// Dampen remainingDelta
			var newDelta = Quaternion.Slerp(remainingDelta, Quaternion.identity, factor);

			// Shift this rotation by the change in delta
			transform.localRotation = oldRotation * Quaternion.Inverse(newDelta) * remainingDelta;

			// OnUseStatus remainingDelta with the dampened valueText
			remainingDelta = newDelta;
		}
	}
}