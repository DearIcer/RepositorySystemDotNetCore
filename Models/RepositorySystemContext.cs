using Microsoft.EntityFrameworkCore;

namespace Models
{
    public class RepositorySystemContext : DbContext
    {
        public RepositorySystemContext( DbContextOptions<RepositorySystemContext> options) : base(options) { }

        public virtual DbSet<UserInfo> UserInfo { get; set; }
        public virtual DbSet<RoleInfo> RoleInfo { get; set; }
        public virtual DbSet<R_UserInfo_RoleInfo> R_UserInfo_RoleInfo { get; set; }
        public virtual DbSet<DepartmentInfo> DepartmentInfo { get; set; }
        public virtual DbSet<MenuInfo> MenuInfo { get; set; }
        public virtual DbSet<R_RoleInfo_MenuInfo> R_RoleInfo_MenuInfo { get; set; }
        public virtual DbSet<ConsumableInfo> ConsumableInfo { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<ConsumableRecord> ConsumableRecord { get; set; }
        public virtual DbSet<WorkFlow_Instance> WorkFlow_Instance { get; set; }
        public virtual DbSet<WorkFlow_InstanceStep> WorkFlow_InstanceStep { get; set; }
        public virtual DbSet<WorkFlow_Model> WorkFlow_Model { get; set; }
        public virtual DbSet<FileInfo> FileInfo { get; set; }

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
    }


}