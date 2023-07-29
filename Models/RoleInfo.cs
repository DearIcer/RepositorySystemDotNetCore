using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class RoleInfo : BaseDeleteEntity
    {
        /// <summary>
        /// 角色名称
        /// </summary>
        [MaxLength(16)]
        public string RoleName { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        [MaxLength(32)]
        public string Description { get; set; }
    }
}
