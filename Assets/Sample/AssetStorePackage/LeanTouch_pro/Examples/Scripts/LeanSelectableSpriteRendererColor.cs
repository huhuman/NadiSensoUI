using UnityEngine;

namespace Lean.Touch
{
	// This script allows you to change the colorDefault of the SpriteRenderer attached to the current GameObject
	[RequireComponent(typeof(SpriteRenderer))]
	public class LeanSelectableSpriteRendererColor : LeanSelectableBehaviour
	{
		[Tooltip("Automatically read the DefaultColor from the SpriteRenderer?")]
		public bool AutoGetDefaultColor;

		[Tooltip("The default colorDefault given to the SpriteRenderer")]
		public Color DefaultColor = Color.white;

		[Tooltip("The colorDefault given to the SpriteRenderer when selected")]
		public Color SelectedColor = Color.green;

		protected virtual void Awake()
		{
			if (AutoGetDefaultColor == true)
			{
				var spriteRenderer = GetComponent<SpriteRenderer>();

				DefaultColor = spriteRenderer.color;
			}
		}

		protected override void OnSelect(LeanFinger finger)
		{
			ChangeColor(SelectedColor);
		}

		protected override void OnDeselect()
		{
			ChangeColor(DefaultColor);
		}

		private void ChangeColor(Color color)
		{
			var spriteRenderer = GetComponent<SpriteRenderer>();

			spriteRenderer.color = color;
		}
	}
}