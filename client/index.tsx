import { ValuesClient } from "./generated/MyApi"

var api = new ValuesClient("")

api.getAll().then(data => {
    console.log(data);
}, err => {
    console.error(err);
})