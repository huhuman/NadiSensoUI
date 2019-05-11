using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UIPlugin.Table {
    public class UITable : MonoBehaviour {
        [Header ("欄位數上限")]
        public int maxTableRow;
        // 暫存當前產生的欄位數
        private int nowTableRow { get { return uiItems.Count; } }

        [Header ("表格欄位Prefab")]
        public GameObject uITableItem;
        public Transform uITableItemParent;
        public List<UITableItem> uiItems = new List<UITableItem> ();

        public void CreateTable (string[] data, bool isTitle = false) {
            if (nowTableRow >= maxTableRow) { return; }
            UITableItem uiItem = GameObject.Instantiate (uITableItem, uITableItemParent).GetComponent<UITableItem> ();
            uiItem.SetDataToTable (data, isTitle);
            uiItems.Add (uiItem);
        }
    }
}