## migrations IDENTITY
dotnet ef migrations add addIdentity --startup-project WebMVC --project WebMVC --context IdentityATContext --output-dir Areas\Identity\Data\Migrations

dotnet ef database update --startup-project WebMVC --project WebMVC --context IdentityATContext

## migrations MODELS
dotnet ef migrations add addtestApi --startup-project WebApi --project Data --context BandaATContext --output-dir Migrations

dotnet ef database update --startup-project WebApi --project WebApi --context BandaATContext
