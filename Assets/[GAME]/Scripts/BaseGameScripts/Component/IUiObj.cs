using UnityEngine;

namespace Scripts.Component
{
    public interface IUiObj
    {
        RectTransform Rect { get; set; }
        GameObject Go { get; set; }
    }
}