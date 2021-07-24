using System.Runtime.CompilerServices;
using UnityEngine;

namespace Z.Ease
{
	public static class EaseCalculator
	{
		[MethodImpl (MethodImplOptions.AggressiveInlining)]
		public static float CalculateEaseInQuad (float start, float diff, float alpha)
		{
			return (diff * alpha * alpha) + start;
		}

		[MethodImpl (MethodImplOptions.AggressiveInlining)]
		public static float CalculateEaseOutQuad (float start, float diff, float alpha)
		{
			return (-diff * alpha * (alpha - 2f)) + start;
		}

		[MethodImpl (MethodImplOptions.AggressiveInlining)]
		public static float CalculateEaseInOutQuad (float start, float diff, float alpha)
		{
			alpha /= 0.5f;

			if (alpha < 1f)
			{
				return (diff / 2f * alpha * alpha) + start;
			}
			else
			{
				alpha--;

				return (-diff / 2f * ((alpha * (alpha - 2f)) - 1f)) + start;
			}
		}

		[MethodImpl (MethodImplOptions.AggressiveInlining)]
		public static float CalculateEaseInCubic (float start, float end, float alpha)
		{
			end -= start;

			return (end * alpha * alpha * alpha) + start;
		}

		[MethodImpl (MethodImplOptions.AggressiveInlining)]
		public static float CalculateEaseOutCubic (float start, float end, float alpha)
		{
			alpha--;
			end -= start;

			return (end * ((alpha * alpha * alpha) + 1f)) + start;
		}

		[MethodImpl (MethodImplOptions.AggressiveInlining)]
		public static float CalculateEaseInOutCubic (float start, float end, float alpha)
		{
			alpha /= 0.5f;
			end -= start;

			if (alpha < 1f)
			{
				return (end / 2f * alpha * alpha * alpha) + start;
			}
			else
			{
				alpha -= 2f;

				return (end / 2f * ((alpha * alpha * alpha) + 2f)) + start;
			}
		}

		[MethodImpl (MethodImplOptions.AggressiveInlining)]
		public static float CalculateEaseInQuart (float start, float end, float alpha)
		{
			end -= start;

			return (end * alpha * alpha * alpha * alpha) + start;
		}

		[MethodImpl (MethodImplOptions.AggressiveInlining)]
		public static float CalculateEaseOutQuart (float start, float end, float alpha)
		{
			alpha--;
			end -= start;

			return (-end * ((alpha * alpha * alpha * alpha) - 1)) + start;
		}

		[MethodImpl (MethodImplOptions.AggressiveInlining)]
		public static float CalculateEaseInOutQuart (float start, float end, float alpha)
		{
			alpha /= 0.5f;
			end -= start;

			if (alpha < 1f)
			{
				return (end / 2f * alpha * alpha * alpha * alpha) + start;
			}
			else
			{
				alpha -= 2f;

				return (-end / 2f * ((alpha * alpha * alpha * alpha) - 2f)) + start;
			}
		}

		[MethodImpl (MethodImplOptions.AggressiveInlining)]
		public static float CalculateEaseInQuint (float start, float end, float alpha)
		{
			end -= start;

			return (end * alpha * alpha * alpha * alpha * alpha) + start;
		}

		[MethodImpl (MethodImplOptions.AggressiveInlining)]
		public static float CalculateEaseOutQuint (float start, float end, float alpha)
		{
			alpha--;
			end -= start;

			return (end * ((alpha * alpha * alpha * alpha * alpha) + 1f)) + start;
		}

		[MethodImpl (MethodImplOptions.AggressiveInlining)]
		public static float CalculateEaseInOutQuint (float start, float end, float alpha)
		{
			alpha /= 0.5f;
			end -= start;

			if (alpha < 1f)
			{
				return (end / 2f * alpha * alpha * alpha * alpha * alpha) + start;
			}
			else
			{
				alpha -= 2f;

				return (end / 2f * ((alpha * alpha * alpha * alpha * alpha) + 2f)) + start;
			}
		}

		[MethodImpl (MethodImplOptions.AggressiveInlining)]
		public static float CalculateEaseInSine (float start, float end, float alpha)
		{
			end -= start;

			return (-end * Mathf.Cos (alpha / 1f * (Mathf.PI / 2f))) + end + start;
		}

		[MethodImpl (MethodImplOptions.AggressiveInlining)]
		public static float CalculateEaseOutSine (float start, float end, float alpha)
		{
			end -= start;

			return (end * Mathf.Sin (alpha / 1f * (Mathf.PI / 2f))) + start;
		}

