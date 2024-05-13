# BuberBreakfast

Following pracitcal course on implementing Clean Architecture & DDD principles in ASP.NET applications:\
https://www.youtube.com/playlist?list=PLzYkqgWkHPKBcDIP5gzLfASkQyTdy0t4k

Requires to have a secret set to generate JWT keys. Stored in configuration at path: `JwtSettings:Secret`.
Can be initialized using user-secrets for development purposes like so:
```bash
$ dotnet user-secrets init --project BuberBreakfast.WebApi
$ dotnet user-secrets --project BuberBreakfast.WebApi set JwtSettings:Secret <your_secret_larger_than_256_bytes>
```

The webapi can be run with the following command (assuming you have .NET SDK installed)
```bash
$ dotnet run --project BuberBreakfast.WebApi
```
