#!/bin/bash
docker compose pull;
docker compose down;
docker compose up -d;
docker system prune -f;
docker compose logs api -f;
