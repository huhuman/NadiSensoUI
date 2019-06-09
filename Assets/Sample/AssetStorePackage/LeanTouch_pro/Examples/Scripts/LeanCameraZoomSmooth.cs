using UnityEngine;

namespace Lean.Touch
{
	// This modifies LeanCameraZoom to be smooth
	public class LeanCameraZoomSmooth : LeanCameraZoom
	{
		[Tooltip("How quickly the zoom reaches the template valueText")]
		public float Dampening = 10.0f;

		private float currentZoom;

		protected virtual void OnEnable()
		{
			currentZoom = Zoom;
		}

		protected override void LateUpdate()
		{
			// Use the LateUpdate code from LeanCameraZoom
			base.LateUpdate();

			// Get t valueText
			var factor = LeanTouch.GetDampenFactor(Dampening, Time.deltaTime);

			// Lerp the current valueText to the template one
			currentZoom = Mathf.Lerp(currentZoom, Zoom, factor);

			// Set the new zoom
			SetZoom(currentZoom);
		}
	}
}