		[MethodImpl (MethodImplOptions.AggressiveInlining)]
		public static float CalculateEaseInOutSine (float start, float end, float alpha)
		{
			end -= start;

			return (-end / 2f * (Mathf.Cos (Mathf.PI * alpha / 1f) - 1f)) + start;
		}

		[MethodImpl (MethodImplOptions.AggressiveInlining)]
		public static float CalculateEaseInExpo (float start, float end, float alpha)
		{
			end -= start;

			return (end * Mathf.Pow (2f, 10f * (alpha / 1f - 1f))) + start;
		}

		[MethodImpl (MethodImplOptions.AggressiveInlining)]
		public static float CalculateEaseOutExpo (float start, float end, float alpha)
		{
			end -= start;

			return end * (-Mathf.Pow (2f, -10f * alpha / 1f) + 1f) + start;
		}

		[MethodImpl (MethodImplOptions.AggressiveInlining)]
		public static float CalculateEaseInOutExpo (float start, float end, float alpha)
		{
			alpha /= 0.5f;
			end -= start;

			if (alpha < 1f)
			{
				return (end / 2f * Mathf.Pow (2f, 10f * (alpha - 1f))) + start;
			}
			else
			{
				alpha--;

				return (end / 2f * (-Mathf.Pow (2f, -10f * alpha) + 2f)) + start;
			}
		}

		[MethodImpl (MethodImplOptions.AggressiveInlining)]
		public static float CalculateEaseInCirc (float start, float end, float alpha)
		{
			end -= start;

			return (-end * (Mathf.Sqrt (1f - (alpha * alpha)) - 1f)) + start;
		}

		[MethodImpl (MethodImplOptions.AggressiveInlining)]
		public static float CalculateEaseOutCirc (float start, float end, float alpha)
		{
			alpha--;
			end -= start;

			return (end * Mathf.Sqrt (1f - (alpha * alpha))) + start;
		}

		[MethodImpl (MethodImplOptions.AggressiveInlining)]
		public static float CalculateEaseInOutCirc (float start, float end, float alpha)
		{
			alpha /= 0.5f;
			end -= start;

			if (alpha < 1f)
			{
				return (-end / 2f * (Mathf.Sqrt (1f - alpha * alpha) - 1f)) + start;
			}
			else
			{
				alpha -= 2f;

				return (end / 2f * (Mathf.Sqrt (1f - alpha * alpha) + 1f)) + start;
			}
		}

		[MethodImpl (MethodImplOptions.AggressiveInlining)]
		public static float CalculateEaseInBounce (float start, float end, float alpha)
		{
			end -= start;
			float duration = 1f;

			return end - CalculateEaseOutBounce (0f, end, duration - alpha) + start;
		}

		[MethodImpl (MethodImplOptions.AggressiveInlining)]
		public static float CalculateEaseOutBounce (float start, float end, float alpha)
		{
			alpha /= 1f;
			end -= start;

			if (alpha < (1f / 2.75f))
			{
				return (end * (7.5625f * alpha * alpha)) + start;
			}
			else if (alpha < (2f / 2.75f))
			{
				alpha -= (1.5f / 2.75f);

				return (end * ((7.5625f * alpha * alpha) + 0.75f)) + start;
			}
			else if (alpha < (2.5f / 2.75f))
			{
				alpha -= (2.25f / 2.75f);

				return (end * ((7.5625f * alpha * alpha) + 0.9375f)) + start;
			}
			else
			{
				alpha -= (2.625f / 2.75f);

				return (end * ((7.5625f * alpha * alpha) + 0.984375f)) + start;
			}
		}

		[MethodImpl (MethodImplOptions.AggressiveInlining)]
		public static float CalculateEaseInOutBounce (float start, float end, float alpha)
		{
			end -= start;
			float duration = 1f;

			if (alpha < (duration / 2f))
			{
				return (CalculateEaseInBounce (0f, end, alpha * 2f) * 0.5f) + start;
			}
			else
			{
				return (CalculateEaseOutBounce (0f, end, alpha * 2f - duration) * 0.5f) + (end * 0.5f) + start;
			}
		}

		[MethodImpl (MethodImplOptions.AggressiveInlining)]
		public static float CalculateEaseInBack (float start, float end, float alpha)
		{
			end -= start;
			alpha /= 1f;
			float constS = 1.70158f;

			return (end * alpha * alpha * (((constS + 1f) * alpha) - constS)) + start;
		}

		[MethodImpl (MethodImplOptions.AggressiveInlining)]
		public static float CalculateEaseOutBack (float start, float end, float alpha)
		{
			float slope = 1.70158f;
			end -= start;
			alpha = (alpha / 1f) - 1f;

			return (end * (alpha * alpha * (((slope + 1f) * alpha) + slope) + 1f)) + start;
		}

