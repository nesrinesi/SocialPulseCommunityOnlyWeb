

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
/*
//Migration database/
// root db
MigrationRootDB rootDB = new MigrationRootDB();
rootDB.Migrate();

//users db
Databases databases = new Databases();
if (databases?.GetAll() != null && databases.GetAll().Count() > 0)
{
    foreach (var database in databases.GetAll())
    {
        MigrationDB db = new MigrationDB(database.Host, database.DBName, database.Password, database.UserName);
        db.Migrate();
    }
}

*/

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
