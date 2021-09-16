## migrations 
dotnet ef migrations add addtestApi --startup-project WebApi --project Data --context BandaContext --output-dir Data\Migrations

dotnet ef database update --startup-project WebApi --project Data --context BandaContext



## migrations teste em uma camada
dotnet ef migrations add addtest --startup-project WebMVC --project WebMVC --context BandaATContext --output-dir Data\Migrations

dotnet ef database update --startup-project WebMVC --project WebMVC --context BandaATContext
