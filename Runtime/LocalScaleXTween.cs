using ElRaccoone.Tweens.Core;
using UnityEngine;

namespace ElRaccoone.Tweens {
  public static class LocalScaleXTween {
    public static Tween<float> TweenLocalScaleX (this Component self, float to, float duration) =>
      Tween<float>.Add<Driver> (self).Finalize (duration, to);

    public static Tween<float> TweenLocalScaleX (this GameObject self, float to, float duration) =>
      Tween<float>.Add<Driver> (self).Finalize (duration, to);

    private class Driver : Tween<float, Transform> {
      private Vector3 localScale;

      public override float OnGetFrom () {
        return this.component.localScale.x;
      }

      public override void OnUpdate (float easedTime) {
        this.localScale = this.component.localScale;
        this.valueCurrent = this.InterpolateValue (this.valueFrom, this.valueTo, easedTime);
        this.localScale.x = this.valueCurrent;
        this.component.localScale = this.localScale;
      }
    }
  }
}