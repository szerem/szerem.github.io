const express = require('express')
const os = require('os')
const app = express()

const port = 3000
const host = os.hostname()
const date = new Date();

app.get('/', (req, res) => {
  res.send(`Hello World! ${host} ${date.toISOString()}`)
})

app.listen(port, () => {
  console.log(`Example app listening on port ${port}`)
})
