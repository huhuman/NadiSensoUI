namespace NADISystemEditor
{
    /// <summary>
    /// 基本序列化型態
    /// </summary>
    public abstract class BaseSerializableType
    {
        /// <summary>
        /// NADI編輯系統主要管理
        /// </summary>
        protected NADISystemEditor nadiSystemEditor;

        public virtual void OnAwake(NADISystemEditor nadiSystemEditor)
        {
            this.nadiSystemEditor = nadiSystemEditor;
        }

        public virtual void OnUpdate()
        {
            
        }
    }
}