import axios from "axios"
const URL =  `${window.location.origin}/api/account/login`


export const PostLogin = async (user) => {
    const result = await axios.post(URL,user)
    .then((res)=>res)
    return result
}


