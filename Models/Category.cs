using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Category : BaseDeleteEntity
    {
        ///// <summary>
        ///// 主键Id
        ///// </summary>
        //[Key]
        //[MaxLength(36)]
        //public string Id { get; set; }
        /// <summary>
        /// 类别名称
        /// </summary>
        [MaxLength(16)]
        public string? CategoryName { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        [MaxLength(32)]
        public string? Description { get; set; }
    }
}
