using UnityEngine;

namespace Utilities
{
    public static class LayerMaskExtensions
    {
        public static bool LayerMaskContains(this LayerMask mask, int layer)
        {
            return mask == (mask | (1 << layer));
        }
        
        public static bool WithinMask(this int layer, LayerMask mask)
        {
            return mask.LayerMaskContains(layer);
        }
    }
}