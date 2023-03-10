using UnityEngine;

namespace KevinCastejon.MoreAttributes
{
    /// <summary>
    ///     Hides the property in PlayMode. The behaviour can be inverted with the 'invert' parameter so the property is
    ///     visible only in PlayMode.
    /// </summary>
    public class HideOnPlayAttribute : PropertyAttribute
    {
        public readonly bool invert;

        /// <summary>
        ///     Hide the property in PlayMode. The behaviour can be inverted with the 'invert' parameter so the property is visible
        ///     only in PlayMode.
        /// </summary>
        /// <param name="invert">If set to true, it inverts the behaviour and makes the property visible only in PlayMode.</param>
        public HideOnPlayAttribute(bool invert = false)
        {
            this.invert = invert;
        }
    }
}