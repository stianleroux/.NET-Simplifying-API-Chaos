using Projects;

var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Farris_Api>("FarrisApi");
builder.AddProject<Frump_Api>("FrumpApi");
builder.AddProject<FusaElection_UI>("FusaElection");

builder.Build().Run();
