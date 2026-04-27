FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /app
# 1. Install Python 3 (Required by Wasm-Tools/Emscripten)
RUN apt-get update && apt-get install -y python3
COPY . .
# Install tools and publish
RUN dotnet workload install wasm-tools
RUN dotnet publish -c Release -o out

# Use a lightweight web server for the runtime
FROM nginx:alpine
WORKDIR /usr/share/nginx/html
# Copy the published static files from the build stage
COPY --from=build /app/out/wwwroot .
# Railway needs Nginx to listen on the $PORT variable
COPY nginx.conf /etc/nginx/conf.d/default.conf
EXPOSE 80