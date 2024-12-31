const express = require('express')
// const os = require('os')
const app = express()


const PORT = 8080
// const HOST = os.hostname();

app.get('/', (req, res) => {
  res.send('Hello World!')
})

app.listen(PORT, () => {
  console.log(`Example app listening on port ${PORT}`)
})
