# 🧠 AgentElite API

A lightweight, production-grade .NET Web API for utility operations like UUID generation and IP address inspection. Designed to replace low-code flows (e.g., n8n) with secure, observable, and scalable endpoints.

---

## 🚀 Endpoints

| Method | Route                | Description                        |
|--------|----------------------|------------------------------------|
| GET    | `/v1/util/new-uuid`  | Generate a new UUID (v4 format)    |
| GET    | `/v1/util/my-ip`     | Return caller’s IP and metadata    |

Both support content negotiation via the `Accept` header (`application/json`, `text/plain`).

---

## 🛠️ Getting Started

### ✅ Prerequisites

- [.NET SDK 6/7/8+](https://dotnet.microsoft.com/download)
- Git CLI
- (Optional) VS Code / Visual Studio

### 📦 Clone & Run

```bash
# Clone the repo
git clone https://github.com/YOUR_USERNAME/agentelite-api.git
cd agentelite-api

# Restore packages and build
dotnet restore
dotnet build

# Run the API locally
dotnet run

# Refer to following document for more details 
https://docs.google.com/document/d/1UomCV1SHAU2GOkK_TD9VCpozcw40IppOxvjgvl2LTTY/edit?tab=t.tb85ewf2ml2c