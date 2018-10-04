import { ValuesClient } from "./generated/TypeScript/MyApiClient"

let api = new ValuesClient("")

api.post("New values").then(rs => {
    console.log(rs);
})