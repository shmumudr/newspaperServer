
using System;
using System.IO;
using System.Text.Json;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using indoxApi.Models;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularLocalhost",
        policy =>
        {
            policy.WithOrigins("http://localhost:4200")
                  .AllowAnyMethod()
                  .AllowAnyHeader();
        });
});

var app = builder.Build();


app.UseCors("AllowAngularLocalhost");


app.MapGet("/", () => "Hello World!");

app.MapGet("/names", () =>
{

    string jsonFile = "NPnames.json";
    string data = File.ReadAllText(jsonFile);
    return Results.Content(data, "application/json");


});



app.MapGet("/data/{id}", (string id) =>
{
    
        string jsonFile = "data.json";
        string jsonContent = File.ReadAllText(jsonFile);

        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        var items = JsonSerializer.Deserialize<List<Indox>>(jsonContent, options);


        var matchedItem = items.FirstOrDefault(i => i.Id == idInt);


        return Results.Json(new List<Indox> { matchedItem });

});

app.Run();
