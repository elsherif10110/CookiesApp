using Microsoft.AspNetCore.Builder;
using System.Net;

// إعداد الخيارات الخاصة بالشهادة
ServicePointManager.ServerCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true;



var builder = WebApplication.CreateBuilder(args);

//***********************************
//to use MVC
builder.Services.AddControllersWithViews();

var app = builder.Build();


//***********************************
//Configure the Http request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    //The default HSTS value is 30 day. You may want o change this for product

    app.UseHsts();
}
//***********************************
//Redirection in https if i have a ssl certificate
app.UseHttpsRedirection();

//*********************************
//for use Static files
app.UseStaticFiles();

//*********************************
// to Use routing
app.UseRouting();

//********************************
//to use authorization
app.UseAuthorization();

//********************************
//to use Map Controller Route


app.UseEndpoints(endpoints =>
{
	endpoints.MapControllerRoute(
		name: "login",
		pattern: "account/login",
		defaults: new { controller = "Account", action = "Login" });


	endpoints.MapControllerRoute(
		name: "register",
		pattern: "account/register",
		defaults: new { controller = "Account", action = "Register" });


	endpoints.MapControllerRoute(
		name: "admin",
		pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");


	endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
});

app.Run();