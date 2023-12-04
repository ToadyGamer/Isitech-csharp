const express = require('express')
const app = express()
app.listen(3000, () => {
    console.log('http://localhost:3000/')
})

const mysql = require('mysql2');
const connection = mysql.createConnection({
	host:'localhost',
	user:'root',
	password:'',
	database:'bddtpdotnet'
});