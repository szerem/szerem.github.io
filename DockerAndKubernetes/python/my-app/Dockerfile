FROM node:alpine3.21

WORKDIR /app

EXPOSE 3000

COPY ./package.json ./

RUN npm install --silent

COPY . ./

CMD [ "npm", "run", "start" ]

