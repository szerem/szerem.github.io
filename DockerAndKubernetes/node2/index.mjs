import express from "express";
import { createClient } from "redis";
import process from "process";

const PORT = 8080;

const client = createClient({ url: "redis://redis-svc:6379" });
client.on("error", (err) => console.log("Redis Client Error", err));

await client.connect();
console.log(await client.ping()); // 'PONG'
await client.set("visits", 0);

/// web
const app = express();

app.get("/stop", async (req, res) => {
  process.exit(0);
});


app.get("/visits", async (req, res) => {
  const visits = parseInt(await client.get("visits"));
  res.send(`Number of visits is ${visits}`);
  await client.set("visits", visits+1);
});

app.get("/", (req, res) => {
  res.send(`Hello world`);
});

app.listen(PORT, () => {
  console.log(`Example app listening on port ${PORT}`);
});

// await subscriber.disconnect();
