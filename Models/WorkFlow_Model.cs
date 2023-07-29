using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class WorkFlow_Model : BaseDeleteEntity
    {
        /// <summary>
        /// 模板标题
        /// </summary>
        [MaxLength(32)]
        public string Title { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        [MaxLength(64)]
        public string Description { get; set; }
    }
}
