using UnityEngine;

namespace NADISystemEditor
{
    public class BaseComponent : MonoBehaviour
    {
        /// <summary>
        /// NADI系統編輯
        /// </summary>
        public NADISystemEditor nadiSystemEditor;

        public virtual void Awake()
        {
            //取得管理者
            nadiSystemEditor = GameObject.Find("NADISystemEditor").GetComponent<NADISystemEditor>();
        }
    }
}