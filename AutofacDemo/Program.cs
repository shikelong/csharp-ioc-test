using Autofac;
using AutofacDemo;
using System.Data.Common;
using Microsoft.Data.SqlClient;

public class Program
{
    static void Main(string[] args)
    {
        var builder = new ContainerBuilder();

        // 注册DbConnection的具体实现
        builder.Register(c => new SqlConnection("Server=myServerAddress;Database=myDataBase;User Id=myUsername;Password=myPassword;")).Named<DbConnection>("TestConnection");

        // 注册服务
        builder.Register(c => new DbContext(c.ResolveNamed<DbConnection>("TestConnection"), false)).As<IDbContext>();

        var container = builder.Build();

        // 解析服务并使用
        using (var scope = container.BeginLifetimeScope())
        {
            var service = scope.Resolve<IDbContext>();
            service.Connect();
        }
    }
}