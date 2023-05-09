FROM node:18-alpine AS node

WORKDIR /src
COPY package.json ./package.json

RUN npm install
COPY . .
CMD npm run build

FROM nginx:alpine
COPY nginx.conf /etc/nginx/nginx.conf
COPY --from=node /src/dist /usr/share/nginx/html