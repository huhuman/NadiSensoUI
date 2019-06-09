using UnityEngine;

namespace NADISystemEditor
{
    /// <summary>
    /// 時間軸:
    /// **在此類定義 時間軸的原型 所需要的 參數，方法，事件，
    /// 並且讓 "時間軸組件" 與 "系統管理組件" 或延伸組件可以建立此類別物件;
    /// </summary>
    [System.Serializable]
    public class TimeBar : BaseSerializableType
    {
        [Header("當前時間")] public double currentTime;
        private double tempCurrentTime;

        /// <summary>
        /// 建立此類專屬事件物件
        /// </summary>
        public Events events = new Events();

        public override void OnAwake(NADISystemEditor nadiSystemEditor)
        {
            base.OnAwake(nadiSystemEditor);
            tempCurrentTime = currentTime;
        }

        public override void OnUpdate()
        {
            base.OnUpdate();
            //[實作了取得nadiSystemEditor的內容]此處傳入了 主要管理的模組 邏輯物件 當前選取的物體
            OnUpdateCurrentTimeForLogicObject(nadiSystemEditor.logicObject.selectedGameObject);
        }

        /// <summary>
        /// 更新邏輯對象的當前時間( ** 此方法可被類別內部執行或是外部呼叫，通常在內部執行 )
        /// </summary>
        /// <param name="target"></param>
        public void OnUpdateCurrentTimeForLogicObject(GameObject logicObject)
        {
            //以下範本只是示範檢查到條件時通知的邏輯物件因為不同條件，做同一件事但結果不同，正式的時間軸不是做這件事
            //更新條件符合才更新了位置
            if (logicObject != null && tempCurrentTime != currentTime)
            {
                float moveRange = 0;
                if (currentTime > 1 && currentTime < 20)
                {
                    moveRange = 0.1f;
                }
                else if (currentTime > 20 && currentTime < 50)
                {
                    moveRange = 0.3f;
                }
                else if (currentTime > 50 && currentTime < 100)
                {
                    moveRange = 0.6f;
                }

                logicObject.transform.localPosition += new Vector3(0, 0, moveRange);
                tempCurrentTime = currentTime;
            }
        }


        public class Events
        {
            /// <summary>
            /// 處理當前時間
            /// </summary>
            public delegate double CurrentTimeHandle();

            /// <summary>
            /// 處理範圍
            /// </summary>
            public delegate void RangeHandle();

            /// <summary>
            /// 處理標記點
            /// </summary>
            public delegate void MarkPointsHandle();

            /// <summary>
            /// 當前時間事件
            /// </summary>
            public event CurrentTimeHandle currentTimeEvent;

            /// <summary>
            /// 範圍事件
            /// </summary>
            public event RangeHandle rangeEvent;

            /// <summary>
            /// 標記點事件
            /// </summary>
            public event MarkPointsHandle markPointsEvent;

            /// <summary>
            /// 執行當前時間
            /// </summary>
            public void OnCurrentTime()
            {
                if (currentTimeEvent != null)
                {
                    currentTimeEvent.Invoke();
                }
            }

            /// <summary>
            /// 執行範圍
            /// </summary>
            public void OnRange()
            {
                if (rangeEvent != null)
                {
                    rangeEvent.Invoke();
                }
            }

            /// <summary>
            /// 執行標記點
            /// </summary>
            public void OnMarkPoints()
            {
                if (markPointsEvent != null)
                {
                    markPointsEvent.Invoke();
                }
            }
        }
    }
}