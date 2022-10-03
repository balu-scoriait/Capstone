using Newtonsoft.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
// *********** Added CORS ***********
builder.Services.AddCors(c => { c.AddPolicy("AllowOrigin", Options => Options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()); });
// *********** Added CORS ***********
builder.Services.AddControllersWithViews();

builder.Services.AddControllersWithViews().AddNewtonsoftJson(opt =>
opt.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore)
    .AddNewtonsoftJson(opt =>
opt.SerializerSettings.ContractResolver = new DefaultContractResolver());
builder.Services.AddMvc(opt => opt.EnableEndpointRouting = false).AddXmlSerializerFormatters();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddSession();
var app = builder.Build();
// *********** Added CORS ***********
app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()); // Added CORS
// *********** Added CORS balu *********** 
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
}


app.UseStaticFiles();
app.UseRouting();

app.UseSession();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller}/{action=Index}/{id?}");
});

app.MapFallbackToFile("index.html"); ;

app.Run();
app.UseMvc();
