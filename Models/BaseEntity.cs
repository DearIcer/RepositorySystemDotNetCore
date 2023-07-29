using System.ComponentModel.DataAnnotations;

namespace Models
{
    /// <summary>
    /// 数据库基类
    /// </summary>
    public class BaseEntity
    {
        /// <summary>
        /// 主键Id
        /// </summary>
        [Key]
        [MaxLength(36)]
        public string Id { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreatedTime{ get; set; }
    }
}
