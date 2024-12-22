
// Importuj moduł 
const rl = require('readline'); 
const fs = require('fs');



// Użyj metod Metody 
const readline = rl.createInterface({ 
  input: process.stdin, 
  output: process.stdout 
});


readline.question('Enter fileName:', (fileName) => {  
  readline.question('Enter same test:', (fileText) => {
    fs.writeFile(`${fileName}.log`, fileText, function(err) {
      if(err) {
          return console.log(err);
      }
      console.log("The file was created");
      readline.close();
      // process.exit(0);
    }); 
  });
});



