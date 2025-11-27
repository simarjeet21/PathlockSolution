# Pathlock-Solution

# PLC Home Coding - Complete Solution

This repo contains solutions for:
1. Basic Task Manager (backend + frontend)
2. Mini Project Manager (full features: auth, projects, tasks)
3. Smart Scheduler API

Folders:
- backend/: .NET 8 Web API (SQLite + EF Core + JWT)
- frontend/: React + TypeScript SPA

## Run Backend
- cd backend/src/PLCHome.Api
- dotnet restore
- Update appsettings.json or set env vars (Jwt:Key, ConnectionStrings)
- dotnet ef database update
- dotnet run

## Run Frontend
- cd frontend/plc-home
- npm install
- npm run dev
- VITE_API_URL should point to backend API

## Submission
Do not upload a .zip. Push this repo to GitHub/GitLab and share link.

## Bonus (Deployment)
- Backend: Deploy to Render/Heroku using Docker or .NET start commands.
- Frontend: Deploy to Vercel (connect to this repo).
