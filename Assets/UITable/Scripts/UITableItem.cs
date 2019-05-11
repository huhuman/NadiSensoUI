using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UIPlugin.Table {
    public class UITableItem : MonoBehaviour {
        [Header ("第一列資料")]
        public Text tableCol1;
        [Header ("第二列資料")]
        public Text tableCol2;
        [Header ("底圖")]
        public Image tableBg;
        /**
         * 設置資料
         */
        public void SetDataToTable (string[] data, bool isTitle = false) {
            tableCol1.text = data[0];
            tableCol2.text = data[1];
            // 如果為標題的話底色變色
            if (isTitle) {
                tableBg.color = Color.grey;
            }
        }
    }
}