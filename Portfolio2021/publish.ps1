Write-Output "dotnet publish:"
dotnet publish -c Release -o .\bin\Publish\

Write-Output "push gh-pages"
Set-Location .\bin\Publish\wwwroot
git add .
git commit -m "via publish script"
git push origin gh-pages
Set-Location ..\..\..
