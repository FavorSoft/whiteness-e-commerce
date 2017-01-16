const express = require('express')  
const app = express()  
const path = require('path')    
const exphbs = require('express-handlebars')

const port = 3000

app.engine('.hbs', exphbs({  
  defaultLayout: 'main',
  extname: '.hbs',
  layoutsDir: path.join(__dirname, 'views/layouts')
}))
app.set('view engine', '.hbs')  
app.set('views', path.join(__dirname, 'views'))  

app.get('/', (request, response) => {  
  response.render('home', {
    name: 'Max'
  })
})

app.listen(port, (err) => {  
  if (err) {
    return console.log('something bad happened', err)
  }

  console.log(`server is listening on ${port}`)
})