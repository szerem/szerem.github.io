const express = require('express')
const os = require('os')
const app = express()

const port = 3000
const host = os.hostname()

app.get('/', (req, res) => {
  const helloMessage = `Hello World! ${host} ${(new Date()).toISOString()}`;
  console.log(`server: ${helloMessage}`);
  res.send(`client: ${helloMessage}`);
})

app.listen(port, () => {
  console.log(`Example app listening on port ${port}`)
})
