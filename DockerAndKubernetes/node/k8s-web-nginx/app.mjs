import express from 'express'
import fetch from 'node-fetch'
import os from 'os'

const app = express();

const PORT = 3000;
const HOST = os.hostname();

app.get("/", (req, res) => {
  const helloMessage = `Hello World! ${HOST} ${new Date().toISOString()}`;
  console.log(`server: ${helloMessage}`);
  res.send(`client: ${helloMessage}`);
});

app.get("/nginx", async (req, res) => {
  const url = "http://nginx";
  const response = await fetch(url);
  const body = await response.text();
  res.send(body);
});

app.listen(PORT, () => {
  console.log(`Example app listening on port ${PORT}`);
});
