# System Test (.NET)

## Instructions

1. Open up the 'system-test' folder in Visual Studio (make sure it is at the root of your project)

2. Start Docker Containers

```shell
docker compose up -d
```

3. Run All Tests

```shell
dotnet test
```

4. Run Smoke Tests Only

```shell
dotnet test --filter "FullyQualifiedName~Optivem.AtddAccelerator.Template.SystemTest.SmokeTests"
```

5. Stop Docker Containers

```shell
docker compose down
```
