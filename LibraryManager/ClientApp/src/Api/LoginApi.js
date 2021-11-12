import axios from "axios"
const URL = 'https://localhost:44340/api/account/login'


export const PostLogin = async (user) => {
    const result = await axios.post(URL,user)
    .then((res)=>res)
    return result
}