		[MethodImpl (MethodImplOptions.AggressiveInlining)]
		public static float CalculateEaseInOutBack (float start, float end, float alpha)
		{
			float slope = 1.70158f;
			end -= start;
			alpha /= 0.5f;

			if (alpha < 1f)
			{
				slope *= 1.525f;

				return (end / 2f * (alpha * alpha * (((slope + 1f) * alpha) - slope))) + start;
			}
			else
			{
				alpha -= 2f;
				slope *= 1.525f;

				return (end / 2f * (alpha * alpha * (((slope + 1f) * alpha) + slope) + 2f)) + start;
			}
		}

		[MethodImpl (MethodImplOptions.AggressiveInlining)]
		public static float CalculateEaseInElastic (float start, float end, float alpha)
		{
			end -= start;

			float duration = 1f;
			float position = duration * 0.3f;
			float slope = 0f;
			float endValue = 0f;

			if (alpha == 0f)
			{
				return start;
			}

			alpha = alpha / duration;

			if (alpha == 1f)
			{
				return start + end;
			}

			if (endValue == 0f || endValue < Mathf.Abs (end))
			{
				endValue = end;
				slope = position / 4f;
			}
			else
			{
				slope = position / (2f * Mathf.PI) * Mathf.Asin (end / endValue);
			}

			alpha = alpha - 1f;

			return -(endValue * Mathf.Pow (2f, 10f * alpha) * Mathf.Sin (((alpha * duration) - slope) * (2f * Mathf.PI) / position)) + start;
		}

		[MethodImpl (MethodImplOptions.AggressiveInlining)]
		public static float CalculateEaseOutElastic (float start, float end, float alpha)
		{
			end -= start;

			float duration = 1f;
			float position = duration * 0.3f;
			float slope = 0f;
			float endValue = 0f;

			if (alpha == 0f)
			{
				return start;
			}

			alpha = alpha / duration;

			if (alpha == 1f)
			{
				return start + end;
			}

			if (endValue == 0f || endValue < Mathf.Abs (end))
			{
				endValue = end;
				slope = position / 4f;
			}
			else
			{
				slope = position / (2f * Mathf.PI) * Mathf.Asin (end / endValue);
			}

			return (endValue * Mathf.Pow (2f, -10f * alpha) * Mathf.Sin (((alpha * duration) - slope) * (2f * Mathf.PI) / position)) + end + start;
		}

		[MethodImpl (MethodImplOptions.AggressiveInlining)]
		public static float CalculateEaseInOutElastic (float start, float end, float alpha)
		{
			end -= start;

			float duration = 1f;
			float position = duration * 0.3f;
			float slope = 0f;
			float endValue = 0f;

			if (alpha == 0)
			{
				return start;
			}

			alpha = alpha / (duration / 2f);

			if (alpha == 2f)
			{
				return start + end;
			}

			if (endValue == 0f || endValue < Mathf.Abs (end))
			{
				endValue = end;
				slope = position / 4f;
			}
			else
			{
				slope = position / (2f * Mathf.PI) * Mathf.Asin (end / endValue);
			}

			if (alpha < 1f)
			{
				alpha = alpha - 1f;

				return (-0.5f * (endValue * Mathf.Pow (2f, 10f * alpha) * Mathf.Sin (((alpha * duration) - slope) * (2f * Mathf.PI) / position))) + start;
			}

			alpha = alpha - 1f;

			return (endValue * Mathf.Pow (2f, -10f * alpha) * Mathf.Sin (((alpha * duration) - slope) * (2f * Mathf.PI) / position) * 0.5f) + end + start;
		}

		[MethodImpl (MethodImplOptions.AggressiveInlining)]
		public static float CalculateEaseSpring (float start, float end, float alpha)
		{
			alpha = Mathf.Clamp01 (alpha);
			alpha = (Mathf.Sin (alpha * Mathf.PI * (0.2f + (2.5f * alpha * alpha * alpha))) * Mathf.Pow (1f - alpha, 2.2f) + alpha) * (1f + (1.2f * (1f - alpha)));

			return start + ((end - start) * alpha);
		}

		[MethodImpl (MethodImplOptions.AggressiveInlining)]
		public static float CalculateOnAnimationCurve (float start, float diff, float alpha, AnimationCurve animationCurve)
		{
			return start + (diff * animationCurve.Evaluate (alpha));
		}

		[MethodImpl (MethodImplOptions.AggressiveInlining)]
		public static float GetCalculatedAlpha (float alpha, EaseType easeType)
		{
			return GetCalculatedAlpha (0f, 1f, alpha, easeType);
		}

