param(
    [Parameter(Mandatory=$true)]
    [string]$MigrationName
)

Write-Host "Adding migration '$MigrationName' to Sqlite project..." -ForegroundColor Cyan
dotnet ef migrations add $MigrationName --project ./PenguinStreamerBot.Sqlite -- --provider Sqlite

if ($LASTEXITCODE -ne 0) {
    Write-Host "Failed to add migration to Sqlite project" -ForegroundColor Red
    exit $LASTEXITCODE
}

Write-Host "`nAdding migration '$MigrationName' to Postgres project..." -ForegroundColor Cyan
dotnet ef migrations add $MigrationName --project ./PenguinStreamerBot.Postgres -- --provider Postgres

if ($LASTEXITCODE -ne 0) {
    Write-Host "Failed to add migration to Postgres project" -ForegroundColor Red
    exit $LASTEXITCODE
}

Write-Host "`nMigrations added successfully!" -ForegroundColor Green
