FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /source

ARG LELYA_TOKEN
ENV LELYA_TOKEN=$LELYA_TOKEN	

COPY Lelya.Bot .
RUN dotnet restore Lelya.Bot.csproj

COPY . .
RUN dotnet publish Lelya.Bot/Lelya.Bot.csproj -c Release -o out

FROM mcr.microsoft.com/dotnet/runtime:8.0 AS runtime
WORKDIR /app
COPY --from=build /source/out .

ENTRYPOINT ["dotnet", "Bot.dll"]