		[MethodImpl (MethodImplOptions.AggressiveInlining)]
		public static float GetCalculatedAlpha (float start, float diff, float alpha, EaseType easeType)
		{
			switch (easeType)
			{
				default:
				case EaseType.Linear:
					return alpha;
				case EaseType.EaseOutQuad:
					return CalculateEaseOutQuad (start, diff, alpha);
				case EaseType.EaseInQuad:
					return CalculateEaseInQuad (start, diff, alpha);
				case EaseType.EaseInOutQuad:
					return CalculateEaseInOutQuad (start, diff, alpha);
				case EaseType.EaseInQubic:
					return CalculateEaseInCubic (start, diff, alpha);
				case EaseType.EaseOutCubic:
					return CalculateEaseOutCubic (start, diff, alpha);
				case EaseType.EaseInOutCubic:
					return CalculateEaseInOutCubic (start, diff, alpha);
				case EaseType.EaseInQuart:
					return CalculateEaseInQuart (start, diff, alpha);
				case EaseType.EaseOutQuart:
					return CalculateEaseOutQuart (start, diff, alpha);
				case EaseType.EaseInOutQuart:
					return CalculateEaseInOutQuart (start, diff, alpha);
				case EaseType.EaseInQuint:
					return CalculateEaseInQuint (start, diff, alpha);
				case EaseType.EaseOutQuint:
					return CalculateEaseOutQuint (start, diff, alpha);
				case EaseType.EaseInOutQuint:
					return CalculateEaseInOutQuint (start, diff, alpha);
				case EaseType.EaseInSine:
					return CalculateEaseInSine (start, diff, alpha);
				case EaseType.EaseOutSine:
					return CalculateEaseOutSine (start, diff, alpha);
				case EaseType.EaseInOutSine:
					return CalculateEaseInOutSine (start, diff, alpha);
				case EaseType.EaseInExpo:
					return CalculateEaseInExpo (start, diff, alpha);
				case EaseType.EaseOutExpo:
					return CalculateEaseOutExpo (start, diff, alpha);
				case EaseType.EaseInOutExpo:
					return CalculateEaseInOutExpo (start, diff, alpha);
				case EaseType.EaseInCirc:
					return CalculateEaseInCirc (start, diff, alpha);
				case EaseType.EaseOutCirc:
					return CalculateEaseOutCirc (start, diff, alpha);
				case EaseType.EaseInOutCirc:
					return CalculateEaseInOutCirc (start, diff, alpha);
				case EaseType.EaseInBounce:
					return CalculateEaseInBounce (start, diff, alpha);
				case EaseType.EaseOutBounce:
					return CalculateEaseOutBounce (start, diff, alpha);
				case EaseType.EaseInOutBounce:
					return CalculateEaseInOutBounce (start, diff, alpha);
				case EaseType.EaseInBack:
					return CalculateEaseInBack (start, diff, alpha);
				case EaseType.EaseOutBack:
					return CalculateEaseOutBack (start, diff, alpha);
				case EaseType.EaseInOutBack:
					return CalculateEaseInOutBack (start, diff, alpha);
				case EaseType.EaseInElastic:
					return CalculateEaseInElastic (start, diff, alpha);
				case EaseType.EaseOutElastic:
					return CalculateEaseOutElastic (start, diff, alpha);
				case EaseType.EaseInOutElastic:
					return CalculateEaseInOutElastic (start, diff, alpha);
				case EaseType.EaseSpring:
					return CalculateEaseSpring (start, diff, alpha);
				case EaseType.Shake:
					return CalculateOnAnimationCurve (start, diff, alpha, _shakeAnimationCurve);
				case EaseType.Punch:
					return CalculateOnAnimationCurve (start, diff, alpha, _punchAnimationCurve);
			}
		}

		private static AnimationCurve _shakeAnimationCurve = new AnimationCurve (
			new Keyframe (0f, 0f),
			new Keyframe (0.25f, 1f),
			new Keyframe (0.75f, -1f),
			new Keyframe (1f, 0f)
		);

		private static AnimationCurve _punchAnimationCurve = new AnimationCurve (
			new Keyframe (0.0f, 0.0f),
			new Keyframe (0.112586f, 0.9976035f),
			new Keyframe (0.3120486f, -0.1720615f),
			new Keyframe (0.4316337f, 0.07030682f),
			new Keyframe (0.5524869f, -0.03141804f),
			new Keyframe (0.6549395f, 0.003909959f),
			new Keyframe (0.770987f, -0.009817753f),
			new Keyframe (0.8838775f, 0.001939224f),
			new Keyframe (1.0f, 0.0f)
		);
	}
}
