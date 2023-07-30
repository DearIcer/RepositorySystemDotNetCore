using BLL;
using CommonLib;
using DAL;
using IBLL;
using IDAL;
using Microsoft.EntityFrameworkCore;
using Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<RepositorySystemContext>(options =>
{
    // �������ݿ������ַ���������ѡ��
    var connectionString = builder.Configuration.GetConnectionString("SqlStr");
    // �������ݿ������ַ���������ѡ��
    options.UseSqlServer(connectionString);
});

// ��ӷ���������
builder.Services.AddControllersWithViews();

// ע��Session
builder.Services.AddSession();

#region IOCע��

builder.Services.AddScoped<IUserInfoDAL, UserInfoDAL>();
builder.Services.AddScoped<IUserInfoBLL, UserInfoBLL>();

builder.Services.AddScoped<IDepartmentInfoDAL, DepartmentInfoDAL>();
builder.Services.AddScoped<IDepartmentInfoBLL, DepartmentInfoBLL>();

builder.Services.AddScoped<IRoleInfoDAL, RoleInfoDAL>();
builder.Services.AddScoped<IRoleInfoBLL, RoleInfoBLL>();

builder.Services.AddScoped<IR_UserInfo_RoleInfoDAL, R_UserInfo_RoleInfoDAL>();

builder.Services.AddScoped<IMenuInfoBLL, MenuInfoBLL>();
builder.Services.AddScoped<IMenuInfoDAL, MenuInfoDAL>();

builder.Services.AddScoped<IR_RoleInfo_MenuInfoDAL, R_RoleInfo_MenuInfoDAL>();

builder.Services.AddScoped<ICategoryDAL, CategoryDAL>();
builder.Services.AddScoped<ICategoryBLL, CategoryBLL>();

builder.Services.AddScoped<IConsumableRecordDAL, ConsumableRecordDAL>();
builder.Services.AddScoped<IConsumableRecordBLL, ConsumableRecordBLL>();

builder.Services.AddScoped<IConsumableInfoDAL, ConsumableInfoDAL>();
builder.Services.AddScoped<IConsumableInfoBLL, ConsumableInfoBLL>();

builder.Services.AddScoped<IWorkFlow_ModelDAL, WorkFlow_ModelDAL>();
builder.Services.AddScoped<IWorkFlow_ModelBLL, WorkFlow_ModelBLL>();

builder.Services.AddScoped<IWorkFlow_InstanceDAL, WorkFlow_InstanceDAL>();
builder.Services.AddScoped<IWorkFlow_InstanceBLL, WorkFlow_InstanceBLL>();

builder.Services.AddScoped<IWorkFlow_InstanceStepDAL, WorkFlow_InstanceStepDAL>();
builder.Services.AddScoped<IWorkFlow_InstanceStepBLL, WorkFlow_InstanceStepBLL>();
#endregion
var app = builder.Build();

// ���� HTTP ������ܵ�
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseStaticFiles();

app.UseRouting();

app.UseSession();
app.UseAuthorization();

//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Home}/{action=Index}/{id?}");
app.UseEndpoints(endpoints =>
{
    //Ĭ����ת·��
    endpoints.MapAreaControllerRoute(
    name: "Home",
    areaName: "Admin",
    pattern: "{controller=Home}/{action=Index}/{id?}");

    endpoints.MapControllerRoute(
        name: "Admin",
        pattern: "{area:exists}/{controller=Account}/{action=Login}/{id?}");

    endpoints.MapControllerRoute(
        name: "Admin",
        pattern: "{area:exists}/{controller=MenuInfo}/{action=ListView}/{id?}");
});
//InitDB();
app.Run();


static void InitDB()
{
    var options = new DbContextOptionsBuilder<RepositorySystemContext>()
        .UseSqlServer(@"Data Source=.;Initial Catalog=RepositorySystem_Core;Integrated Security=True;TrustServerCertificate=True").Options;

    RepositorySystemContext db = new RepositorySystemContext(options);

    db.Database.EnsureDeleted();
    db.Database.EnsureCreated();

    // ��Ӳ����û�
    UserInfo userInfo = new UserInfo()
    {
        Id = Guid.NewGuid().ToString(),
        Account = "admin",
        PassWord = MD5Help.GenerateMD5("123456"),
        CreatedTime = DateTime.Now,
        IsAdmin = true,
        UserName = "testdata",
        DepartmentId = Guid.NewGuid().ToString(),
    };

    db.UserInfo.Add(userInfo);


    Console.WriteLine(db.SaveChanges() > 0);
}