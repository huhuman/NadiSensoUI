using UnityEngine;

namespace NADISystemEditor
{
    /// <summary>
    /// [基本]邏輯物件
    /// </summary>
    public abstract class BaseLogicObject : BaseSerializableType
    {
        private GameObject gameObject;
        private Transform parent;

        /// <summary>
        /// 設定遊戲物件
        /// </summary>
        /// <param name="gameObject"></param>
        public void SetGameObject(GameObject gameObject)
        {
            this.gameObject = gameObject;
            //如果物件有父節點就指定
            if (this.gameObject && this.gameObject.transform.parent)
            {
                SetParetn(this.gameObject.transform.parent);
            }
            else if (!this.gameObject)
            {
                SetParetn(null);
            }
        }

        /// <summary>
        /// 取得遊戲物件
        /// </summary>
        /// <returns></returns>
        public GameObject GetGameObject()
        {
            return this.gameObject;
        }

        /// <summary>
        /// 物件名
        /// </summary>
        /// <returns></returns>
        public string GetName()
        {
            if (gameObject != null)
            {
                return "邏輯物件名: " + gameObject.name;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 設定父物件
        /// </summary>
        /// <param name="parent"></param>
        public void SetParetn(Transform parent)
        {
            this.parent = parent;
        }

        /// <summary>
        /// 取得父物件
        /// </summary>
        /// <returns></returns>
        public Transform GetParent()
        {
            return parent;
        }

        /// <summary>
        /// 取得父物件名
        /// </summary>
        /// <returns></returns>
        public string GetParentName()
        {
            if (parent != null)
            {
                return "父物件名: " + parent.name;
            }
            else
            {
                return null;
            }
        }
    }
}