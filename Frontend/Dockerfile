# Stage 1: Build React App bằng Node.js
FROM node:20-alpine AS build
WORKDIR /app

# Copy package.json và cài đặt thư viện
COPY package*.json ./
RUN npm install

# Copy toàn bộ source code và build ra thư mục /dist
COPY . .
RUN npm run build

# Stage 2: Serve bằng Nginx
FROM nginx:alpine

# Copy code đã build từ Stage 1 sang thư mục html của Nginx
COPY --from=build /app/dist /usr/share/nginx/html

# Expose cổng 80
EXPOSE 80

# Chạy Nginx
CMD ["nginx", "-g", "daemon off;"]