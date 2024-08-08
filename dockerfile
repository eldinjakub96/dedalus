# Use the .NET SDK image to build the application
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /app

# Copy the .csproj file and restore dependencies
COPY *.csproj ./
RUN dotnet restore

# Copy the rest of the application code
COPY . ./
RUN dotnet build -c Release -o /app/build

# Use the .NET runtime image to run the application
FROM mcr.microsoft.com/dotnet/runtime:7.0
WORKDIR /app
COPY --from=build /app/build .

# Create the required directory structure
RUN mkdir -p /var/opt/dedalus/userdata/bin \
               /var/opt/dedalus/userdata/charts/beta/validations \
               /var/opt/dedalus/userdata/ci \
               /var/opt/dedalus/userdata/postgres/data/logs \
               /var/opt/dedalus/userdata/script \
               /var/opt/dedalus/userdata/templates

ENTRYPOINT ["dotnet", "DedalusTask.dll"]
