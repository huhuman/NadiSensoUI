using System;
using UnityEngine;

namespace NADISystemEditor
{
    /// <summary>
    /// 實作邏輯物件: 建立 選擇事件
    /// </summary>
    [System.Serializable]
    public class LogicObject : BaseLogicObject
    {
        [Header("目前選擇的遊戲物件")] public GameObject selectedGameObject;
        [Header("目前選擇物件的父物件")] public Transform selectedObjectParent;

        public Events events = new Events();

        public void OnAwake(NADISystemEditor nadiSystemEditor)
        {
            this.nadiSystemEditor = nadiSystemEditor;
        }

        /// <summary>
        /// 處理更新
        /// </summary>
        public override void OnUpdate()
        {
            base.OnUpdate();
            OnUpdateSelectedObject();
        }

        /// <summary>
        /// 更新選擇的物體
        /// </summary>
        private void OnUpdateSelectedObject()
        {
            if (nadiSystemEditor != null)
            {
                //目前選擇的遊戲物件
                if (selectedGameObject != nadiSystemEditor.logicObject.GetGameObject())
                {
                    selectedGameObject = nadiSystemEditor.logicObject.GetGameObject();
                }

                if (selectedObjectParent != nadiSystemEditor.logicObject.GetParent())
                {
                    selectedObjectParent = nadiSystemEditor.logicObject.GetParent();
                }

            }
        }
        
        /// <summary>
        /// 事件
        /// </summary>
        public class Events
        {
            /// <summary>
            /// 處理選擇
            /// </summary>
            public delegate void SelectedHandle();
            /// <summary>
            /// 處理取消選取
            /// </summary>
            public delegate void DeselectedHandle();

            /// <summary>
            /// 選擇事件
            /// </summary>
            public event SelectedHandle selectedEvent;
            /// <summary>
            /// 取消事件
            /// </summary>
            public event DeselectedHandle deselectedEvent;

            /// <summary>
            /// 執行選擇事件
            /// </summary>
            public void OnSelected()
            {
                if (selectedEvent != null)
                {
                    selectedEvent.Invoke();
                }
            }

            /// <summary>
            /// 執行取消選擇事件
            /// </summary>
            public void OnDeselected()
            {
                if (deselectedEvent != null)
                {
                    deselectedEvent.Invoke();
                }
            }

            /// <summary>
            /// 取得委派清單
            /// </summary>
            public void GetSelectedHandleListLength()
            {
                Debug.Log("委派長度: " + selectedEvent.GetInvocationList().Length);
            }
        }
    }
}
