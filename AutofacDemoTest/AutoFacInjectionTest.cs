using System.Data.Common;
using Autofac;
using AutofacDemo;
using Microsoft.Data.SqlClient;
using Xunit;

public class AutoFacInjectionTest
{
    [Fact]
    public void Test_DatabaseService_Resolution()
    {
        var builder = new ContainerBuilder();

        builder.Register(c => new SqlConnection("Server=myServerAddress;Database=myDataBase;User Id=myUsername;Password=myPassword;"))
               .Named<DbConnection>("TestConnection");

        builder.Register(c => new DbContext(c.ResolveNamed<DbConnection>("TestConnection"), false))
               .As<IDbContext>();

        var container = builder.Build();

        // 尝试解析IDatabaseService
        var service = container.Resolve<IDbContext>();

        Assert.NotNull(service);
    }

}
