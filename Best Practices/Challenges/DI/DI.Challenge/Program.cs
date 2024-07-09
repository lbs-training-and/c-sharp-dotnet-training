using DI.Challenge;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddPart01();
builder.Services.AddPart02();
builder.Services.AddPart03();
builder.Services.AddPart04();
builder.Services.AddPart05();
builder.Services.AddPart06();
builder.Services.AddPart07();

var app = builder.Build();

app.Run();

public partial class Program;