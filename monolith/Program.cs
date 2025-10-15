var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddHttpClient();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

// Add API endpoint for testing
app.MapGet("/api/echo", () => "Hello from API!");

// Add todos API endpoint for E2E testing
app.MapGet("/api/todos/{id:int}", async (int id) =>
{
    var baseUrl = app.Configuration["ExternalApis:JsonPlaceholder"] ?? "https://jsonplaceholder.typicode.com";
    
    using var httpClient = new HttpClient();
    var response = await httpClient.GetAsync($"{baseUrl}/todos/{id}");
    
    if (response.IsSuccessStatusCode)
    {
        var jsonContent = await response.Content.ReadAsStringAsync();
        return Results.Content(jsonContent, "application/json");
    }
    
    return Results.NotFound();
});

app.Run();

// TODO: VJ: DELETE COMMENT 2025-10-08