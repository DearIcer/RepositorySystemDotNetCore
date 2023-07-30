using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class DepartmentInfo : BaseDeleteEntity
    {
        /// <summary>
        /// 描述
        /// </summary>
        [MaxLength(32)]
        public string Description { get; set; }
        /// <summary>
        /// 部门名称
        /// </summary>
        [MaxLength(16)]
        public string DepartmentName { get; set; }
        /// <summary>
        /// 主管id
        /// </summary>
        [MaxLength(36)]
        public string? LeaderId { get; set; }
        /// <summary>
        /// 父部门id
        /// </summary>
        [MaxLength(36)]
        public string? ParentId { get; set; }
    }
}
