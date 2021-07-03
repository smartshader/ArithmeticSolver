FROM mcr.microsoft.com/dotnet/runtime:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["ArithmeticSolver/ArithmeticSolver.csproj", "ArithmeticSolver/"]
RUN dotnet restore "ArithmeticSolver/ArithmeticSolver.csproj"
COPY . .
WORKDIR "/src/ArithmeticSolver"
RUN dotnet build "ArithmeticSolver.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ArithmeticSolver.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ArithmeticSolver.dll"]
