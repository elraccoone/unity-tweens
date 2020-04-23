using UnityEngine;

namespace ElRaccoone.Tweens.Helpers {
  public static class EasingMethods {
    public static float Apply (Ease ease, float time) {
      switch (ease) {
        default : return 0;
        case Ease.Linear:
            return EasingMethods.Linear (time);
        case Ease.SineIn:
            return EasingMethods.SineIn (time);
        case Ease.SineOut:
            return EasingMethods.SineOut (time);
        case Ease.SineInOut:
            return EasingMethods.SineInOut (time);
        case Ease.BackIn:
            return EasingMethods.BackIn (time);
        case Ease.BackOut:
            return EasingMethods.BackOut (time);
        case Ease.BackInOut:
            return EasingMethods.BackInOut (time);
      }
    }

    private static float Linear (float time) {
      return time;
    }

    private static float SineIn (float time) {
      return 1f - Mathf.Cos ((time * Mathf.PI) / 2f);
    }

    private static float SineOut (float time) {
      return Mathf.Sin ((time * Mathf.PI) / 2f);
    }

    private static float SineInOut (float time) {
      return -(Mathf.Cos (Mathf.PI * time) - 1f) / 2f;
    }

    private const float backConstantA = 1.70158f;
    private const float backConstantB = backConstantA * 1.525f;
    private const float backConstantC = backConstantA + 1;

    private static float BackIn (float time) {
      return backConstantC * time * time * time - backConstantA * time * time;
    }

    private static float BackOut (float time) {
      return 1f + backConstantC * Mathf.Pow (time - 1, 3) + backConstantA * Mathf.Pow (time - 1, 2);
    }

    private static float BackInOut (float time) {
      return time < 0.5 ?
        (Mathf.Pow (2 * time, 2) * ((backConstantB + 1) * 2 * time - backConstantB)) / 2 :
        (Mathf.Pow (2 * time - 2, 2) * ((backConstantB + 1) * (time * 2 - 2) + backConstantB) + 2) / 2;
    }
  }
}