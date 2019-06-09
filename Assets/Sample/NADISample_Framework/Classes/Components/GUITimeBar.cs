using UnityEngine;
using UnityEngine.UI;

namespace NADISystemEditor
{
    public class GUITimeBar : MonoBehaviour
    {
        public Slider slider;

        /// <summary>
        /// 取得值
        /// </summary>
        /// <returns></returns>
        public float GetValue()
        {
            return slider.value;
        }
    }
}