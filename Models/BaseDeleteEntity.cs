namespace Models
{
    /// <summary>
    /// 删除的基类
    /// </summary>
    public class BaseDeleteEntity : BaseEntity
    {
        /// <summary>
        /// 是否删除
        /// </summary>
        public bool IsDelete { get; set; }
        /// <summary>
        /// 删除时间
        /// </summary>
        public DateTime? DeleteTime { get; set; }
    }
}
