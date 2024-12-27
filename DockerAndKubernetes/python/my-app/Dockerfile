FROM node:alpine3.21

WORKDIR /app

EXPOSE 3000

# COPY . ./
COPY ./public ./public
COPY ./src ./src
COPY ./package.json ./

RUN npm install --silent

CMD [ "npm", "start" ]

