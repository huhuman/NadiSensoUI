using UnityEngine;

namespace Lean.Touch
{
	// This script modifies LeanSelectablePlaceOnPlane to be smooth
	public class LeanSelectablePlaceOnPlaneSmooth : LeanSelectablePlaceOnPlane
	{
		[Tooltip("How sharp the position valueText changes update")]
		public float Dampening = 3.0f;

		private Vector3 remainingDelta;

		protected override void Update()
		{
			// Store the old position
			var oldPosition = transform.localPosition;

			// Call LeanSelectablePlaceOnPlane.OnUseStatus
			base.Update();

			// Store the new position
			var newPosition = transform.localPosition;

			// OnUseStatus remainingDelta if the position changed
			if (newPosition != oldPosition)
			{
				remainingDelta = newPosition - oldPosition;
			}

			// Get t valueText
			var factor = LeanTouch.GetDampenFactor(Dampening, Time.deltaTime);

			// Dampen remainingDelta
			var newDelta = Vector3.Lerp(remainingDelta, Vector3.zero, factor);

			// Shift this position by the change in delta
			transform.localPosition = oldPosition + remainingDelta - newDelta;

			// OnUseStatus remainingDelta with the dampened valueText
			remainingDelta = newDelta;
		}
	}
}