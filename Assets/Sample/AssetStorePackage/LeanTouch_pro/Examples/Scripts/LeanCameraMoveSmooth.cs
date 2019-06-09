using UnityEngine;

namespace Lean.Touch
{
	// This modifies LeanCameraMove to be smooth
	public class LeanCameraMoveSmooth : LeanCameraMove
	{
		[Tooltip("How quickly the zoom reaches the template valueText")]
		public float Dampening = 10.0f;

		private Vector3 remainingDelta;

		protected override void LateUpdate()
		{
			// Store the current position
			var oldPosition = transform.localPosition;

			// Call LeanCameraMove.LateUpdate
			base.LateUpdate();

			// Add to remainingDelta
			remainingDelta += transform.localPosition - oldPosition;

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