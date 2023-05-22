using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using N5.Challenge.Api.Entities;
using N5.Challenge.Api.Persistence;
using N5.Challenge.Api.Repositories;
using N5.Challenge.Test;

[TestClass]
public class RepositoryUnitTests : BaseTest
{
    [TestMethod]
    public async Task FindAllAsync()
    {
        string dbName = Guid.NewGuid().ToString();
        DataContext context = BuildContext(dbName);

        await context.Permissions.AddAsync(new Permissions { NombreEmpleado = "Empleado 1", ApellidoEmpleado = "Empleado 1", FechaPermiso = DateTime.Now, TipoPermiso = 1 });
        await context.Permissions.AddAsync(new Permissions { NombreEmpleado = "Empleado 2", ApellidoEmpleado = "Empleado 2", FechaPermiso = DateTime.Now, TipoPermiso = 1 });

        await context.SaveChangesAsync();

        DataContext context2 = BuildContext(dbName);

        Repository repository = new Repository(context2);
        ActionResult<List<Permissions>> response = await repository.FindAllAsync<Permissions>();
        List<Permissions> permissions = response.Value;
        Assert.AreEqual(2, permissions.Count);

    }


    [TestMethod]
    public async Task GetByIdAsync()
    {
        string dbName = Guid.NewGuid().ToString();
        DataContext context = BuildContext(dbName);

        await context.Permissions.AddAsync(new Permissions { NombreEmpleado = "Empleado 1", ApellidoEmpleado = "Empleado 1", FechaPermiso = DateTime.Now, TipoPermiso = 1 });
        await context.Permissions.AddAsync(new Permissions { NombreEmpleado = "Empleado 2", ApellidoEmpleado = "Empleado 2", FechaPermiso = DateTime.Now, TipoPermiso = 1 });

        await context.SaveChangesAsync();

        DataContext context2 = BuildContext(dbName);

        int id = 2;

        Repository repository = new Repository(context2);
        Permissions response = await repository.GetById<Permissions>(id);
        Assert.AreEqual(id, response.Id);

    }

    [TestMethod]
    public async Task AddAsync()
    {
        string dbName = Guid.NewGuid().ToString();
        DataContext context = BuildContext(dbName);

        var permission = new Permissions { NombreEmpleado = "Empleado 1", ApellidoEmpleado = "Empleado 1", FechaPermiso = DateTime.Now, TipoPermiso = 1 };

        Repository repository = new Repository(context);
        repository.Add<Permissions>(permission);
        await context.SaveChangesAsync();

        var context2 = BuildContext(dbName);
        var totalData = await context2.Permissions.CountAsync();
        Assert.AreEqual(1, totalData);

    }


    [TestMethod]
    public async Task UpdateAsync()
    {
        string dbName = Guid.NewGuid().ToString();
        DataContext context = BuildContext(dbName);

        await context.Permissions.AddAsync(new Permissions { NombreEmpleado = "Empleado 1", ApellidoEmpleado = "Empleado 1", FechaPermiso = DateTime.Now, TipoPermiso = 1 });
        await context.SaveChangesAsync();

        var context2 = BuildContext(dbName);

        Repository repository = new Repository(context2);

        var permissions = new Permissions { Id = 1, NombreEmpleado = "Empleado 2", ApellidoEmpleado = "Empleado 1", FechaPermiso = DateTime.Now, TipoPermiso = 1 };

        var id = 1;
        repository.Update<Permissions>(permissions);
        await context2.SaveChangesAsync();

        var exist = await context2.Permissions.AnyAsync(x => x.NombreEmpleado == "Empleado 2");
        Assert.IsTrue(exist);

    }


}
